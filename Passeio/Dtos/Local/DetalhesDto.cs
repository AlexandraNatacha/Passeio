namespace Passeio.web.Dtos.Local
{
    public class DetalhesDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public string UsuarioCriador { get; set; }
        public Byte Imagem { get; set; }
    }
}
