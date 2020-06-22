using SimpleBackgroundTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleBackgroundTask.Services
{
    public class SendMessage : ISendMessage
    {
        private readonly IHttpClientFactory _httpClient;
        public SendMessage(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public void Send(string url, string name, string descr)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(JsonSerializer.Serialize(
                new Message { Name = name, Description = descr }));
            request.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            var client = _httpClient.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //var response = await client.SendAsync(request);
            client.SendAsync(request);
        }
    }
}
