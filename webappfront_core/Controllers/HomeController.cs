using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webappfront_core.Models;
using System.Threading.Tasks;
using System.Net.Http;

namespace webappfront_core.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            // client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("http://sfoneappdemo2.centralus.cloudapp.azure.com:8081/api/StatelessBackendService/");
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("500 Internal Server Error occurred");
            }

            var responseBody = response.Content.ReadAsStringAsync().Result;

            ViewBag.Number = responseBody;

            return View();

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
