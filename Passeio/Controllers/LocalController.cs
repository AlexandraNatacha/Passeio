using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Passeio.Api.Dtos.Local;
using Passeio.Api.Enums;
using Passeio.Contexto;
using Passeio.Dtos.Local;
using Passeio.Entidades;
using Passeio.web.Dtos.Local;

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

        [HttpGet("buscar/{localId}")]
        public IActionResult Buscar(Guid localId)
        {
            var lugar = _contexto.Locais.SingleOrDefault(x => x.Id == localId);
            if(lugar is null)
                return NotFound(new {erro = "Local não encontrado!" });
            
            var datalhesDoLocal = new DetalhesDto
            {
                Id = localId,
                Titulo = lugar.Titulo,
                Descricao = lugar.Descricao,
                Localizacao = lugar.Localizacao,
                Imagem = lugar.Imagem,
                UsuarioCriador = lugar.UsuarioCriador
            };

            return Ok(datalhesDoLocal);
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

        [HttpGet("buscarParaEdicao/{localId}")]
        public IActionResult BuscarParaEdicao(Guid localId)
        {
            var local = _contexto.Locais.SingleOrDefault(x => x.Id == localId);
            if(local is null)
            {
                return NotFound(new { error = "Local não encontrado" });
            }

            var localParaEdicao = new EditarLocalDto
            {
                Id = localId,
                Titulo = local.Titulo,
                Descricao = local.Descricao,
                Localizacao = local.Localizacao,
                Imagem = local.Imagem
            };

            return Ok(localParaEdicao);
        }

        [HttpPut("editar")]
        public IActionResult Editar([FromBody] EditarLocalDto editarDto)
        {
            var localParaEditar = _contexto.Locais.SingleOrDefault(x => x.Id == editarDto.Id);

            if(editarDto is null)
                return NotFound(new { error = "Local não encontrado!" });

            localParaEditar!.Editar(editarDto.Titulo, editarDto.Descricao, editarDto.Localizacao, editarDto.Imagem);

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
