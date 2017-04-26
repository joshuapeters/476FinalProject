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
                return parseSuccess && threadCount > 0 ? threadCount : 1;
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
            ToggleWaitCursor();
            ConvertBitmapToAscii();
            ToggleWaitCursor();
        }

        private void btnResetCanvas_Click(object sender, EventArgs e)
        {        
            ResetCanvas();
        }

        private void ToggleWaitCursor()
        {
            if (Cursor.Current == Cursors.Default)
                Cursor.Current = Cursors.WaitCursor;
            else
                Cursor.Current = Cursors.Default;
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

            var threadCount = ThreadCount;

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var asciiMap = bitMap.ToGrayScaleRGBMatrixAsync(ThreadCount);
            stopWatch.Stop();
            SetElapsedTime(stopWatch);

            drawAsciiMap(asciiMap);

            ToggleCanvasEditting();
        }


        private void drawAsciiMap (char[,] asciiMap)
        {
            var lines = new string[asciiMap.GetLength(1)]; 


            for (int y = 0; y < asciiMap.GetLength(1); ++y)
            {
                string output = "";
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
                lines[y] = output;
            }

            rtbAsciiCanvas.Lines = lines;
        }

        private void SetElapsedTime(Stopwatch stopWatch)
        {
            lblElapsed.Text = $"Elapsed Time: {stopWatch.ElapsedMilliseconds} ms";
        }

        private void generateSwitchCode()
        {
            string s = "$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/\\|()1{}[]?-_+~<>i!lI;:,\" ^`'. ";
            string code = "switch(RBG){\n";
            for (int i = 0; i < s.Length; ++i)
            {
                code += "case " + i + ":\n\treturn \'" + s[i] + "\';\n";
            }
            rtbAsciiCanvas.Text = code + "}";
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
            var currentPath = AppDomain.CurrentDomain.BaseDirectory;
            var fileName = $"AsciiExport_{new Random(DateTime.Now.Ticks.GetHashCode()).Next()}.rtf";
            var filePath = currentPath + fileName;
            using (var writer = new StreamWriter(filePath, true))
            {
                writer.Write(rtbAsciiCanvas.Text);
            }
        }

        private void rtbAsciiCanvas_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
