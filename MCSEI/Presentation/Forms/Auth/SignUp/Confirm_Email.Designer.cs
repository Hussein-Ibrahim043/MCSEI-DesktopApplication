namespace Final_Project_SHA_V1._2.Pages
{
    partial class Confirm_Email
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Confirm_Email));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CONFIRMbtn = new System.Windows.Forms.PictureBox();
            this.EMAILADDRESStb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CONFIRMCODEtb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CONFIRMbtn)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.CONFIRMbtn);
            this.panel1.Controls.Add(this.EMAILADDRESStb);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CONFIRMCODEtb);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(470, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 741);
            this.panel1.TabIndex = 2;
            // 
            // CONFIRMbtn
            // 
            this.CONFIRMbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CONFIRMbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CONFIRMbtn.Image = ((System.Drawing.Image)(resources.GetObject("CONFIRMbtn.Image")));
            this.CONFIRMbtn.Location = new System.Drawing.Point(76, 631);
            this.CONFIRMbtn.Name = "CONFIRMbtn";
            this.CONFIRMbtn.Size = new System.Drawing.Size(580, 44);
            this.CONFIRMbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CONFIRMbtn.TabIndex = 38;
            this.CONFIRMbtn.TabStop = false;
            this.CONFIRMbtn.Click += new System.EventHandler(this.CONFIRMbtn_Click);
            // 
            // EMAILADDRESStb
            // 
            this.EMAILADDRESStb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EMAILADDRESStb.BackColor = System.Drawing.Color.White;
            this.EMAILADDRESStb.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.EMAILADDRESStb.Location = new System.Drawing.Point(76, 398);
            this.EMAILADDRESStb.Name = "EMAILADDRESStb";
            this.EMAILADDRESStb.Size = new System.Drawing.Size(580, 44);
            this.EMAILADDRESStb.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(69, 485);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(302, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "Confirmation Code";
            // 
            // CONFIRMCODEtb
            // 
            this.CONFIRMCODEtb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CONFIRMCODEtb.BackColor = System.Drawing.Color.White;
            this.CONFIRMCODEtb.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.CONFIRMCODEtb.Location = new System.Drawing.Point(76, 525);
            this.CONFIRMCODEtb.Name = "CONFIRMCODEtb";
            this.CONFIRMCODEtb.Size = new System.Drawing.Size(580, 44);
            this.CONFIRMCODEtb.TabIndex = 2;
            this.CONFIRMCODEtb.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(69, 358);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email Address";
            // 
            // Confirm_Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1662, 913);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Confirm_Email";
            this.Text = "Confirm_Email";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CONFIRMbtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox EMAILADDRESStb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CONFIRMCODEtb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox CONFIRMbtn;
    }
}