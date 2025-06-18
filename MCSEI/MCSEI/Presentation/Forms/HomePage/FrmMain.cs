using System;
using System.Drawing;
using System.Windows.Forms;
using Final_Project_SHA_V1._2.Core.Interfaces;
using Final_Project_SHA_V1._2.Pages;
using Final_Project_SHA_V1._2.Services;

namespace Final_Project_SHA_V1._2.Forms
{
    public partial class FrmMain : Form
    {
        private readonly IAuthService _authService;
        public FrmMain()
        {
            InitializeComponent();
            Login_Page loginPage = new Pages.Login_Page(this);
            loadform(loginPage);
            deactivateButtons();


            // Create service instance
            _authService = new AuthService();
        }
        //hussinibrahim043
        public void activateButtons()
        {
            CITIZENbtn.Enabled = true;
            MEDICALbtn.Enabled = true;
            RADIOLOGYbtn.Enabled = true;
            EXPORTbtn.Enabled = true;
            LOGOUTbtn.Enabled = true;
        }
        public void deactivateButtons()
        {
            CITIZENbtn.Enabled = false;
            MEDICALbtn.Enabled = false;
            RADIOLOGYbtn.Enabled = false;
            EXPORTbtn.Enabled = false;
            LOGOUTbtn.Enabled = false;
        }
        public void loadform(object Form)
        {
            if (this.ContentPannel.Controls.Count > 0)
            {
                this.ContentPannel.Controls.RemoveAt(0);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.ContentPannel.Controls.Add(f);
            this.ContentPannel.Tag = f;
            f.Show();
        }

        private void LOGOUTbtn_Click(object sender, EventArgs e)
        {
            _authService.Logout();
            deactivateButtons();
            Login_Page loginPage = new Pages.Login_Page(this);
            loadform(loginPage);
            resetButtons();
        }

        private void CITIZENbtn_Click(object sender, EventArgs e)
        {
            this.CITIZENbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.MEDICALbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.RADIOLOGYbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.EXPORTbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            //this.LOGOUTbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;

            resetButtons();
            this.CITIZENbtn.BackColor = Color.WhiteSmoke;
            this.CITIZENbtn.ForeColor = Color.DarkBlue;
            Citizens_Page CitizenPage = new Pages.Citizens_Page(this);
            loadform(CitizenPage);

        }

        private void MEDICALbtn_Click(object sender, EventArgs e)
        {
            this.CITIZENbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.MEDICALbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.RADIOLOGYbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.EXPORTbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            //this.LOGOUTbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;

            resetButtons();
            this.MEDICALbtn.BackColor = Color.WhiteSmoke;
            this.MEDICALbtn.ForeColor = Color.DarkBlue;
            Medical_Page medicalPage = new Pages.Medical_Page(this);
            loadform(medicalPage);
        }

        private void RADIOLOGYbtn_Click(object sender, EventArgs e)
        {
            this.CITIZENbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.MEDICALbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.RADIOLOGYbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.EXPORTbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            //this.LOGOUTbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            
            resetButtons();
            this.RADIOLOGYbtn.BackColor = Color.WhiteSmoke;
            this.RADIOLOGYbtn.ForeColor = Color.DarkBlue;
            Radiology_Page radiologyPage = new Pages.Radiology_Page(this);
            loadform(radiologyPage);
        }

        private void EXPORTbtn_Click(object sender, EventArgs e)
        {
            this.CITIZENbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.MEDICALbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.RADIOLOGYbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.EXPORTbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aquamarine;
            this.LOGOUTbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;


            resetButtons();
            this.EXPORTbtn.BackColor = Color.WhiteSmoke;
            this.EXPORTbtn.ForeColor = Color.DarkBlue;
            Export_Page exportPage = new Pages.Export_Page(this);
            loadform(exportPage);
        }

        public void resetButtons()
        {
            this.CITIZENbtn.BackColor = Color.FromArgb(99, 74, 255);
            this.CITIZENbtn.ForeColor = System.Drawing.SystemColors.ButtonFace;

            this.MEDICALbtn.BackColor = Color.FromArgb(99, 74, 255);
            this.MEDICALbtn.ForeColor = System.Drawing.SystemColors.ButtonFace;

            this.RADIOLOGYbtn.BackColor = Color.FromArgb(99, 74, 255);
            this.RADIOLOGYbtn.ForeColor = System.Drawing.SystemColors.ButtonFace;

            this.LOGOUTbtn.BackColor = Color.FromArgb(99, 74, 255);
            this.LOGOUTbtn.ForeColor = System.Drawing.SystemColors.ButtonFace;

            this.EXPORTbtn.BackColor = Color.FromArgb(99, 74, 255);
            this.EXPORTbtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
        }
    
    }
}
