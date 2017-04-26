using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace AsciiArtConverter
{
    public partial class Form1 : Form
    {
        private int ThreadCount
        {
            get
            {
                var threadCount = -1;
                var parseSuccess = int.TryParse(txtThreadCount.Text, out threadCount);
                return parseSuccess && threadCount >= 0 ? threadCount : 0;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void fileSelector_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            ConvertBitmapToAscii();
        }

        private void btnResetCanvas_Click(object sender, EventArgs e)
        {        
            ResetCanvas();
        }

        private void ConvertBitmapToAscii()
        {
            var filePath = txtFileText.Text;
            if (string.IsNullOrEmpty(filePath))
            {
                ShowTextBox("No file has been specified!");
                return;
            }

            ToggleCanvasEditting();

            var bitMap = new Bitmap(filePath);

            //bitMap.LockBits(new Rectangle(0, 0, bitMap.Width, bitMap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bitMap.PixelFormat);
            var threadCount = ThreadCount;

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            int[,] grayMap = toIntMatrix(bitMap);
            serialAsciiGenerator(ref grayMap);
            //ParallelAsciiGenerator(grayMap, threadCount);

            stopWatch.Stop();
            SetElapsedTime(stopWatch);

            ToggleCanvasEditting();
        }

        private  int[,] toIntMatrix(Bitmap Bmp)
        {
            int rgb;
            int[,] pixelMatrix = new int[Bmp.Width, Bmp.Height];
            Color c;
            //Bmp = CreateNonIndexedImage(Bmp);
            for (int x = 0; x < Bmp.Width; ++x)
            {
                for (int y = 0; y < Bmp.Height; ++y)
                {
                    c = Bmp.GetPixel(x, y);
                    pixelMatrix[x, y] = (int)((c.R + c.G + c.B) / 3);
                }
            }
            return pixelMatrix;
        }

        private Bitmap CreateNonIndexedImage(Image src)
        {
            Bitmap newBmp = new Bitmap(src.Width, src.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics gfx = Graphics.FromImage(newBmp))
            {
                gfx.DrawImage(src, 0, 0);
            }

            return newBmp;
        }

        private void printIntArray (int[,] a)
        {
            string s = "";
            for (int i = 0; i < a.GetLength(0); ++i)
            {
                for (int j = 0; j < a.GetLength(1); ++j)
                {
                    s += a[i, j] + " ";
                }
                s += "\n";
            }
            rtbAsciiCanvas.Text = s;
        }

        private char GrayToAscii(int RGB)
        {
            // .:-=+*#%@
            int x = RGB / 25;
            switch (x)
            {
                case 0:
                    return '@';
                case 1:
                    return '%';
                case 2:
                    return '#';
                case 3:
                    return '*';
                case 4:
                    return '+';
                case 5:
                    return '=';
                case 6:
                    return '-';
                case 7:
                    return ':';
                case 8:
                    return '.';
                case 9:
                    return ' ';
                case 10:
                    return ' ';
            }  
            return ' ';
        }

        private void serialAsciiGenerator(ref int[,] grayMap)
        {
            //printIntArray(grayMap);
            //return;
            char[,] asciiMap = new char[grayMap.GetLength(0), grayMap.GetLength(1)];
            for (int x = 0; x < asciiMap.GetLength(0); ++x)
            {
                for (int y = 0; y < asciiMap.GetLength(1); ++y)
                {
                    asciiMap[x, y] = GrayToAscii(grayMap[x, y]);
                }
            }
            drawAsciiMap(ref asciiMap);
        }

        private void serialAsciiGenerator(ref Bitmap bitmap)
        {
            //todo: The easier shit.
            char[,] asciiMap = new char[bitmap.Width, bitmap.Height];
            for (int x = 0; x < bitmap.Width; ++x)
            {
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    asciiMap[x, y] = GrayToAscii(bitmap.GetPixel(y, x).R);
                }
            }

            drawAsciiMap(ref asciiMap);
            
        }

        private void drawAsciiMap (ref char[,] asciiMap)
        {
            string output = "";
            for (int y = 0; y < asciiMap.GetLength(1); ++y)
            {
                for (int x = 0; x < asciiMap.GetLength(0); ++x)
                {
                    try
                    {
                        output += asciiMap[x, y];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        output += "_";
                    }
                }
                output += "\n";
            }
            rtbAsciiCanvas.Text = output;
        }

        private void ParallelAsciiGenerator(int[,] intMatrix, int threadCount)
        {
            // todo: The hard shit.
            char[,] asciiMap = new char[intMatrix.GetLength(0), intMatrix.GetLength(1)];
            Task[] tasks = new Task[threadCount];
            int start, end;
            int N = intMatrix.GetLength(0) * intMatrix.GetLength(1);
            for (int p_id = 0; p_id < threadCount; ++p_id)
            {
                start = (p_id * N) / threadCount;
                end = ((p_id + 1) * N) / threadCount;
                tasks[p_id] = new Task(() => populateAsciiMap(ref asciiMap, ref intMatrix, p_id, start, end));   
            }

            drawAsciiMap(ref asciiMap);
            

        }

        private void populateAsciiMap(ref char[,] asciiMap, ref int[,] intMatrix, int p_id, int start, int end)
        {
            int x = start / asciiMap.GetLength(0);
            int y = start % asciiMap.GetLength(0);
            int end_x = end / asciiMap.GetLength(0);
            int end_y = end % asciiMap.GetLength(0);

            for (; x < end_x; ++x)
            {
                for (; y < end_y; ++y)
                {
                    asciiMap[x, y] = GrayToAscii(intMatrix[x, y]);
                }
            }
            /*
             *  0  1  2  3  4  5  
             *  6  7  8  9 10 11 
             * 12 13 14 15 16 17
               18 19 20 21 22 23
             */
        }

        private void SetElapsedTime(Stopwatch stopWatch)
        {
            lblElapsed.Text = $"Elapsed Time: {stopWatch.ElapsedMilliseconds} ms";
        }
        

        private void ShowTextBox(string message)
        {
            var textBox = new TextBox();
            textBox.Text = message;
            textBox.Show();
        }

        private void ResetCanvas()
        {
            ToggleCanvasEditting();
            rtbAsciiCanvas.Text = string.Empty;
            ToggleCanvasEditting();

            ToggleTextBox();
            txtFileText.Text = string.Empty;
            ToggleTextBox();
        }

        private void LoadFile()
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files | *.bmp;";
            var dr = fileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ToggleTextBox();
                txtFileText.Text = fileDialog.FileName;
                ToggleTextBox();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory;
            var fileName = $"AsciiExport_{new Random(DateTime.Now.Ticks.GetHashCode())}";
            using (var writer = new StreamWriter(fileName, true))
            {
                writer.Write(rtbAsciiCanvas.Text);
            }
        }

        private void rtbAsciiCanvas_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
