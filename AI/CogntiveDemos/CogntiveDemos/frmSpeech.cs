using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CogntiveDemos
{
    public partial class frmSpeech : Form
    {
        //static string host = "https://api.cognitive.microsofttranslator.com";
        static string path = string.Empty; //"/translate?api-version=3.0";
        static string params_ = string.Empty; //"&to=de&to=it";

        static string uri = string.Empty;// host + path + params_;

        // NOTE: Replace this example key with a valid subscription key.
        static string key = "";

        static string text = "Hello world!";
        static string output = string.Empty;
        public frmSpeech()
        {
            InitializeComponent();
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            //HttpWebRequest request = null;
            //request = (HttpWebRequest)HttpWebRequest.Create(requestUri);
            //request.SendChunked = true;
            //request.Accept = @"application/json;text/xml";
            //request.Method = "POST";
            //request.ProtocolVersion = HttpVersion.Version11;
            //request.ContentType = @"audio/wav; codec=audio/pcm; samplerate=16000";
            //request.Headers["Ocp-Apim-Subscription-Key"] = "YOUR_SUBSCRIPTION_KEY";

            //// Send an audio file by 1024 byte chunks
            //using (FileStream fs = new FileStream(YOUR_AUDIO_FILE, FileMode.Open, FileAccess.Read))
            //{

            //    /*
            //    * Open a request stream and write 1024 byte chunks in the stream one at a time.
            //    */
            //    byte[] buffer = null;
            //    int bytesRead = 0;
            //    using (Stream requestStream = request.GetRequestStream())
            //    {
            //        /*
            //        * Read 1024 raw bytes from the input audio file.
            //        */
            //        buffer = new Byte[checked((uint)Math.Min(1024, (int)fs.Length))];
            //        while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) != 0)
            //        {
            //            requestStream.Write(buffer, 0, bytesRead);
            //        }

            //        // Flush
            //        requestStream.Flush();
            //  }
            //}
        }
    }
}
