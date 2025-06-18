using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final_Project_SHA_V1._2.Forms;
using Final_Project_SHA_V1._2.Services;

namespace Final_Project_SHA_V1._2.Pages
{
    public partial class Dashboard_Page : Form
    {
        private FrmMain _startPage;

        public Dashboard_Page(FrmMain startPage)
        {
            InitializeComponent();
            _startPage = startPage;

            if (SessionManager.Role == "User")
            {
                ADMINDASHBOARDbtn.Enabled = false;
            }
            else
            {
                ADMINDASHBOARDbtn.Enabled = true;
            }
        }

        private void UPDATEPASSWORDbtn_Click(object sender, EventArgs e)
        {
            _startPage.loadform(new UpdatePassword_Page(_startPage));
            _startPage.resetButtons();
        }

        private void ADMINDASHBOARDbtn_Click(object sender, EventArgs e)
        {            
            _startPage.loadform(new AdminDashboard(_startPage));
            _startPage.resetButtons();
        }

        private void Homebtn_Click(object sender, EventArgs e)
        {
            _startPage.loadform(new Dashboard_Page(_startPage));
            _startPage.resetButtons();
        }
    }
}
