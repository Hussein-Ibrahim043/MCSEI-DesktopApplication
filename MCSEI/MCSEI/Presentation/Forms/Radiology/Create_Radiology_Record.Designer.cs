namespace Final_Project_SHA_V1._2.Pages
{
    partial class Create_Radiology_Record
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Create_Radiology_Record));
            this.SELECTFILEbtn = new System.Windows.Forms.PictureBox();
            this.SELECTED_PIC = new System.Windows.Forms.PictureBox();
            this.REPORTtb = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RADIOLOGYTYPEcb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CANCELbtn = new System.Windows.Forms.PictureBox();
            this.SAVEbtn = new System.Windows.Forms.PictureBox();
            this.NIDtb = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SELECTFILEbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SELECTED_PIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CANCELbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SAVEbtn)).BeginInit();
            this.SuspendLayout();
            // 
            // SELECTFILEbtn
            // 
            this.SELECTFILEbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SELECTFILEbtn.Image = ((System.Drawing.Image)(resources.GetObject("SELECTFILEbtn.Image")));
            this.SELECTFILEbtn.Location = new System.Drawing.Point(12, 706);
            this.SELECTFILEbtn.Name = "SELECTFILEbtn";
            this.SELECTFILEbtn.Size = new System.Drawing.Size(165, 44);
            this.SELECTFILEbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SELECTFILEbtn.TabIndex = 100;
            this.SELECTFILEbtn.TabStop = false;
            this.SELECTFILEbtn.Click += new System.EventHandler(this.SELECTFILEbtn_Click);
            // 
            // SELECTED_PIC
            // 
            this.SELECTED_PIC.BackColor = System.Drawing.Color.Gainsboro;
            this.SELECTED_PIC.Location = new System.Drawing.Point(12, 384);
            this.SELECTED_PIC.Name = "SELECTED_PIC";
            this.SELECTED_PIC.Size = new System.Drawing.Size(441, 316);
            this.SELECTED_PIC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.SELECTED_PIC.TabIndex = 99;
            this.SELECTED_PIC.TabStop = false;
            // 
            // REPORTtb
            // 
            this.REPORTtb.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.REPORTtb.Location = new System.Drawing.Point(12, 277);
            this.REPORTtb.Name = "REPORTtb";
            this.REPORTtb.Size = new System.Drawing.Size(441, 101);
            this.REPORTtb.TabIndex = 94;
            this.REPORTtb.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(0, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 31);
            this.label5.TabIndex = 93;
            this.label5.Text = "Report";
            // 
            // RADIOLOGYTYPEcb
            // 
            this.RADIOLOGYTYPEcb.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RADIOLOGYTYPEcb.FormattingEnabled = true;
            this.RADIOLOGYTYPEcb.Items.AddRange(new object[] {
            "X-Ray",
            "MRI",
            "CT Scan",
            "Ultrasound"});
            this.RADIOLOGYTYPEcb.Location = new System.Drawing.Point(12, 181);
            this.RADIOLOGYTYPEcb.Name = "RADIOLOGYTYPEcb";
            this.RADIOLOGYTYPEcb.Size = new System.Drawing.Size(441, 39);
            this.RADIOLOGYTYPEcb.TabIndex = 92;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(0, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 31);
            this.label1.TabIndex = 91;
            this.label1.Text = "Radiology Type";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(98, -8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(252, 47);
            this.label8.TabIndex = 107;
            this.label8.Text = "Create Record";
            // 
            // CANCELbtn
            // 
            this.CANCELbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CANCELbtn.Image = ((System.Drawing.Image)(resources.GetObject("CANCELbtn.Image")));
            this.CANCELbtn.Location = new System.Drawing.Point(148, 793);
            this.CANCELbtn.Name = "CANCELbtn";
            this.CANCELbtn.Size = new System.Drawing.Size(149, 52);
            this.CANCELbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.CANCELbtn.TabIndex = 111;
            this.CANCELbtn.TabStop = false;
            this.CANCELbtn.Click += new System.EventHandler(this.CANCELbtn_Click);
            // 
            // SAVEbtn
            // 
            this.SAVEbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SAVEbtn.Image = ((System.Drawing.Image)(resources.GetObject("SAVEbtn.Image")));
            this.SAVEbtn.Location = new System.Drawing.Point(303, 793);
            this.SAVEbtn.Name = "SAVEbtn";
            this.SAVEbtn.Size = new System.Drawing.Size(175, 52);
            this.SAVEbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.SAVEbtn.TabIndex = 110;
            this.SAVEbtn.TabStop = false;
            this.SAVEbtn.Click += new System.EventHandler(this.SAVEbtn_Click);
            // 
            // NIDtb
            // 
            this.NIDtb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NIDtb.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NIDtb.Location = new System.Drawing.Point(12, 89);
            this.NIDtb.MaxLength = 14;
            this.NIDtb.Name = "NIDtb";
            this.NIDtb.Size = new System.Drawing.Size(441, 44);
            this.NIDtb.TabIndex = 113;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(0, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 31);
            this.label10.TabIndex = 112;
            this.label10.Text = "National ID";
            // 
            // Create_Radiology_Record
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(481, 857);
            this.Controls.Add(this.NIDtb);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CANCELbtn);
            this.Controls.Add(this.SAVEbtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.SELECTFILEbtn);
            this.Controls.Add(this.SELECTED_PIC);
            this.Controls.Add(this.REPORTtb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RADIOLOGYTYPEcb);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Create_Radiology_Record";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Radiology Record";
            ((System.ComponentModel.ISupportInitialize)(this.SELECTFILEbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SELECTED_PIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CANCELbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SAVEbtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox SELECTFILEbtn;
        private System.Windows.Forms.PictureBox SELECTED_PIC;
        private System.Windows.Forms.RichTextBox REPORTtb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox RADIOLOGYTYPEcb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox CANCELbtn;
        private System.Windows.Forms.PictureBox SAVEbtn;
        private System.Windows.Forms.TextBox NIDtb;
        private System.Windows.Forms.Label label10;
    }
}