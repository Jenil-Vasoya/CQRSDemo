using CQRSDemoFrontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace CQRSDemoFrontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiService _apiService;
        private readonly HttpClient client;
        public HomeController(ILogger<HomeController> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
            client = _apiService.Initial();
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

        [HttpPost]
        public IActionResult Index(User objLogin)
        {
            
            try
            {
                //var jsonContent = new StringContent(JsonConvert.SerializeObject(objLogin), Encoding.UTF8, "application/json");
                //HttpResponseMessage res = client.PostAsync("/User/user-login", jsonContent).Result;

                string apiUrl = "/User/user-login" + $"?email={objLogin.Email}&password={objLogin.Password}";
                //string queryString = ;
                HttpResponseMessage response = client.PostAsync(apiUrl,null).Result;
                 if(response.IsSuccessStatusCode)
                {
                    return View("Privacy");
                }
            }
            catch (Exception ex)
            {
                TempData["Fail"] = ex.Message;
                return View();
            }
            return View();

        }
    }
}