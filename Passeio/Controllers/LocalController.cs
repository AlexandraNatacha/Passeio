using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Passeio.Contexto;
using Passeio.Dtos.Local;
using Passeio.Entidades;

namespace Passeio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalController : ControllerBase
    {
        private readonly PasseioContexto _contetxo;
        public LocalController(PasseioContexto contexto)
        {
            _contetxo = contexto;
        }

        [HttpPost("criar")]
        public IActionResult Criar([FromBody] CriarLocalDto localDto)
        {
            var localComLocalocalizacaoJaCadastrada = _contetxo.Locais.Any(x => x.Localização.Equals(localDto.Localização));

            if (localComLocalocalizacaoJaCadastrada)
                return BadRequest(new { error = "O local já está cadastrado!" });

            var local = new Local(localDto.Titulo, localDto.Descricao, localDto.Localização, localDto.Imagem, localDto.UsuarioCriador);

            _contetxo.Add(local);
            _contetxo.SaveChanges();

            return Ok();
        }
    }
}
