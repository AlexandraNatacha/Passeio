using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Passeio.Api.Dtos.Local;
using Passeio.Contexto;
using Passeio.Dtos.Local;
using Passeio.Entidades;

namespace Passeio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalController : ControllerBase
    {
        private readonly PasseioContexto _contexto;
        public LocalController(PasseioContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            var locais = _contexto.Locais.ToList();
            if(!locais.Any())
                return NotFound(new {error = "Ainda não há locais cadastrados"});

            var locaisDto = new List<ListarLocalDto>();
            foreach(var local in locais)
            {
                locaisDto.Add(new ListarLocalDto
                {
                    Id = local.Id,
                    Titulo = local.Titulo,
                    Descricao = local.Descricao,
                    Localização = local.Localização,
                    Imagem = local.Imagem
                });
            }
            return Ok(locaisDto);
        }

        [HttpGet("buscar/{id}")]
        public IActionResult Buscar(Guid id)
        {
            var lugar = _contexto.Locais.SingleOrDefault(x => x.Id == id);
            if(lugar is null)
                return NotFound(new {erro = "Local não encontrado!" });

            return Ok(lugar);
        }

        [HttpPost("criar")]
        public IActionResult Criar([FromBody] CriarLocalDto localDto)
        {
            var localComLocalocalizacaoJaCadastrada = _contexto.Locais.Any(x => x.Localização.Equals(localDto.Localização));

            if (localComLocalocalizacaoJaCadastrada)
                return Unauthorized(new { error = "O local já está cadastrado!" });

            var local = new Local(localDto.Titulo, localDto.Descricao, localDto.Localização, localDto.Imagem, localDto.UsuarioCriador);

            _contexto.Add(local);
            _contexto.SaveChanges();

            return Ok();
        }

        [HttpPut("editar/{id}")]
        public IActionResult Editar(Guid id, [FromBody] EditarLocalDto editarDto)
        {
            var localParaEditar = _contexto.Locais.SingleOrDefault(x => x.Id == id);

            if(localParaEditar is null)
                return NotFound(new { error = "Local não encontrado!" });

            localParaEditar.Editar(editarDto.Titulo, editarDto.Descricao, editarDto.Localização, editarDto.Imagem);

            _contexto.SaveChanges();

            return Ok();
        }

        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(Guid id)
        {
            var localParaDeletar = _contexto.Locais.SingleOrDefault(x => x.Id == id);
            if( localParaDeletar is null)
                return NotFound(new {error = "Local não encontrado!"});

            _contexto.Remove(localParaDeletar);
            _contexto.SaveChanges();

            return Ok();
        }
    }
}
