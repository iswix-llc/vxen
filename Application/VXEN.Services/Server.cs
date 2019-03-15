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
                httpClient.Timeout = new TimeSpan(0, 0, 0, 0, milliseconds);
                var request = new HttpRequestMessage(HttpMethod.Post, GetUrl(document));
                request.Content = new StringContent(document.ToString(), Encoding.UTF8, "text/xml");
                // Temporarily disabled to allow customer to proceed with certification. 
                SafetyCheck(document);
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

        /// <summary>
        /// Throws an exception if you send a credit card number that is not on the certification whitelist to the certification provider.
        /// </summary>
        /// <param name="document"></param>
        private static void SafetyCheck(XDocument document)
        {
            if (Session.Instance.APILifeCycle == APILifeCycle.Certification)
            {
                List<string> certificationCreditCardNumbers = GetCertificationCreditcardNumbers();

                if (document.Descendants("CardNumber").Any())
                {
                    if (!certificationCreditCardNumbers.Contains(document.Descendants("CardNumber").First().Value))
                    {
                        throw new SecurityException("You may only send the test credit card number to the certification null processor.");
                    }
                }
            }
        }

        private static List<string> GetCertificationCreditcardNumbers()
        {
            //Obtained from https://developer.vantiv.com/docs/DOC-2624 on March, 15, 2019
            //This list may change over time.  Please contact us if you need an update.
            List<string> certificationCreditCardNumbers = new List<string>();
            //Vantiv Integrated Payments EMV and Magstripe test cards kits
            certificationCreditCardNumbers.Add("5413330089010681");
            certificationCreditCardNumbers.Add("6510000000000059");

            //Magstripe card profiles
            certificationCreditCardNumbers.Add("4895281000000006");
            certificationCreditCardNumbers.Add("5541032000004422");
            certificationCreditCardNumbers.Add("6011000990911111");
            certificationCreditCardNumbers.Add("341111597242000");  // This is missing a digit on their website???
            certificationCreditCardNumbers.Add("2223000048400011");

            //Two additional special use case test cards are included in your test kit that you may find helpful for MercuryPay:
            certificationCreditCardNumbers.Add("373953244361001");
            certificationCreditCardNumbers.Add("5439750001500222");

            // Obtained from https://developer.vantiv.com/docs/DOC-1065
            certificationCreditCardNumbers.Add("5499990123456781");
            return certificationCreditCardNumbers;
        }
    }
}
