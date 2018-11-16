using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VXEN.Services
{
    public static class Server
    {
        public static string SendToApi<T>(T data)
        {
            return SendToAPI(Serialization.Serialize(data));
        }
        public static string SendToAPI(string data)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            string response = string.Empty;

            using( var webClient = new WebClient())
            {
                webClient.Headers.Add("Content-Type", "text/xml; charset=utf-8");
                byte[] bytes = Encoding.UTF8.GetBytes(data);
                var result = webClient.UploadData(Session.Instance.GetUri().AbsoluteUri, bytes);
                response = System.Text.Encoding.Default.GetString(result);
            }
            return response;
        }
        public static async Task<string> SendToAPIAsync<T>(T data)
        {
            return await SendToAPIASync(Serialization.Serialize(data));
        }
        public static async Task<string> SendToAPIASync(string data)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, Session.Instance.GetUri());
                request.Content = new StringContent(data, Encoding.UTF8, "text/xml");
                var response = await httpClient.SendAsync(request);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
