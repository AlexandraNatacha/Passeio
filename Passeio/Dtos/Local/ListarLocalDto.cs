using Passeio.Api.Enums;

namespace Passeio.Api.Dtos.Local
{
    public class ListarLocalDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public string UsuarioCriador { get; set; }
        public StatusDoLocal Status { get; set; }
        public string Imagem { get; set; }
    }
}
