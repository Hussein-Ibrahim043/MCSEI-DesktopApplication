using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final_Project_SHA_V1._2.Forms;
using Newtonsoft.Json;
using static Final_Project_SHA_V1._2.Pages.Radiology_Page;
using Final_Project_SHA_V1._2.Services;
using System.Security.Cryptography;
using Final_Project_SHA_V1._2.Core.Models;
using Final_Project_SHA_V1._2.Core.Interfaces;

namespace Final_Project_SHA_V1._2.Pages
{
    
    public partial class Medical_Page : Form
    {
        private FrmMain _startPage;
        public static String URL = "https://medical-website-production-1dc4.up.railway.app";
        string _ID = null;

        private readonly IMedicalService _medicalservice;
        private readonly ICitizenService _citizenService;

        public Medical_Page(FrmMain startPage)
        {
            InitializeComponent();
            _startPage = startPage;

            //private readonly MedicalController _medicalController;
            // Create service instance
            var medicalSevicer = new MedicalService(); // Only if it has a parameterless constructor
            _medicalservice = new MedicalService();

            // Create service instance
            _citizenService = new CitizenService();
        }

        private void CREATERECORDbtn_Click(object sender, EventArgs e)
        {
            Create_Medical_Record createMedical = new Create_Medical_Record();
            createMedical.LoadNID(NIDtb.Text);
            createMedical.Show();

            //Refresh table after create new record
            string nationalId = NIDtb.Text.Trim();
            _ = LoadMedicalData(nationalId);
        }

        private async void NIDtb_TextChanged(object sender, EventArgs e)
        {
            string nid = NIDtb.Text.Trim();

            // Validate length before making API call
            if (nid.Length != 14)
            {
                ClearCitizenFields();
                return;
            }

            try
            {
                var citizenResponse = await _citizenService.GetCitizenByNationalIdAsync(nid);
                LoadMedicalData(nid);

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

        public async Task LoadMedicalData(string nationalId)
        {
            try
            {                
                var response = await _medicalservice.GetMedicalRecordsAsync(nationalId);

                if (response?.Data?.MedicalRecords != null && response.Data.MedicalRecords.Count > 0)
                {
                    TABLEdgv.Rows.Clear();

                    foreach (var record in response.Data.MedicalRecords)
                    {
                        int rowIndex = TABLEdgv.Rows.Add(
                            record._id,
                            record.ClinicName,
                            record.ClinicCode,
                            record.Diagnosis,
                            record.Treatment,
                            record.RecodeDate.ToString("yyyy-MM-dd"),
                            record.Status
                        );

                        // Store record ID in the Tag property of the row
                        //TABLEdgv.Rows[rowIndex].Tag = record.Id;
                    }
                }
                else
                {
                    TABLEdgv.Rows.Clear();
                    MessageBox.Show("No medical records found for the provided National ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error loading medical records:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void UPDATERECORDbtn_Click(object sender, EventArgs e)
        {            

            if (TABLEdgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a medical record to update.");
                return;
            }

            var selectedRow = TABLEdgv.SelectedRows[0];

            string _id = selectedRow.Cells[0].Value?.ToString();
            string nationalId = NIDtb.Text.Trim();
            string clinicName = selectedRow.Cells[1].Value?.ToString();
            string CLinicCode = selectedRow.Cells[2].Value?.ToString();
            string diagnosis = selectedRow.Cells[3].Value?.ToString();
            string treatment = selectedRow.Cells[4].Value?.ToString();
            bool status = bool.TryParse(selectedRow.Cells[4].Value?.ToString(), out bool stat) ? stat : false;

            var updateForm = new Update_Medical_Record();
            updateForm.LoadMedicalData(_id,nationalId, clinicName, CLinicCode, diagnosis, treatment, status);
            updateForm.ShowDialog();

            // Refresh table after update
            _ = LoadMedicalData(nationalId);
        }

        private async void DELETERECORDbtn_Click(object sender, EventArgs e)
        {
            string nationalId = NIDtb.Text.Trim();

            if (TABLEdgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a medical record to delete.");
                return;
            }

            var selectedRow = TABLEdgv.SelectedRows[0];
            _ID = selectedRow.Cells[0].Value?.ToString();

            if (string.IsNullOrWhiteSpace(nationalId))
            {
                MessageBox.Show("Please enter the National ID to delete.");
                return;
            }

            DialogResult confirmResult = MessageBox.Show(
                "Are you sure you want to delete this medical record?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                bool response = await _medicalservice.DeleteMedicalRecordAsync(nationalId, _ID);
                if (response)
                {
                    MessageBox.Show("Medical record delete successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Refresh table after update
                    _ = LoadMedicalData(nationalId);
                }
                else
                {
                    MessageBox.Show("Failed to delete medical record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {                
                MessageBox.Show("Failed to delete medical record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        /// <summary>
        /// Clears the citizen input fields on the form.
        /// </summary>
        private void ClearCitizenFields()
        {
            FULLNAMEtb.Clear();
            ADDRESStb.Clear();
            BLOODtb.Text = string.Empty;
            BIRTHDATEtb.Text = null;
            TABLEdgv.Rows.Clear();
        }
    }
}
