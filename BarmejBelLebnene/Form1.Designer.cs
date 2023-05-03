namespace BarmejBelLebnene
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            bblCode = new TextBox();
            compileBtn = new Button();
            saveFileDialog1 = new SaveFileDialog();
            generateSampleBtn = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // bblCode
            // 
            bblCode.AcceptsTab = true;
            bblCode.BorderStyle = BorderStyle.FixedSingle;
            bblCode.Location = new Point(12, 49);
            bblCode.Multiline = true;
            bblCode.Name = "bblCode";
            bblCode.Size = new Size(882, 383);
            bblCode.TabIndex = 0;
            // 
            // compileBtn
            // 
            compileBtn.BackColor = SystemColors.HotTrack;
            compileBtn.Cursor = Cursors.Hand;
            compileBtn.FlatStyle = FlatStyle.Popup;
            compileBtn.ForeColor = SystemColors.Window;
            compileBtn.Location = new Point(820, 448);
            compileBtn.Name = "compileBtn";
            compileBtn.Size = new Size(75, 23);
            compileBtn.TabIndex = 1;
            compileBtn.Text = "Compile";
            compileBtn.UseVisualStyleBackColor = false;
            compileBtn.Click += compileBtn_Click;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.Title = "Save Assembly Code";
            // 
            // generateSampleBtn
            // 
            generateSampleBtn.BackColor = SystemColors.HotTrack;
            generateSampleBtn.Cursor = Cursors.Hand;
            generateSampleBtn.DialogResult = DialogResult.OK;
            generateSampleBtn.FlatStyle = FlatStyle.Popup;
            generateSampleBtn.ForeColor = SystemColors.Window;
            generateSampleBtn.Location = new Point(736, 12);
            generateSampleBtn.Name = "generateSampleBtn";
            generateSampleBtn.Size = new Size(114, 31);
            generateSampleBtn.TabIndex = 2;
            generateSampleBtn.Text = "Sample Code";
            generateSampleBtn.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Window;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(856, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(51, 42);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(907, 483);
            Controls.Add(pictureBox1);
            Controls.Add(generateSampleBtn);
            Controls.Add(compileBtn);
            Controls.Add(bblCode);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox bblCode;
        private Button compileBtn;
        private SaveFileDialog saveFileDialog1;
        private Button generateSampleBtn;
        private PictureBox pictureBox1;
    }
}