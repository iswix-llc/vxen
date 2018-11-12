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
        public async Task<string> SendToApi<T>(Uri apiURL, T data)
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
