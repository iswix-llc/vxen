using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VXEN.Services
{
    public static class Server
    {
        public static string SendToApi<T>(T data, int timeout)
        {
            return SendToAPI(Serialization.Serialize(data), timeout);
        }

        public static string SendToApi<T>(T data)
        {
            return SendToAPI(Serialization.Serialize(data), 65000);
        }

        public static string SendToAPI(XDocument document)
        {
            return SendToAPI(document, 65000);
        }

        public static string SendToAPI(XDocument document, int timeout)
        {
            // Temporarily disabled to allow customer to proceed with certification. 
            SafetyCheck(document);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            string response = string.Empty;

            using (var webClient = new CustomWebClient())
            {
                webClient.Timeout = timeout;
                webClient.Headers.Add("Content-Type", "text/xml; charset=utf-8");
                byte[] bytes = Encoding.UTF8.GetBytes(document.ToString());
                var result = webClient.UploadData(GetUrl(document), bytes);

                response = System.Text.Encoding.Default.GetString(result);
            }
            return response;
        }

        public static async Task<string> SendToAPIAsync<T>(T data)
        {
            return await SendToAPIASync(Serialization.Serialize(data), 65000);
        }

        public static async Task<string> SendToAPIAsync<T>(T data, int milliseconds)
        {
            return await SendToAPIASync(Serialization.Serialize(data), milliseconds);
        }
        public static async Task<string> SendToAPIASync(XDocument document, int milliseconds)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = new TimeSpan(0,0,0,0, milliseconds);
                var request = new HttpRequestMessage(HttpMethod.Post, GetUrl(document));
                request.Content = new StringContent(document.ToString(), Encoding.UTF8, "text/xml");
                // Temporarily disabled to allow customer to proceed with certification. 
                //SafetyCheck(document);
                var response = await httpClient.SendAsync(request);
                return await response.Content.ReadAsStringAsync();
            }
        }

        private static string GetUrl(XDocument document)
        {
            string rootNamespace = document.Root.GetDefaultNamespace().ToString();
            string url = string.Empty;
            if (Session.Instance.APILifeCycle == APILifeCycle.Production)
            {
                url = rootNamespace;
            }
            else
            {
                url = rootNamespace.Replace("https://", "https://cert");
            }
            return url;
        }

        private static void SafetyCheck(XDocument document)
        {
            // Temporarily disabled.  We need to decide if we seed this with all known test credit card numbers or we ditch the feature.
            if (Session.Instance.APILifeCycle == APILifeCycle.Certification)
            {
                string testCreditCardPrefix = "549999012345";
                string testCreditCardSuffix = "6781";
                string creditCardNumber = string.Empty;

                try
                {
                    var elements = from e in document.Descendants()
                                   where e.Name.LocalName == "CardNumber"
                                   select e;
                     creditCardNumber = elements.First().Value;
                }
                catch (Exception)
                {
                }

                if (!string.IsNullOrEmpty(creditCardNumber) && !creditCardNumber.Equals(testCreditCardPrefix + testCreditCardSuffix))
                {
                    throw new SecurityException("You may only send the test credit card number to the certification null processor.");
                }
            }
        }
    }
}
