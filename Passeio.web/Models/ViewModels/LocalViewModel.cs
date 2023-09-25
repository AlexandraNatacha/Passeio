using Passeio.web.Enums;

namespace Passeio.web.Models.ViewModels
{
    public class LocalViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public string UsuarioCriador { get; set; }
        public string Imagem { get; set; }
    }
}
