using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final_Project_SHA_V1._2.Core.Interfaces;
using Final_Project_SHA_V1._2.Infrastructure.Utils;
using Final_Project_SHA_V1._2.Services;

namespace Final_Project_SHA_V1._2.Pages
{
    public partial class Create_Radiology_Record : Form
    {
        // Stores the path of the selected image file
        private string selectedImagePath = null;
        
        private readonly IRadiologyService _radiologyService;
       
        public Create_Radiology_Record()
        {
            InitializeComponent();
            _radiologyService = new RadiologyService(); // Dependency setup
        }

        // Close the form .
        private void CANCELbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Load the passed National ID into the textbox
        public void LoadNID(string NID)
        {
            NIDtb.Text = NID;
        }

        // Open file dialog for the user to select an image
        private void SELECTFILEbtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.dicom";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;

                    // Display selected image in the picture box
                    SELECTED_PIC.Image = Image.FromFile(selectedImagePath);
                }
            }
        }

        // Handle the click event to save and upload the radiology record.
        private async void SAVEbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Get inputs
                string nationalId = NIDtb.Text.Trim();
                string radiologyType = RADIOLOGYTYPEcb.Text.Trim();
                string radiologyNotes = REPORTtb.Text.Trim();

                // Validation for national ID
                if (string.IsNullOrWhiteSpace(nationalId) || nationalId.Length != 14)
                {
                    Logger.LogInfo("Validation failed: Invalid or missing National ID for radiology creation.");
                    MessageBox.Show("Please enter a valid 14-digit National ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validation for radiology type
                if (string.IsNullOrWhiteSpace(radiologyType))
                {
                    Logger.LogInfo("Validation failed: Radiology type is required.");
                    MessageBox.Show("Please select a radiology type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validation for image file
                if (string.IsNullOrEmpty(selectedImagePath) || !File.Exists(selectedImagePath))
                {
                    Logger.LogInfo("Validation failed: Image file is not selected or does not exist.");
                    MessageBox.Show("Please select a valid image file to upload.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Log the record creation attempt
                Logger.LogInfo($"Attempting to create radiology record. NID: {nationalId}, Type: {radiologyType}");

                // Call the service to create the radiology record
                bool isCreated = await _radiologyService.CreateRadiologyRecordAsync(
                    nationalId,
                    radiologyType,
                    radiologyNotes,
                    selectedImagePath
                );

                // Handle response
                if (isCreated)
                {
                    Logger.LogInfo($"Successfully created radiology record for NID: {nationalId}");
                    MessageBox.Show("Radiology record created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset form fields
                    NIDtb.Text = string.Empty;
                    RADIOLOGYTYPEcb.Text = string.Empty;
                    REPORTtb.Text = string.Empty;
                    selectedImagePath = null;
                    SELECTED_PIC.Image = null;
                }
                else
                {
                    Logger.LogError($"Radiology record creation failed for NID: {nationalId}");
                    MessageBox.Show("Failed to create radiology record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Log and display any unexpected errors
                Logger.LogError("Exception occurred during radiology record creation.", ex);
                MessageBox.Show($"An error occurred while creating the radiology record:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}