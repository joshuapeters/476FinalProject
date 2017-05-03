namespace AsciiArtConverter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbAsciiCanvas = new System.Windows.Forms.RichTextBox();
            this.txtFileText = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnFileSelector = new System.Windows.Forms.Button();
            this.btnResetCanvas = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtThreadCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblElapsed = new System.Windows.Forms.Label();
            this.lblFontSize = new System.Windows.Forms.Label();
            this.numFontSize = new System.Windows.Forms.NumericUpDown();
            this.ddlFonts = new System.Windows.Forms.ComboBox();
            this.lblFont = new System.Windows.Forms.Label();
            this.chkBeta = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbAsciiCanvas
            // 
            this.rtbAsciiCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbAsciiCanvas.DetectUrls = false;
            this.rtbAsciiCanvas.Font = new System.Drawing.Font("Courier New", 2F);
            this.rtbAsciiCanvas.Location = new System.Drawing.Point(14, 75);
            this.rtbAsciiCanvas.Name = "rtbAsciiCanvas";
            this.rtbAsciiCanvas.ReadOnly = true;
            this.rtbAsciiCanvas.Size = new System.Drawing.Size(1771, 1029);
            this.rtbAsciiCanvas.TabIndex = 0;
            this.rtbAsciiCanvas.Text = "";
            this.rtbAsciiCanvas.WordWrap = false;
            this.rtbAsciiCanvas.TextChanged += new System.EventHandler(this.rtbAsciiCanvas_TextChanged);
            // 
            // txtFileText
            // 
            this.txtFileText.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileText.Location = new System.Drawing.Point(12, 12);
            this.txtFileText.Name = "txtFileText";
            this.txtFileText.ReadOnly = true;
            this.txtFileText.Size = new System.Drawing.Size(342, 21);
            this.txtFileText.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnFileSelector
            // 
            this.btnFileSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileSelector.Location = new System.Drawing.Point(362, 15);
            this.btnFileSelector.Name = "btnFileSelector";
            this.btnFileSelector.Size = new System.Drawing.Size(38, 23);
            this.btnFileSelector.TabIndex = 2;
            this.btnFileSelector.Text = "...";
            this.btnFileSelector.UseVisualStyleBackColor = true;
            this.btnFileSelector.Click += new System.EventHandler(this.fileSelector_Click);
            // 
            // btnResetCanvas
            // 
            this.btnResetCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetCanvas.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetCanvas.Location = new System.Drawing.Point(944, 12);
            this.btnResetCanvas.Name = "btnResetCanvas";
            this.btnResetCanvas.Size = new System.Drawing.Size(128, 23);
            this.btnResetCanvas.TabIndex = 3;
            this.btnResetCanvas.Text = "Reset Canvas";
            this.btnResetCanvas.UseVisualStyleBackColor = true;
            this.btnResetCanvas.Click += new System.EventHandler(this.btnResetCanvas_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.Location = new System.Drawing.Point(817, 12);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(122, 23);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // txtThreadCount
            // 
            this.txtThreadCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThreadCount.Location = new System.Drawing.Point(106, 42);
            this.txtThreadCount.MaxLength = 2;
            this.txtThreadCount.Name = "txtThreadCount";
            this.txtThreadCount.Size = new System.Drawing.Size(70, 21);
            this.txtThreadCount.TabIndex = 6;
            this.txtThreadCount.Text = "0";
            this.txtThreadCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtThreadCount.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Thread Count: ";
            // 
            // lblElapsed
            // 
            this.lblElapsed.AutoSize = true;
            this.lblElapsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElapsed.Location = new System.Drawing.Point(645, 20);
            this.lblElapsed.Name = "lblElapsed";
            this.lblElapsed.Size = new System.Drawing.Size(108, 15);
            this.lblElapsed.TabIndex = 8;
            this.lblElapsed.Text = "Elapsed Time: N/A";
            // 
            // lblFontSize
            // 
            this.lblFontSize.AutoSize = true;
            this.lblFontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFontSize.Location = new System.Drawing.Point(442, 45);
            this.lblFontSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFontSize.Name = "lblFontSize";
            this.lblFontSize.Size = new System.Drawing.Size(61, 15);
            this.lblFontSize.TabIndex = 10;
            this.lblFontSize.Text = "Font Size:";
            // 
            // numFontSize
            // 
            this.numFontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numFontSize.Location = new System.Drawing.Point(510, 42);
            this.numFontSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numFontSize.Maximum = new decimal(new int[] {
            46,
            0,
            0,
            0});
            this.numFontSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFontSize.Name = "numFontSize";
            this.numFontSize.Size = new System.Drawing.Size(70, 21);
            this.numFontSize.TabIndex = 11;
            this.numFontSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFontSize.ValueChanged += new System.EventHandler(this.numFontSize_ValueChanged);
            // 
            // ddlFonts
            // 
            this.ddlFonts.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlFonts.FormattingEnabled = true;
            this.ddlFonts.Location = new System.Drawing.Point(252, 42);
            this.ddlFonts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ddlFonts.Name = "ddlFonts";
            this.ddlFonts.Size = new System.Drawing.Size(180, 23);
            this.ddlFonts.TabIndex = 12;
            this.ddlFonts.SelectedIndexChanged += new System.EventHandler(this.ddlFonts_SelectedIndexChanged);
            this.ddlFonts.TextChanged += new System.EventHandler(this.ddlFonts_SelectedIndexChanged);
            // 
            // lblFont
            // 
            this.lblFont.AutoSize = true;
            this.lblFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFont.Location = new System.Drawing.Point(210, 46);
            this.lblFont.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(34, 15);
            this.lblFont.TabIndex = 13;
            this.lblFont.Text = "Font:";
            // 
            // chkBeta
            // 
            this.chkBeta.AutoSize = true;
            this.chkBeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.chkBeta.Location = new System.Drawing.Point(429, 15);
            this.chkBeta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkBeta.Name = "chkBeta";
            this.chkBeta.Size = new System.Drawing.Size(143, 21);
            this.chkBeta.TabIndex = 14;
            this.chkBeta.Text = "Show Beta Features";
            this.chkBeta.UseVisualStyleBackColor = true;
            this.chkBeta.CheckedChanged += new System.EventHandler(this.chkBeta_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1803, 1028);
            this.Controls.Add(this.chkBeta);
            this.Controls.Add(this.lblFont);
            this.Controls.Add(this.ddlFonts);
            this.Controls.Add(this.numFontSize);
            this.Controls.Add(this.lblFontSize);
            this.Controls.Add(this.lblElapsed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtThreadCount);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnResetCanvas);
            this.Controls.Add(this.btnFileSelector);
            this.Controls.Add(this.txtFileText);
            this.Controls.Add(this.rtbAsciiCanvas);
            this.MinimumSize = new System.Drawing.Size(1489, 1032);
            this.Name = "Form1";
            this.Text = "Picture To Ascii Art Converter";
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ToggleCanvasEditting()
        {
            rtbAsciiCanvas.ReadOnly = !rtbAsciiCanvas.ReadOnly;
        }

        private void ToggleTextBox()
        {
            txtFileText.ReadOnly = !txtFileText.ReadOnly;
        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbAsciiCanvas;
        private System.Windows.Forms.TextBox txtFileText;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnFileSelector;
        private System.Windows.Forms.Button btnResetCanvas;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox txtThreadCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblElapsed;
        private System.Windows.Forms.Label lblFontSize;
        private System.Windows.Forms.NumericUpDown numFontSize;
        private System.Windows.Forms.ComboBox ddlFonts;
        private System.Windows.Forms.Label lblFont;
        private System.Windows.Forms.CheckBox chkBeta;
    }
}

