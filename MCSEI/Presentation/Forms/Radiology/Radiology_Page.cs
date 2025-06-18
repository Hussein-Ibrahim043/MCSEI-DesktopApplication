using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final_Project_SHA_V1._2.Core.Interfaces;
using Final_Project_SHA_V1._2.Core.Models;
using Final_Project_SHA_V1._2.Forms;
using Final_Project_SHA_V1._2.Infrastructure.Utils;
using Final_Project_SHA_V1._2.Services;
using MCSEI.Presentation.Forms.Radiology;
using Newtonsoft.Json;


namespace Final_Project_SHA_V1._2.Pages
{
    public partial class Radiology_Page : Form
    {
        private FrmMain _startPage;
        private readonly IRadiologyService _radiologyservice;
        private readonly ICitizenService _citizenService;
        string _ID = null;

        public Radiology_Page(FrmMain startPage)
        {
            InitializeComponent();
            _startPage = startPage;

            // Initialize services
            _radiologyservice = new RadiologyService();
            _citizenService = new CitizenService();
        }

        // Event handler: Opens the Create Radiology Record form with National ID preloaded
        private void CREATERECORDbtn_Click(object sender, EventArgs e)
        {
            Create_Radiology_Record createRadiology = new Create_Radiology_Record();
            createRadiology.LoadNID(NIDtb.Text);
            createRadiology.Show();
            string nationalId = NIDtb.Text.Trim();
            _ = LoadRadiologyData(nationalId); // Refresh data after update
        }

        // Event handler: Triggers on National ID text change to fetch citizen and radiology data
        private async void NIDtb_TextChanged(object sender, EventArgs e)
        {
            string nid = NIDtb.Text.Trim();

            if (nid.Length != 14)
            {
                ClearCitizenFields();
                return;
            }

            try
            {
                var citizenResponse = await _citizenService.GetCitizenByNationalIdAsync(nid);
                LoadRadiologyData(nid); //Display Radiology data in table.

                if (citizenResponse?.Citizen != null)
                {
                    var citizen = citizenResponse.Citizen;
                    FULLNAMEtb.Text = citizen.FullName ?? "N/A";
                    ADDRESStb.Text = citizen.Address ?? "N/A";
                    BLOODtb.Text = citizen.BloodType ?? "N/A";
                    BIRTHDATEtb.Text = citizen.BirthDate.ToString("yyyy-MM-dd");
                }
                else
                {
                    ClearCitizenFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while fetching citizen data:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearCitizenFields();
            }
        }

        // Loads all radiology records for a given National ID and displays them in the table
        private async Task LoadRadiologyData(string nationalId)
        {
            try
            {
                RadiologyApiResponse response = await _radiologyservice.GetRadiologyRecordsAsync(nationalId);

               /* if (response.Data.Radiology != null && response.Data.Radiology.Count > 0)
                {*/
                TABLEdgv.Rows.Clear();

                foreach (var record in response.Data.Radiology)
                {
                    string imageUrl = record.Images != null && record.Images.Count > 0
                        ? record.Images[0].SecureUrl
                        : "No image available";

                    TABLEdgv.Rows.Add(
                        record._id,
                        record.RadiologyType,
                        record.Report,
                        record.Date.ToString("yyyy-MM-dd"),
                        imageUrl
                    );
                }
               /* }
                else
                {
                    MessageBox.Show("No radiology records found.");
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error loading radiology data: " + ex.Message);
            }
        }

        // Event handler: Deletes the selected radiology record after confirmation
        private async void DELETEbtn_Click(object sender, EventArgs e)
        {
            string nationalId = NIDtb.Text.Trim();

            if (!Validator.IsValidNationalID(nationalId))
            {
                MessageBox.Show("Please enter the National ID to delete.");
                return;
            }

            if (TABLEdgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record.");
                return;
            }

            var selectedRow = TABLEdgv.SelectedRows[0];
            _ID = selectedRow.Cells[0].Value?.ToString();

            DialogResult confirmResult = MessageBox.Show(
                "Are you sure you want to delete this radiology record?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                bool response = await _radiologyservice.DeleteRadiologyRecordAsync(nationalId, _ID);
                if (response)
                {
                    MessageBox.Show("Radiology record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ = LoadRadiologyData(nationalId); // Refresh the table
                }
                else
                {
                    MessageBox.Show("Failed to delete radiology record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete radiology record.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler: Opens update form with the selected radiology record’s data prefilled
        private async void UPDATEbtn_Click(object sender, EventArgs e)
        {
            if (TABLEdgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record.");
                return;
            }

            var selectedRow = TABLEdgv.SelectedRows[0];
            _ID = selectedRow.Cells[0].Value?.ToString();
            string type = selectedRow.Cells[1].Value?.ToString();
            string report = selectedRow.Cells[2].Value?.ToString();
            string imageUrl = selectedRow.Cells[4].Value?.ToString();
            string nid = NIDtb.Text.Trim();

            var updateForm = new Update_Radiology_Record();
            updateForm.LoadRadiologyData(_ID, nid, type, report, imageUrl);
            updateForm.ShowDialog();

            _ = LoadRadiologyData(nid); // Refresh data after update
        }

        // Navigates to the update password page
        private void UPDATEPASSWORDbtn_Click(object sender, EventArgs e)
        {
            _startPage.loadform(new UpdatePassword_Page(_startPage));
            _startPage.resetButtons();
        }

        // Navigates to the admin dashboard
        private void ADMINDASHBOARDbtn_Click(object sender, EventArgs e)
        {
            _startPage.loadform(new AdminDashboard(_startPage));
            _startPage.resetButtons();
        }

        // Navigates to the home dashboard
        private void Homebtn_Click(object sender, EventArgs e)
        {
            _startPage.loadform(new Dashboard_Page(_startPage));
            _startPage.resetButtons();
        }

        /// <summary>
        /// Clears all citizen information fields on the form.
        /// </summary>
        private void ClearCitizenFields()
        {
            FULLNAMEtb.Clear();
            ADDRESStb.Clear();
            BLOODtb.Text = string.Empty;
            BIRTHDATEtb.Text = null;
            TABLEdgv.Rows.Clear();
        }

        private void TABLEdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // If clicked cell is in the "ViewImage" button column
            if (TABLEdgv.Columns[e.ColumnIndex].Name == "ViewImage" && e.RowIndex >= 0)
            {
                string imageUrl = TABLEdgv.Rows[e.RowIndex].Cells["SecureUrl"].Value?.ToString();

                if (!string.IsNullOrEmpty(imageUrl))
                {
                    Logger.LogInfo($"{SessionManager.Email}: Viewieng Radiology image for NationalID {NIDtb.Text}, _id = {TABLEdgv.Rows[e.RowIndex].Cells["SecureUrl"].Value?.ToString()}");
                    ImageViewerForm imageForm = new ImageViewerForm(imageUrl);
                    imageForm.ShowDialog(); // Open as popup window
                }
            }
        }
    }
}
