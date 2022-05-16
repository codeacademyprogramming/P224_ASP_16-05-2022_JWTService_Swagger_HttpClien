using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using P224ClientApp.DTOS;
using P224ClientApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace P224ClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            LoginDto loginDto = new LoginDto
            {
                UserName = "SuperAdmin",
                Password = "SuperAdmin123"
            };

            HttpResponseMessage login = null;
            string loginurl = "http://localhost:57925/api/auth/login";

            using (HttpClient httpClient = new HttpClient())
            {
                string content = JsonConvert.SerializeObject(loginDto);

                StringContent stringContent = new StringContent(content, Encoding.UTF8, "application/json");

                login = await httpClient.PostAsync(loginurl, stringContent);
            }

            if (login.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string token = await login.Content.ReadAsStringAsync();

                Response.Cookies.Append("AuthToken", token);
            }


            HttpResponseMessage httpResponseMessage = null;
            string url = "http://localhost:57925/api/categories";

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", Request.Cookies["AuthToken"]);

                httpResponseMessage = await httpClient.GetAsync(url);
            }

            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await httpResponseMessage.Content.ReadAsStringAsync();

                List<CategoryListDto> categoryListDtos = JsonConvert.DeserializeObject<List<CategoryListDto>>(content);

                return View(categoryListDtos);
            }

            //return NotFound();

            return RedirectToAction("index");
           
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int? id)
        {

            HttpResponseMessage httpResponseMessage = null;
            string url = "http://localhost:57925/api/categories/"+id;

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", Request.Cookies["AuthToken"]);

                httpResponseMessage = await httpClient.GetAsync(url);
            }

            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await httpResponseMessage.Content.ReadAsStringAsync();

                CategoryListDto categoryListDtos = JsonConvert.DeserializeObject<CategoryListDto>(content);

                return View(categoryListDtos);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(int? id, CategoryListDto categoryListDto)
        {
            HttpResponseMessage httpResponseMessage = null;
            string url = "http://localhost:57925/api/categories/" + id;

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", Request.Cookies["AuthToken"]);

                string content = JsonConvert.SerializeObject(categoryListDto);

                StringContent stringContent = new StringContent(content, Encoding.UTF8, "application/json");

                httpResponseMessage = await httpClient.PutAsync(url, stringContent);
            }

            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return RedirectToAction("GetCategories");
            }

            return NotFound();
        }

    }
}
