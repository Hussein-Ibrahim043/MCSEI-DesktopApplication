using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final_Project_SHA_V1._2.Core.Interfaces;
using Final_Project_SHA_V1._2.Infrastructure.Utils;
using Final_Project_SHA_V1._2.Services;

namespace Final_Project_SHA_V1._2.Pages
{
    public partial class Update_Radiology_Record : Form
    {
        
        private readonly IRadiologyService _radiologyService;        
        public string selectedImagePath { get; set; }        
        string _ID = null;

        // Constructor initializes the form and service instance
        public Update_Radiology_Record()
        {
            InitializeComponent();
            _radiologyService = new RadiologyService();
        }

        /// <summary>
        /// Load existing radiology data into the form fields.
        /// </summary>
        public void LoadRadiologyData(string _id, string nid, string type, string report, string imageUrl)
        {
            _ID = _id;
            NIDtb.Text = nid;
            RADIOLOGYTYPEcb.Text = type;
            REPORTtb.Text = report;
            selectedImagePath = imageUrl;

            // Try to load image from URL into picture box
            try
            {
                if (!string.IsNullOrEmpty(imageUrl))
                    SELECTED_PIC.Load(imageUrl); // Load image from URL
            }
            catch
            {
                SELECTED_PIC.Image = null; 
            }
        }

        /// <summary>
        /// Validates input and updates the radiology record using the service.
        /// </summary>
        private async void UPDATEbtn_Click(object sender, EventArgs e)
        {
            // Extract and trim input values
            string nationalId = NIDtb.Text.Trim();
            string radiologyType = RADIOLOGYTYPEcb.Text.Trim();
            string radiologyNotes = REPORTtb.Text.Trim();

            // Validate National ID (must be 14 digits)
            if (string.IsNullOrWhiteSpace(nationalId) || nationalId.Length != 14)
            {
                MessageBox.Show("Please enter a valid 14-digit National ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.LogInfo("Invalid National ID input on radiology update.");
                return;
            }

            // Validate radiology type
            if (string.IsNullOrWhiteSpace(radiologyType))
            {
                MessageBox.Show("Radiology type is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.LogInfo("Missing radiology type input on radiology update.");
                return;
            }

            try
            {
                // Log update attempt
                Logger.LogInfo($"Attempting to update radiology record. ID: {_ID}, National ID: {nationalId}");

                // Call service method to update record
                bool isUpdated = await _radiologyService.UpdateRadiologyRecordAsync(
                    _ID,
                    nationalId,
                    radiologyType,
                    radiologyNotes,
                    selectedImagePath
                );

                // Handle result
                if (isUpdated)
                {
                    Logger.LogInfo($"Radiology record {_ID} updated successfully for National ID: {nationalId}");
                    MessageBox.Show("Radiology record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Close the form
                }
                else
                {
                    Logger.LogError($"Failed to update radiology record {_ID} for National ID: {nationalId}");
                    MessageBox.Show("Failed to update radiology record. Please verify the input data and try again.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Log and show error if exception occurs
                Logger.LogError($"Exception while updating radiology record {_ID} for National ID: {nationalId}", ex);
                MessageBox.Show($"❌ An error occurred while updating the record:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Close the form without saving changes.
        /// </summary>
        private void CANCELbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Allow the user to select a new image file from their system.
        /// Updates the image preview and the file path.
        /// </summary>
        private void SELECTFILEbtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.dicom";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Save new image path and preview it
                    selectedImagePath = openFileDialog.FileName;
                    SELECTED_PIC.Image = Image.FromFile(selectedImagePath);
                }
            }
        }
    }
}