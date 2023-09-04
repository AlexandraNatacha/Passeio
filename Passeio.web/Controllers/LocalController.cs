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
            passeioApi = "http://passeio.api:8080";
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

        [HttpGet]
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

            _toastNotification.AddErrorToastMessage(response.Content);
            return View(localViewModel);
        }

        public IActionResult Editar(Guid localId)
        {
            var client = new RestClient(passeioApi);
            var rest = $"api/local/buscarParaEdicao/{localId}";
            var request = new RestRequest(rest);
            var response = client.Execute(request);
            if(response.IsSuccessful)
            {
                var editarViewModel = JsonConvert.DeserializeObject<EditarViewModel>(response.Content!);
                return View(editarViewModel);
            }

            return View(nameof(Index));
        }


        [HttpPost]
        public IActionResult Editar(EditarViewModel editarViewModel)
        {
            var editarLocalDto = new EditarLocalDto
            {
                Id = editarViewModel.Id,
                Titulo = editarViewModel.Titulo,
                Descricao = editarViewModel.Descricao,
                Localizacao = editarViewModel.Localizacao,
                Imagem = editarViewModel.Imagem,
            };

            var client = new RestClient(passeioApi);
            var rest = $"api/local/editar";
            var request = new RestRequest(rest, Method.Put);
            request.AddBody(editarLocalDto);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                _toastNotification.AddSuccessToastMessage("Suas alterações foram salvas com sucesso!");
                return RedirectToAction(nameof(Index));
            }

            _toastNotification.AddErrorToastMessage(response.Content);
            return View(editarViewModel);
        }

        public IActionResult Deletar(Guid localId)
        {
            var client = new RestClient(passeioApi);
            var rest = $"api/local/deletar/{localId}";
            var request = new RestRequest(rest, Method.Patch);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                _toastNotification.AddSuccessToastMessage("Local excluído!");
                return RedirectToAction(nameof(Index));
            }

            _toastNotification.AddErrorToastMessage(response.Content);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(Guid localId)
        {
            var client = new RestClient(passeioApi);
            var rest = $"api/local/buscar/{localId}";
            var request = new RestRequest(rest);
            request.AddBody(localId);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var detalhesViewModel = JsonConvert.DeserializeObject<DetalhesViewModel>(response.Content!);
                return View(detalhesViewModel);
            }
            _toastNotification.AddErrorToastMessage(response.Content);
            return RedirectToAction(nameof(Index));
        }
    }
}
