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
            this.btnExport = new System.Windows.Forms.Button();
            this.txtThreadCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbAsciiCanvas
            // 
            this.rtbAsciiCanvas.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbAsciiCanvas.Location = new System.Drawing.Point(13, 66);
            this.rtbAsciiCanvas.Name = "rtbAsciiCanvas";
            this.rtbAsciiCanvas.ReadOnly = true;
            this.rtbAsciiCanvas.Size = new System.Drawing.Size(953, 866);
            this.rtbAsciiCanvas.TabIndex = 0;
            this.rtbAsciiCanvas.Text = "";
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
            this.btnFileSelector.Location = new System.Drawing.Point(711, 10);
            this.btnFileSelector.Name = "btnFileSelector";
            this.btnFileSelector.Size = new System.Drawing.Size(38, 23);
            this.btnFileSelector.TabIndex = 2;
            this.btnFileSelector.Text = "...";
            this.btnFileSelector.UseVisualStyleBackColor = true;
            this.btnFileSelector.Click += new System.EventHandler(this.fileSelector_Click);
            // 
            // btnResetCanvas
            // 
            this.btnResetCanvas.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetCanvas.Location = new System.Drawing.Point(857, 10);
            this.btnResetCanvas.Name = "btnResetCanvas";
            this.btnResetCanvas.Size = new System.Drawing.Size(109, 23);
            this.btnResetCanvas.TabIndex = 3;
            this.btnResetCanvas.Text = "Reset Canvas";
            this.btnResetCanvas.UseVisualStyleBackColor = true;
            this.btnResetCanvas.Click += new System.EventHandler(this.btnResetCanvas_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.Location = new System.Drawing.Point(755, 10);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(96, 23);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(711, 38);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(255, 23);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtThreadCount
            // 
            this.txtThreadCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThreadCount.Location = new System.Drawing.Point(284, 39);
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
            this.label1.Location = new System.Drawing.Point(191, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Thread Count: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 944);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtThreadCount);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnResetCanvas);
            this.Controls.Add(this.btnFileSelector);
            this.Controls.Add(this.txtFileText);
            this.Controls.Add(this.rtbAsciiCanvas);
            this.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.MinimumSize = new System.Drawing.Size(1000, 1000);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtThreadCount;
        private System.Windows.Forms.Label label1;
    }
}

