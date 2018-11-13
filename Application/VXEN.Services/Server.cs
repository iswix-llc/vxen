using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VXEN.Models.Transaction;

namespace VXEN.Services
{
    public class Server
    {
        public string SendToApiSync<T>(Uri apiURL, T data)
        {
            return SendToAPISync(apiURL, Serialization.Serialize(data));
        }

        public string SendToAPISync(Uri apiURL, string data)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            string response = string.Empty;

            using( var webClient = new WebClient())
            {
                webClient.Headers.Add("Content-Type", "text/xml; charset=utf-8");
                byte[] bytes = Encoding.UTF8.GetBytes(data);
                var result = webClient.UploadData(apiURL.AbsoluteUri, bytes);
                response = System.Text.Encoding.Default.GetString(result);
            }
            return response;
        }

        public async Task<string> SendToApiASync<T>(Uri apiURL, T data)
        {
            return await SendToAPI(apiURL, Serialization.Serialize(data));
        }

        public async Task<string> SendToAPI(Uri apiURL, string data)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, apiURL);
                request.Content = new StringContent(data, Encoding.UTF8, "text/xml");
                var response = await httpClient.SendAsync(request);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
