using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Runtime.Serialization;

namespace CogntiveDemos
{
    public partial class frmTranslator : Form
    {
        static string host = "https://api.cognitive.microsofttranslator.com";
        static string path = string.Empty; //"/translate?api-version=3.0";
        // German and Italian.
        static string params_ = string.Empty; //"&to=de&to=it";

        static string uri = string.Empty;// host + path + params_;
        // NOTE: Replace this example key with a valid subscription key.
        static string key = "";

        static string text = "Hello world!";
        static string output = string.Empty;

        public frmTranslator()
        {
            InitializeComponent();
        }

        private async void btnTranslate_Click(object sender, EventArgs e)
        {
            text = txtInput.Text.ToString();
            try
            {
                path = "/translate?api-version=3.0";
                params_ = BuildParams();
                uri = host + path + params_;

                await CallCognitiveAPI("POST");
                txtOutput.Text = output;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private static async Task CallCognitiveAPI(string methodType)
        {
            System.Object[] body = new System.Object[] { new { Text = text } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                if (methodType == "POST")
                    request.Method = HttpMethod.Post;
                else
                    request.Method = HttpMethod.Get;
                request.RequestUri = new Uri(uri);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", key);
                var response = await client.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(responseBody),
                    Newtonsoft.Json.Formatting.Indented);
                output = result;
            }
        }

        private string BuildParams()
        {
            string paramsBuilt = string.Empty;
            CheckedListBox.CheckedItemCollection objects = chkListBoxLanguages.CheckedItems;
            foreach (object obj in objects)
            {
                paramsBuilt += "&to=" + obj.ToString();
            }
            return paramsBuilt;;
        }

        private static DataSet ReadDataFromJson(String jsonString)
        {
            var xd = new XmlDocument();

            //jsonString = "{ \"rootNode\": {" + jsonString.Trim().TrimStart('{').TrimEnd('}') + @"} }";
            xd = JsonConvert.DeserializeXmlNode(jsonString);

            var result = new DataSet();
            result.ReadXml(new XmlNodeReader(xd));
            return result;
        }

        public static DataTable Tabulate(string json)
        {
            var jsonLinq = JObject.Parse(json);

            var srcArray = jsonLinq.Descendants().Where(d => d is JArray).First();
            var trgArray = new JArray();
            foreach (JObject row in srcArray.Children<JObject>())
            {
                var cleanRow = new JObject();
                foreach (JProperty column in row.Properties())
                {
                    if (column.Value is JValue)
                    {
                        cleanRow.Add(column.Name, column.Value);
                    }
                }

                trgArray.Add(cleanRow);
            }

            return JsonConvert.DeserializeObject<DataTable>(trgArray.ToString());
        }

        public static XmlDocument JsonToXml(string json)
        {
            XmlNode newNode = null;
            XmlNode appendToNode = null;
            XmlDocument returnXmlDoc = new XmlDocument();
            returnXmlDoc.LoadXml("<Document />");
            XmlNode rootNode = returnXmlDoc.SelectSingleNode("Document");
            appendToNode = rootNode;

            string[] arrElementData;
            string[] arrElements = json.Split('\r');
            foreach (string element in arrElements)
            {
                string processElement = element.Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();
                if ((processElement.IndexOf("}") > -1 || processElement.IndexOf("]") > -1) && appendToNode != rootNode)
                {
                    appendToNode = appendToNode.ParentNode;
                }
                else if (processElement.IndexOf("[") > -1)
                {
                    processElement = processElement.Replace(":", "").Replace("[", "").Replace("\"", "").Trim();
                    newNode = returnXmlDoc.CreateElement(processElement);
                    appendToNode.AppendChild(newNode);
                    appendToNode = newNode;
                }
                else if (processElement.IndexOf("{") > -1 && processElement.IndexOf(":") > -1)
                {
                    processElement = processElement.Replace(":", "").Replace("{", "").Replace("\"", "").Trim();
                    newNode = returnXmlDoc.CreateElement(processElement);
                    appendToNode.AppendChild(newNode);
                    appendToNode = newNode;
                }
                else
                {
                    if (processElement.IndexOf(":") > -1)
                    {
                        arrElementData = processElement.Replace(": \"", ":").Replace("\",", "").Replace("\"", "").Split(':');
                        newNode = returnXmlDoc.CreateElement(arrElementData[0]);
                        for (int i = 1; i < arrElementData.Length; i++)
                        {
                            newNode.InnerText += arrElementData[i];
                        }

                        appendToNode.AppendChild(newNode);
                    }
                }
            }

            return returnXmlDoc;
        }

        private void frmCognitiveDemos_Load(object sender, EventArgs e)
        {
            chkListBoxLanguages.Items.Add("de", true);
            chkListBoxLanguages.Items.Add("it", true);
            chkListBoxLanguages.Items.Add("fr", true);
            chkListBoxLanguages.Items.Add("hi", true);
            chkListBoxLanguages.Items.Add("en", true);
            //List<string> languages = new List<string>();
            //languages.Add("de");
            //languages.Add("it");
            //chkListBoxLanguages.Items.AddRange(languages.ToArray());
        }

        private async void btnLanguages_Click(object sender, EventArgs e)
        {
            try
            {
                path = "/languages?api-version=3.0&scope=translation";
                //params_ = BuildParams();
                uri = host + path;

                await GetLanguages();

                #region trials
                ////dgv1 = LoadGrid(output);

                ////DataTable dt = Tabulate(output);

                //string testJson = "{\"translation\": {\"af\": [{\"name\": \"Afrikaans\",\"nativeName\": \"Afrikaans\",\"dir\": \"ltr\"}]}}";
                ////"\"ar\": [{\"name\": \"Arabic\",\"nativeName\": \"العربية\",\"dir\": \"rtl\"}]}}";

                //string testJsonAsIs = "{\"translation\": {\"af\": {\"name\": \"Afrikaans\",\"nativeName\": \"Afrikaans\",\"dir\": \"ltr\"},\"ar\": {\"name\": \"Arabic\",\"nativeName\": \"العربية\",\"dir\": \"rtl\"}}}";

                //string testJson2 = "{\"Item\": [{\"Name\": \"Super Mario Bros\",\"Count\": \"14\"}]}";

                ////DataTable dt = (DataTable)JsonConvert.DeserializeObject(testJson2, (typeof(DataTable)));

                //var ds = JsonConvert.DeserializeObject<DataSet>(testJson2);
                //var table = ds.Tables[0];

                ////var table1 = JsonConvert.DeserializeAnonymousType(testJson, new { Makes = default(DataTable) }).Makes;
                //DataSet ds1 = JObject.Parse(testJson)["translation"].ToObject<DataSet>();

                //dynamic stuff = JObject.Parse(testJsonAsIs);
                //string translationText = stuff.translation.ToString();

                //JsonObject root = Windows.Data.Json.JsonValue.Parse(stuff).GetObject();

                //var table2 = JsonConvert.DeserializeAnonymousType(testJsonAsIs, new { Translation = default(DataTable) }).Translation;
                #endregion trials

                txtLanguages.Text = output;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private class Wrapper
        {
            [JsonProperty("translation")]
            private DataSet DataSet { get; set; }
        }

        private static DataGridView LoadGrid(string response)
        {
            DataGridView dgv0 = new DataGridView();
            dgv0.Rows.Clear();
            JArray fetch = JArray.Parse(response);
            if (fetch.Count() > 0)
            {
                for (int i = 0; dgv0.Rows.Count > i; i++)
                {
                    int n = dgv0.Rows.Add();
                    dgv0.Rows[n].Cells[0].Value = fetch[i]["JsonObjectName1"].ToString();
                }
            }

            return dgv0;
        }

        private static async Task GetLanguages()
        {
            System.Object[] body = new System.Object[] { new { Text = text } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri(uri);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", key);
                var response = await client.GetAsync(request.RequestUri);
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(responseBody),
                    Newtonsoft.Json.Formatting.Indented);
                output = result;
            }
        }

        private async void btnDetectLanguage_Click(object sender, EventArgs e)
        {
            text = txtInput.Text.ToString();
            try
            {
                path = "/detect?api-version=3.0";
                //params_ = BuildParams();
                uri = host + path;

                await CallCognitiveAPI("POST");

                txtOutput.Text = output;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
