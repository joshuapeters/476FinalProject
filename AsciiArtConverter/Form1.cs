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
            ToggleBetaComponents(false);
            BindFonts();
            numFontSize.Text = rtbAsciiCanvas.Font.SizeInPoints.ToString();
            ddlFonts.SelectedItem = rtbAsciiCanvas.Font.FontFamily.Name;
        }

        private void ToggleBetaComponents(bool display)
        {
            numFontSize.Visible = display;
            ddlFonts.Visible = display;
            lblFontSize.Visible = display;
            lblFont.Visible = display;
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
            var bitMap = (Bitmap) Image.FromFile(filePath);

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
            rtbAsciiCanvas.Font = new Font("Courier New", 2);
            numFontSize.Text = rtbAsciiCanvas.Font.SizeInPoints.ToString();
            ddlFonts.SelectedItem = rtbAsciiCanvas.Font.FontFamily.Name;
            ToggleCanvasEditting();

            ToggleTextBox();
            txtFileText.Text = string.Empty;
            ToggleTextBox();

            txtThreadCount.Text = "0";
        }

        private void LoadFile()
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            var dr = fileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ToggleTextBox();
                txtFileText.Text = fileDialog.FileName;
                ToggleTextBox();
            }
        }

        // messes up current image when font size changes
        private void UpdateFont()
        {
            var currentFont = rtbAsciiCanvas.Font;
            var font = new Font(ddlFonts.SelectedText, decimal.ToInt64(numFontSize.Value));

            rtbAsciiCanvas.SelectAll();
            rtbAsciiCanvas.SelectionFont = font;
            
        }

        private void BindFonts()
        {
            System.Drawing.Text.InstalledFontCollection col = new System.Drawing.Text.InstalledFontCollection();
            ddlFonts.Items.AddRange(col.Families.Select(f => f.Name).ToArray());
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var currentPath = AppDomain.CurrentDomain.BaseDirectory;
            var fileName = $"AsciiExport_{new Random(DateTime.Now.Ticks.GetHashCode()).Next()}.rtf";
            var filePath = currentPath + fileName;
            using (var writer = new StreamWriter(filePath, true))
            {
                writer.Write(rtbAsciiCanvas.Rtf);
            }
        }

        private void rtbAsciiCanvas_TextChanged(object sender, EventArgs e)
        {

        }


        private void numFontSize_ValueChanged(object sender, EventArgs e)
        {
            UpdateFont();
        }

        private void ddlFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFont();
        }

        private void chkBeta_CheckedChanged(object sender, EventArgs e)
        {
            ToggleBetaComponents(chkBeta.Checked);
        }
    }
}
