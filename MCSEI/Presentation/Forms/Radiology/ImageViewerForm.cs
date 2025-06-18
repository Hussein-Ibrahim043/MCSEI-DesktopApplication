using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCSEI.Presentation.Forms.Radiology
{
    public partial class ImageViewerForm : Form
    {
        public string selectedImagePath { get; set; }

        public ImageViewerForm(string imageUrl)
        {
            InitializeComponent();
            LoadImage(imageUrl);
            selectedImagePath = imageUrl;
        }        
        private void LoadImage(string url)
        {
            try
            {
                pictureBox.Load(url);                
                /* using (HttpClient client = new HttpClient())
                 {
                     byte[] imageBytes = await client.GetByteArrayAsync(url);
                     using (MemoryStream ms = new MemoryStream(imageBytes))
                     {
                         pictureBox1.Image = Image.FromStream(ms);
                     }
                 }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load image: " + ex.Message);
                this.Close();
            }
        }
    }
}
