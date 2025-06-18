using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final_Project_SHA_V1._2.Core.Interfaces;
using Final_Project_SHA_V1._2.Core.Models;
using Final_Project_SHA_V1._2.Forms;
using Final_Project_SHA_V1._2.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Final_Project_SHA_V1._2.Pages
{
    public partial class Export_Page : Form
    {

        private readonly IExportService _exportService;
        private readonly ICitizenService _citizenService;


        private string DIAGNOSIS;
        private string TREATMENT;
        private string SECUREURL;
        private readonly string URL = "https://medical-website-production-1dc4.up.railway.app";

        private FrmMain _startPage;


        public Export_Page(FrmMain startPage)
        {
            InitializeComponent();
            _startPage = startPage;

            // Create service instance
            _exportService = new ExportService();
            _citizenService = new CitizenService();

        }

        private async void EXPORTbtn_Click(object sender, EventArgs e)
        {
            string nationalId = NIDtb.Text.Trim();

            if (string.IsNullOrWhiteSpace(nationalId))
            {
                MessageBox.Show("Please enter a valid National ID.");
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON files (*.json)|*.json";
                saveFileDialog.FileName = $"{nationalId}_MedicalExport.json";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    bool success = await _exportService.ExportDataToJsonFileAsync(nationalId, filePath);

                    if (success)
                        MessageBox.Show("Export successful!");
                    else
                        MessageBox.Show("Failed to export data.");
                }
            }
            /*string nid = NIDtb.Text.Trim();
            if (nid.Length != 14)
            {
                MessageBox.Show("Invalid NID. Please ensure it's 14 digits.");
                return;
            }

            try
            {
                // Fetch citizen data
                CitizenRecordResponse citizenData = await _citizenController.GetCitizenByNationalIdAsync(nid);
                var citizen = citizenData?.Citizen;
                if (citizen == null)
                {
                    MessageBox.Show("No citizen data found.");
                    return;
                }

                // Generate exportable JSON string
                string jsonData = await _exportController.ExportDataAsync(nid, citizen);

                // Prompt user to save file
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                    saveFileDialog.Title = "Save Exported Data";
                    saveFileDialog.FileName = $"{nid}.json";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, jsonData);
                        MessageBox.Show("Data exported to " + saveFileDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export error: " + ex.Message);
            }*/
        }

        private async Task FetchMedicalAndRadiologyDataAsync(string nid)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string combinedApiUrl = $"{URL}/user/dashboard?national_ID={nid}";
                    if (!string.IsNullOrEmpty(SessionManager.AuthToken))
                    {
                        client.DefaultRequestHeaders.Authorization =
                            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SessionManager.AuthToken);
                    }
                    else
                    {
                        MessageBox.Show("No token found. Please login again.");
                        return;
                    }

                    HttpResponseMessage response = await client.GetAsync(combinedApiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        dynamic parsedJson = JsonConvert.DeserializeObject(json);

                        var resultArray = parsedJson.data.result;

                        // Collect all diagnoses and treatments
                        List<string> diagnoses = new List<string>();
                        List<string> treatments = new List<string>();

                        if (resultArray.Count >= 2 && resultArray[1].status == "fulfilled")
                        {
                            var medicalValues = resultArray[1].value;
                            foreach (var record in medicalValues)
                            {
                                string diagnosis = record.diagnosis ?? "";
                                string treatment = record.treatment ?? "";

                                if (!string.IsNullOrWhiteSpace(diagnosis)) diagnoses.Add((string)diagnosis);
                                if (!string.IsNullOrWhiteSpace(treatment)) treatments.Add((string)treatment);
                            }
                        }

                        DIAGNOSIS = diagnoses.Count > 0 ? string.Join(", ", diagnoses) : "N/A";
                        TREATMENT = treatments.Count > 0 ? string.Join(", ", treatments) : "N/A";

                        // Get first available radiology secure_url
                        if (resultArray.Count >= 3 && resultArray[2].status == "fulfilled")
                        {
                            var radiologyValues = resultArray[2].value;
                            foreach (var record in radiologyValues)
                            {
                                var images = record.images;
                                if (images != null && images.Count > 0)
                                {
                                    SECUREURL = images[0].secure_url ?? "N/A";
                                    break;
                                }
                            }

                            if (string.IsNullOrEmpty(SECUREURL))
                            {
                                SECUREURL = "N/A";
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error fetching medical and radiology data.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        public class MedicalRadiologyResponse
        {
            public string Diagnosis { get; set; }
            public string Treatment { get; set; }
            public string SecureUrl { get; set; }
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
            BIRTHDATEtb.Clear();
        }
    }
}
