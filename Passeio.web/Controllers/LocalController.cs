using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;
using Passeio.web.Dtos.Local;
using Passeio.web.Models.ViewModels;
using RestSharp;

namespace Passeio.web.Controllers
{
    public class LocalController : Controller
    {
        private readonly string passeioApi;
        private readonly IToastNotification _toastNotification;

        public LocalController(IToastNotification toastNotification)
        {
            passeioApi = "https://passeio.api:8080";
            _toastNotification = toastNotification;
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

            return View();
        }
        public IActionResult Criar() => View();

        [HttpPost]
        public IActionResult Criar(LocalViewModel localViewModel)
        {
            var criarLocalDto = new CriarLocalDto
            {
                Titulo = localViewModel.Titulo,
                Descricao = localViewModel.Descricao,
                Localizacao = localViewModel.Localizacao,
                UsuarioCriador = localViewModel.UsuarioCriador
            };
            var client = new RestClient(passeioApi);
            var rest = $"api/local/criar";
            var request = new RestRequest(rest, Method.Post);
            request.AddBody(criarLocalDto);
            var response = client.Execute(request);
            if(response.IsSuccessful)
            {
                _toastNotification.AddSuccessToastMessage("Local cadastrado com sucesso!");
                return RedirectToAction(nameof(Index));
            }

            _toastNotification.AddErrorToastMessage("Este local foi cadastrado!");
            return View(localViewModel);
        }
    }
}
