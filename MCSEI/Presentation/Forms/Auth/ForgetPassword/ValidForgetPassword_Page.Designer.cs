namespace Final_Project_SHA_V1._2.Pages
{
    partial class ValidForgetPassword_Page
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValidForgetPassword_Page));
            this.panel1 = new System.Windows.Forms.Panel();
            this.VERIFYbtn = new System.Windows.Forms.PictureBox();
            this.CODEtxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VERIFYbtn)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.CODEtxt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.VERIFYbtn);
            this.panel1.Location = new System.Drawing.Point(420, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 741);
            this.panel1.TabIndex = 2;
            // 
            // VERIFYbtn
            // 
            this.VERIFYbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.VERIFYbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VERIFYbtn.Image = ((System.Drawing.Image)(resources.GetObject("VERIFYbtn.Image")));
            this.VERIFYbtn.Location = new System.Drawing.Point(152, 538);
            this.VERIFYbtn.Name = "VERIFYbtn";
            this.VERIFYbtn.Size = new System.Drawing.Size(580, 44);
            this.VERIFYbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.VERIFYbtn.TabIndex = 29;
            this.VERIFYbtn.TabStop = false;
            this.VERIFYbtn.Click += new System.EventHandler(this.VERIFYbtn_Click);
            // 
            // CODEtxt
            // 
            this.CODEtxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CODEtxt.BackColor = System.Drawing.Color.White;
            this.CODEtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.CODEtxt.Location = new System.Drawing.Point(152, 455);
            this.CODEtxt.Name = "CODEtxt";
            this.CODEtxt.Size = new System.Drawing.Size(580, 44);
            this.CODEtxt.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(145, 415);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 37);
            this.label2.TabIndex = 31;
            this.label2.Text = "Code";
            // 
            // ValidForgetPassword_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1678, 952);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ValidForgetPassword_Page";
            this.Text = "ValidForgetPassword_Page";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VERIFYbtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox CODEtxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox VERIFYbtn;
    }
}