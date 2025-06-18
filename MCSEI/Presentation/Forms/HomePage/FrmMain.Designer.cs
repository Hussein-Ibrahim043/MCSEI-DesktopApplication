using System.Drawing;

namespace Final_Project_SHA_V1._2.Forms
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CITIZENbtn = new System.Windows.Forms.Button();
            this.MEDICALbtn = new System.Windows.Forms.Button();
            this.RADIOLOGYbtn = new System.Windows.Forms.Button();
            this.EXPORTbtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LOGOUTbtn = new System.Windows.Forms.Button();
            this.ContentPannel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.CITIZENbtn);
            this.flowLayoutPanel1.Controls.Add(this.MEDICALbtn);
            this.flowLayoutPanel1.Controls.Add(this.RADIOLOGYbtn);
            this.flowLayoutPanel1.Controls.Add(this.EXPORTbtn);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(230, 991);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 204);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(42, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(127, 134);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Sitka Text", 33F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(22, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(172, 63);
            this.label8.TabIndex = 26;
            this.label8.Text = "MCSEI";
            // 
            // CITIZENbtn
            // 
            this.CITIZENbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CITIZENbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CITIZENbtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.CITIZENbtn.FlatAppearance.BorderSize = 0;
            this.CITIZENbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CITIZENbtn.Font = new System.Drawing.Font("Sitka Text", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CITIZENbtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CITIZENbtn.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.CITIZENbtn.Location = new System.Drawing.Point(3, 213);
            this.CITIZENbtn.Name = "CITIZENbtn";
            this.CITIZENbtn.Size = new System.Drawing.Size(227, 60);
            this.CITIZENbtn.TabIndex = 1;
            this.CITIZENbtn.Text = "Citizens";
            this.CITIZENbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CITIZENbtn.UseVisualStyleBackColor = true;
            this.CITIZENbtn.Click += new System.EventHandler(this.CITIZENbtn_Click);
            // 
            // MEDICALbtn
            // 
            this.MEDICALbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MEDICALbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MEDICALbtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.MEDICALbtn.FlatAppearance.BorderSize = 0;
            this.MEDICALbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MEDICALbtn.Font = new System.Drawing.Font("Sitka Text", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MEDICALbtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MEDICALbtn.Location = new System.Drawing.Point(3, 279);
            this.MEDICALbtn.Name = "MEDICALbtn";
            this.MEDICALbtn.Size = new System.Drawing.Size(227, 60);
            this.MEDICALbtn.TabIndex = 1;
            this.MEDICALbtn.Text = "Medical";
            this.MEDICALbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MEDICALbtn.UseVisualStyleBackColor = true;
            this.MEDICALbtn.Click += new System.EventHandler(this.MEDICALbtn_Click);
            // 
            // RADIOLOGYbtn
            // 
            this.RADIOLOGYbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.RADIOLOGYbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RADIOLOGYbtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.RADIOLOGYbtn.FlatAppearance.BorderSize = 0;
            this.RADIOLOGYbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RADIOLOGYbtn.Font = new System.Drawing.Font("Sitka Text", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RADIOLOGYbtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.RADIOLOGYbtn.Location = new System.Drawing.Point(3, 345);
            this.RADIOLOGYbtn.Name = "RADIOLOGYbtn";
            this.RADIOLOGYbtn.Size = new System.Drawing.Size(227, 60);
            this.RADIOLOGYbtn.TabIndex = 1;
            this.RADIOLOGYbtn.Text = "Radiology";
            this.RADIOLOGYbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RADIOLOGYbtn.UseVisualStyleBackColor = true;
            this.RADIOLOGYbtn.Click += new System.EventHandler(this.RADIOLOGYbtn_Click);
            // 
            // EXPORTbtn
            // 
            this.EXPORTbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EXPORTbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EXPORTbtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.EXPORTbtn.FlatAppearance.BorderSize = 0;
            this.EXPORTbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EXPORTbtn.Font = new System.Drawing.Font("Sitka Text", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EXPORTbtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.EXPORTbtn.Location = new System.Drawing.Point(3, 411);
            this.EXPORTbtn.Name = "EXPORTbtn";
            this.EXPORTbtn.Size = new System.Drawing.Size(227, 60);
            this.EXPORTbtn.TabIndex = 1;
            this.EXPORTbtn.Text = "Export";
            this.EXPORTbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EXPORTbtn.UseVisualStyleBackColor = true;
            this.EXPORTbtn.Click += new System.EventHandler(this.EXPORTbtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.LOGOUTbtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 477);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(227, 514);
            this.panel2.TabIndex = 29;
            // 
            // LOGOUTbtn
            // 
            this.LOGOUTbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LOGOUTbtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LOGOUTbtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(74)))), ((int)(((byte)(255)))));
            this.LOGOUTbtn.FlatAppearance.BorderSize = 0;
            this.LOGOUTbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LOGOUTbtn.Font = new System.Drawing.Font("Sitka Text", 20F, System.Drawing.FontStyle.Bold);
            this.LOGOUTbtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LOGOUTbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LOGOUTbtn.Location = new System.Drawing.Point(0, 454);
            this.LOGOUTbtn.Name = "LOGOUTbtn";
            this.LOGOUTbtn.Size = new System.Drawing.Size(227, 60);
            this.LOGOUTbtn.TabIndex = 2;
            this.LOGOUTbtn.Text = "Log out";
            this.LOGOUTbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LOGOUTbtn.UseVisualStyleBackColor = true;
            this.LOGOUTbtn.Click += new System.EventHandler(this.LOGOUTbtn_Click);
            // 
            // ContentPannel
            // 
            this.ContentPannel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ContentPannel.Location = new System.Drawing.Point(236, 0);
            this.ContentPannel.Name = "ContentPannel";
            this.ContentPannel.Size = new System.Drawing.Size(1684, 991);
            this.ContentPannel.TabIndex = 1;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 991);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.ContentPannel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MCSEI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CITIZENbtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel ContentPannel;
        private System.Windows.Forms.Button MEDICALbtn;
        private System.Windows.Forms.Button RADIOLOGYbtn;
        private System.Windows.Forms.Button EXPORTbtn;
        private System.Windows.Forms.Button LOGOUTbtn;
        private System.Windows.Forms.Panel panel2;
    }
}