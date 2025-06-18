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
using Final_Project_SHA_V1._2.Forms;
using Final_Project_SHA_V1._2.Infrastructure.Utils;
using Final_Project_SHA_V1._2.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Final_Project_SHA_V1._2.Pages
{
    public partial class Update_Medical_Record : Form
    {
        String _ID = null;
        String NID = null;
        String ClinicName = null;
        int clinicCode;
        String Diagnosis = null;
        String Treatment = null;
        bool Status ;

        private readonly IMedicalService _medicalservice;

        public Update_Medical_Record()
        {
            InitializeComponent();

            // Create service instance
            _medicalservice = new MedicalService();
        }
        public void LoadMedicalData(string _id, string nid, string clinicName, string ClinicCode, string diagnosis, string treatment, bool status)
        {
            _ID = _id;

            NIDtb.Text = nid;
            CLINICNAMEcb.Text = clinicName;
            CLINICCODEtb.Text = ClinicCode;
            DIAGNOSIStb.Text = diagnosis;
            TREATMENTtb.Text = treatment;
            STATUScb.Checked = status;
        }

        private async void UPDATEbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Extract and validate input
                string nationalId = NIDtb.Text.Trim();
                string clinicName = CLINICNAMEcb.Text.Trim();
                string clinicCodeText = CLINICCODEtb.Text.Trim();
                string diagnosis = DIAGNOSIStb.Text.Trim();
                string treatment = TREATMENTtb.Text.Trim();
                bool status = STATUScb.Checked;

                if (string.IsNullOrEmpty(_ID) || string.IsNullOrEmpty(nationalId))
                {
                    Logger.LogInfo("Missing _ID or National ID during update attempt.");
                    MessageBox.Show("Missing record ID or National ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(clinicCodeText, out int clinicCode))
                {
                    Logger.LogInfo("Invalid clinic code input: not a valid integer.");
                    MessageBox.Show("Clinic Code must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Construct the updated medical record
                var updatedRecord = new MedicalRequest
                {                    
                    NationalID = nationalId,
                    ClinicName = clinicName,
                    ClinicCode = clinicCode,
                    Diagnosis = diagnosis,
                    Treatment = treatment,
                    Status = status
                };

                Logger.LogInfo($"Attempting to update medical record: ID={_ID}, NationalID={nationalId}");

                // Attempt to update the record
                bool success = await _medicalservice.UpdateMedicalRecordAsync(updatedRecord,_ID);

                if (success)
                {
                    Logger.LogInfo($"Successfully updated medical record: ID={_ID}");
                    MessageBox.Show("Medical record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                    this.Close();
                }
                else
                {
                    Logger.LogInfo($"Failed to update medical record: ID={_ID}");
                    MessageBox.Show("Failed to update medical record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Exception occurred while updating medical record.", ex);
                MessageBox.Show($"An error occurred while updating the record:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CANCELbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
