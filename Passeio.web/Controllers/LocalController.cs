using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Passeio.web.Models.ViewModels;
using RestSharp;
using static System.Net.WebRequestMethods;

namespace Passeio.web.Controllers
{
    public class LocalController : Controller
    {
        private readonly string passeioApi;

        public LocalController()
        {
            passeioApi = "https://localhost:7058";
        }
        public IActionResult Index()
        {
            var client = new RestClient(passeioApi);
            var rest = $"api/local/listar";
            var request = new RestRequest(rest, Method.Get);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var localViewModel = JsonConvert.DeserializeObject<List<LocalViewModel>>(response.Content!);
                return View(localViewModel);
            }

            return null;
        }
    }
}
