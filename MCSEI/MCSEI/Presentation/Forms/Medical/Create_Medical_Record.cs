using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final_Project_SHA_V1._2.Core.Interfaces;
using Final_Project_SHA_V1._2.Core.Models;
using Final_Project_SHA_V1._2.Infrastructure.Utils;
using Final_Project_SHA_V1._2.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Final_Project_SHA_V1._2.Pages
{
    public partial class Create_Medical_Record : Form
    {
        private readonly IMedicalService _medicalService;

        public Create_Medical_Record()
        {
            InitializeComponent();

            
            // Create service instance
            var medicalSevicer = new MedicalService(); // Only if it has a parameterless constructor
            _medicalService = new MedicalService();
        }

        private void CANCELbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadNID( string NID)
        {
            
            NIDtb.Text = NID;                      
        }

        private async void SAVEbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Extract and trim inputs
                string nationalId = NIDtb.Text.Trim();
                string clinicName = CLINICNAMEcb.Text.Trim();
                string clinicCodeText = CLINICCODEtb.Text.Trim();
                string diagnosis = DIAGNOSIStb.Text.Trim();
                string treatment = TREATMENTtb.Text.Trim();                

                // Input validation
                if (string.IsNullOrWhiteSpace(nationalId) || nationalId.Length != 14)
                {
                    Logger.LogInfo("Validation failed: Invalid or missing National ID.");
                    MessageBox.Show("Please enter a valid 14-digit National ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(clinicName))
                {
                    Logger.LogInfo("Validation failed: Missing clinic name.");
                    MessageBox.Show("Please select a clinic name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(clinicCodeText, out int clinicCode))
                {
                    Logger.LogInfo("Validation failed: Invalid clinic code input.");
                    MessageBox.Show("Please enter a valid number for Clinic Code.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Logger.LogInfo($"Attempting to create medical record for National ID: {nationalId}");

                // Call the controller to create the medical record
                CreateMedicalRequest request = new CreateMedicalRequest
                {
                    NationalID =  nationalId,
                    Treatment = treatment,
                    Diagnosis = diagnosis,
                    ClinicName = clinicName,
                    ClinicCode = clinicCode,                    
                };
                bool isCreated = await _medicalService.CreateMedicalRecordAsync(request);

                if (isCreated)
                {
                    Logger.LogInfo($"Medical record successfully created for National ID: {nationalId}");
                    MessageBox.Show("Medical record created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear fields
                    //NIDtb.Text = string.Empty;
                    CLINICNAMEcb.Text = string.Empty;
                    CLINICCODEtb.Text = string.Empty;
                    DIAGNOSIStb.Text = string.Empty;
                    TREATMENTtb.Text = string.Empty;
                }
                else
                {
                    Logger.LogInfo($"Medical record creation failed for National ID: {nationalId}");
                    MessageBox.Show("Failed to create medical record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Exception occurred during medical record creation.", ex);
                MessageBox.Show($"An error occurred while creating the medical record:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
