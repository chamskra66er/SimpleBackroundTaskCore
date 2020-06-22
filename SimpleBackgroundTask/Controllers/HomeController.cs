using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleBackgroundTask.Models;

namespace SimpleBackgroundTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //public async Task SendMessage(string url, string name, string descr)
        //{
        //    var request = new HttpRequestMessage(HttpMethod.Post,
        //        url);
        //    request.Content = new StringContent(JsonSerializer.Serialize(
        //        new Message { Name = name, Description = descr}));
        //    request.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

        //    var client = _httpClient.CreateClient();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    var response = await client.SendAsync(request);
        //}
    }
}
