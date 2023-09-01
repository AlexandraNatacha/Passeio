namespace Passeio.web.Dtos.Local
{
    public class EditarLocalDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public byte Imagem { get; set; }
    }
}
