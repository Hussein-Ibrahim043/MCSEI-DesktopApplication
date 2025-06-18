using System;
using System.Windows.Forms;
using Final_Project_SHA_V1._2.Core.Interfaces;
using Final_Project_SHA_V1._2.Forms;
using Final_Project_SHA_V1._2.Services;

namespace Final_Project_SHA_V1._2.Pages
{
    public partial class Citizens_Page : Form
    {
        private FrmMain _startPage;
        private readonly ICitizenService _citizenService;

        public Citizens_Page(FrmMain startPage)
        {
            InitializeComponent();
            _startPage = startPage;

            
            // Create service instance
            _citizenService = new CitizenService();
        }

        private async void SAVEbtn_Click(object sender, EventArgs e)
        {
            string nationalID = NIDtb.Text;
            string fullName = FULLNAMEtb.Text;
            string address = ADDRESStb.Text;
            string bloodType = BLOODlb.Text;
            string birthDate = BIRTHDATEdp.Value.ToString("yyyy-MM-dd");
            string mobileNumber = EMERGENCYCOTACTtb.Text.Trim();

            

            try
            {
                // Input Validation
                if (string.IsNullOrWhiteSpace(nationalID) || nationalID.Length != 14)
                {
                    MessageBox.Show("Please enter a valid 14-digit National ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(fullName))
                {
                    MessageBox.Show("Full name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(address))
                {
                    MessageBox.Show("Address is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(bloodType))
                {
                    MessageBox.Show("Please select a blood type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(mobileNumber) || mobileNumber.Length < 10)
                {
                    MessageBox.Show("Please enter a valid mobile number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Call the service
                bool isCreated = await _citizenService.CreateCitizenRecordAsync(
                    nationalID, fullName, address, bloodType, birthDate, mobileNumber);

                if (isCreated)
                {
                    MessageBox.Show("Citizen record created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NIDtb.Clear();
                    FULLNAMEtb.Clear();
                    ADDRESStb.Clear();
                    BLOODlb.Text = "";
                    EMERGENCYCOTACTtb.Clear();
                }
                else
                {
                    MessageBox.Show("Failed to create citizen record. Please check inputs or try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Failed to create citizen record.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show($"An error occurred while creating the citizen record.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void UPDATEbtn_Click(object sender, EventArgs e)
        {
            string nationalID = NIDtb.Text;
            string fullName = FULLNAMEtb.Text;
            string address = ADDRESStb.Text;
            string bloodType = BLOODlb.Text;            
            string birthDate = BIRTHDATEdp.Value.ToString("yyyy-MM-dd");
            string mobileNumber = EMERGENCYCOTACTtb.Text.Trim();




            try
            {
                // Input Validation
                if (string.IsNullOrWhiteSpace(nationalID) || nationalID.Length != 14)
                {
                    MessageBox.Show("Please enter a valid 14-digit National ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(fullName))
                {
                    MessageBox.Show("Full name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(address))
                {
                    MessageBox.Show("Address is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(bloodType))
                {
                    MessageBox.Show("Please select a blood type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(mobileNumber) || mobileNumber.Length < 10)
                {
                    MessageBox.Show("Please enter a valid mobile number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                // Call the service to update citizen
                bool isUpdated = await _citizenService.UpdateCitizenAsync(nationalID, fullName, address, bloodType, birthDate, mobileNumber);

                if (isUpdated)
                {
                    MessageBox.Show("Citizen record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update citizen record. Please check the data or try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Failed to update citizen record.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show($"An error occurred while updating the citizen record.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                if (citizenResponse?.Citizen != null)
                {
                    var citizen = citizenResponse.Citizen;

                    FULLNAMEtb.Text = citizen.FullName ?? "N/A";
                    ADDRESStb.Text = citizen.Address ?? "N/A";
                    BLOODlb.Text = citizen.BloodType ?? "N/A";
                    BIRTHDATEdp.Text = citizen.BirthDate.ToString("yyyy-MM-dd");                    
                    EMERGENCYCOTACTtb.Text = citizen.MobileNumber ?? "N/A";
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

        private async void DELETEbtn_Click(object sender, EventArgs e)
        {
            string nationalId = NIDtb.Text.Trim();

            if (string.IsNullOrWhiteSpace(nationalId))
            {
                MessageBox.Show("Please enter the National ID to delete.");
                return;
            }

            DialogResult confirmResult = MessageBox.Show(
                "Are you sure you want to delete this citizen?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                // Input validation
                if (string.IsNullOrWhiteSpace(nationalId) || nationalId.Length != 14)
                {
                    MessageBox.Show("Please enter a valid 14-digit National ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirm deletion
                DialogResult confirm = MessageBox.Show(
                    $"Are you sure you want to delete the citizen with ID: {nationalId}?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm != DialogResult.Yes)
                    return;

                // Call service
                bool isDeleted = await _citizenService.DeleteCitizenAsync(nationalId);

                if (isDeleted)
                {
                    MessageBox.Show("Citizen record deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear all fields
                    NIDtb.Clear();
                    FULLNAMEtb.Clear();
                    ADDRESStb.Clear();
                    BLOODlb.Text = string.Empty;
                    BIRTHDATEdp.Value = DateTime.Today;
                    EMERGENCYCOTACTtb.Clear();
                }
                else
                {
                    MessageBox.Show("Failed to delete the citizen record. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while attempting to delete the record.\n{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            BLOODlb.Text = string.Empty;
            BIRTHDATEdp.Value = DateTime.Today;
            EMERGENCYCOTACTtb.Clear();
        }
    }
}
