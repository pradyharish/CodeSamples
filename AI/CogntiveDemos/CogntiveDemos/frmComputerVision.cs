using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CogntiveDemos
{
    public partial class frmComputerVision : Form
    {
        // update the subscriptionKey and the uriBase.
        const string subscriptionKey = "";
        const string uriBase =
            "https://eastus.api.cognitive.microsoft.com/vision/v1.0/analyze";
            //"https://westcentralus.api.cognitive.microsoft.com/vision/v2.0/analyze";
        static string output = string.Empty;
        //static string filePath = string.Empty;

        public frmComputerVision()
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
                        picBoxImg.ImageLocation = txtFile.Text;
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

        static async Task MakeAnalysisRequest(string imageFilePath)
        {
            try
            {
                HttpClient client = new HttpClient();

                // Request headers.
                client.DefaultRequestHeaders.Add(
                    "Ocp-Apim-Subscription-Key", subscriptionKey);

                // Request parameters. A third optional parameter is "details".
                string requestParameters =
                    "visualFeatures=Categories,Description,Color";

                // Assemble the URI for the REST API Call.
                string uri = uriBase + "?" + requestParameters;

                HttpResponseMessage response;

                // Request body. Posts a locally stored JPEG image.
                byte[] byteData = GetImageAsByteArray(imageFilePath);

                using (ByteArrayContent content = new ByteArrayContent(byteData))
                {
                    // This example uses content type "application/octet-stream".
                    // The other content types you can use are "application/json"
                    // and "multipart/form-data".
                    content.Headers.ContentType =
                        new MediaTypeHeaderValue("application/octet-stream");

                    response = await client.PostAsync(uri, content);
                }

                // Get the JSON response.
                string contentString = await response.Content.ReadAsStringAsync();

                output = JToken.Parse(contentString).ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
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

        private async void btnAnalyze_Click(object sender, EventArgs e)
        {
            try
            {
                picBoxImg.ImageLocation = txtFile.Text;
                await MakeAnalysisRequest(txtFile.Text);//.Wait();
                txtOutput.Text = output;

                string pattern = "\"text\": ";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(pattern))
                {
                    int first = output.IndexOf(pattern) + pattern.Length;
                    int last = output.LastIndexOf("\"confidence\"");
                    txtDescription.Text = output.Substring(first, last - first);
                    txtDescription.Text = txtDescription.Text.Replace("\"", "");
                    txtDescription.Text = txtDescription.Text.Replace(",", "");
                }
                else
                    txtDescription.Text = string.Empty;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
