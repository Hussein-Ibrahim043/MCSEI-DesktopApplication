namespace Final_Project_SHA_V1._2.Pages
{
    partial class ResetPassword_Page
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetPassword_Page));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CONFIRMPASSWORDtxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PASSWORDtxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RESETbtn = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RESETbtn)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.CONFIRMPASSWORDtxt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.PASSWORDtxt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.RESETbtn);
            this.panel1.Location = new System.Drawing.Point(420, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 741);
            this.panel1.TabIndex = 2;
            // 
            // CONFIRMPASSWORDtxt
            // 
            this.CONFIRMPASSWORDtxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CONFIRMPASSWORDtxt.BackColor = System.Drawing.Color.White;
            this.CONFIRMPASSWORDtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.CONFIRMPASSWORDtxt.Location = new System.Drawing.Point(160, 492);
            this.CONFIRMPASSWORDtxt.Name = "CONFIRMPASSWORDtxt";
            this.CONFIRMPASSWORDtxt.Size = new System.Drawing.Size(580, 44);
            this.CONFIRMPASSWORDtxt.TabIndex = 34;
            this.CONFIRMPASSWORDtxt.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(154, 458);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(252, 31);
            this.label4.TabIndex = 35;
            this.label4.Text = "Confirm Password";
            // 
            // PASSWORDtxt
            // 
            this.PASSWORDtxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PASSWORDtxt.BackColor = System.Drawing.Color.White;
            this.PASSWORDtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.PASSWORDtxt.Location = new System.Drawing.Point(160, 405);
            this.PASSWORDtxt.Name = "PASSWORDtxt";
            this.PASSWORDtxt.Size = new System.Drawing.Size(580, 44);
            this.PASSWORDtxt.TabIndex = 32;
            this.PASSWORDtxt.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(154, 371);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 31);
            this.label3.TabIndex = 33;
            this.label3.Text = "New Password";
            // 
            // RESETbtn
            // 
            this.RESETbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.RESETbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RESETbtn.Image = ((System.Drawing.Image)(resources.GetObject("RESETbtn.Image")));
            this.RESETbtn.Location = new System.Drawing.Point(160, 561);
            this.RESETbtn.Name = "RESETbtn";
            this.RESETbtn.Size = new System.Drawing.Size(580, 44);
            this.RESETbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RESETbtn.TabIndex = 29;
            this.RESETbtn.TabStop = false;
            this.RESETbtn.Click += new System.EventHandler(this.RESETbtn_Click);
            // 
            // ResetPassword_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1678, 952);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ResetPassword_Page";
            this.Text = "ResetPassword_Page";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RESETbtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox RESETbtn;
        private System.Windows.Forms.TextBox CONFIRMPASSWORDtxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PASSWORDtxt;
        private System.Windows.Forms.Label label3;
    }
}