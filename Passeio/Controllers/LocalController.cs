using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Passeio.Api.Dtos.Local;
using Passeio.Api.Enums;
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
            var locais = _contexto.Locais
                .Where(x => x.Status == StatusDoLocal.Ativo)
                .ToList();

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
                    Localizacao = local.Localizacao,
                    UsuarioCriador = local.UsuarioCriador,
                    Imagem = local.Imagem,
                    Status = local.Status
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
            var localJaCadastrado = _contexto.Locais.SingleOrDefault(x => x.Localizacao.Equals(localDto.Localizacao));

            if (localJaCadastrado is not null && localJaCadastrado!.Status != StatusDoLocal.Inativo)
            {
                return Unauthorized(new { error = "O local já está cadastrado!" });
            }

            var local = new Local(localDto.Titulo, localDto.Descricao, localDto.Localizacao, localDto.Imagem, localDto.UsuarioCriador);

            _contexto.Add(local);
            _contexto.SaveChanges();

            return Ok();
        }

        [HttpPut("editar/{localId}")]
        public IActionResult Editar(Guid localId, [FromBody] EditarLocalDto editarDto)
        {
            var localParaEditar = _contexto.Locais.SingleOrDefault(x => x.Id == localId);

            if(localParaEditar is null)
                return NotFound(new { error = "Local não encontrado!" });

            localParaEditar.Editar(editarDto.Titulo, editarDto.Descricao, editarDto.Localizacao, editarDto.Imagem);

            _contexto.SaveChanges();

            return Ok();
        }

        [HttpPatch("deletar/{localId}")]
        public IActionResult Deletar(Guid localId)
        {
            var local = _contexto.Locais.SingleOrDefault(x => x.Id == localId);
            if( local is null)
                return NotFound(new {error = "Local não encontrado!"});

            local.Inativar();

            _contexto.SaveChanges();

            return Ok();
        }
    }
}
