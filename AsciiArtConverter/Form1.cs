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

            var bitMap = new Bitmap(filePath).GrayScale();
            bitMap.LockBits(new Rectangle(0, 0, bitMap.Width, bitMap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bitMap.PixelFormat);
            var threadCount = ThreadCount;

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            ParallelAsciiGenerator(ref bitMap, threadCount);

            stopWatch.Stop();
            SetElapsedTime(stopWatch);

            ToggleCanvasEditting();
        }

        private void ParallelAsciiGenerator(ref Bitmap bitmap, int threadCount)
        {
            // todo: The hard shit.
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
    }
}
