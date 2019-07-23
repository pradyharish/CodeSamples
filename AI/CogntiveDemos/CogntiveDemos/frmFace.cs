using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace CogntiveDemos
{
    public partial class frmFace : Form
    {
        // update the subscriptionKey and the uriBase.
        const string subscriptionKey = "";
        const string uriBase =
            "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize?";
        static string output = string.Empty;
        public frmFace()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                openFileDialog1.FilterIndex = 2;
                //openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(openFileDialog1.FileName))
                    {
                        //filePath = openFileDialog1.FileName;
                        txtFile.Text = openFileDialog1.FileName;
                        //MakeAnalysisRequest(openFileDialog1.FileName).Wait();
                    }
                    else
                    {
                        txtFile.Text = string.Empty;
                        MessageBox.Show("Invalid file path", "Prad says...Wrong!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        /// <summary>
        /// Returns the contents of the specified file as a byte array.
        /// </summary>
        /// <param name="imageFilePath">The image file to read.</param>
        /// <returns>The byte array of the image data.</returns>
        static byte[] GetImageAsByteArray(string imageFilePath)
        {
            using (FileStream fileStream =
                new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }

        static async Task MakeAnalysisRequest(string imageFilePath)
        {
            try
            {
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Add(
                    "Ocp-Apim-Subscription-Key", subscriptionKey);

                string requestParameters =
                    "visualFeatures=Categories,Description,Color";
                string uri = uriBase + "?" + requestParameters;

                HttpResponseMessage response;

                byte[] byteData = GetImageAsByteArray(imageFilePath);

                using (ByteArrayContent content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType =
                        new MediaTypeHeaderValue("application/octet-stream");

                    response = await client.PostAsync(uri, content);
                }

                string contentString = await response.Content.ReadAsStringAsync();

                output = JToken.Parse(contentString).ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async void btnAnalyze_Click(object sender, EventArgs e)
        {
            try
            {
                picBoxImg.ImageLocation = txtFile.Text;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            await MakeAnalysisRequest(txtFile.Text);//.Wait();
            txtOutput.Text = output;
        }
    }
}
