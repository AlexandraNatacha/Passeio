namespace Passeio.web.Dtos.Local
{
    public class CriarLocalDto
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public byte Imagem { get; set; }
        public string UsuarioCriador { get; set; }
    }
}
