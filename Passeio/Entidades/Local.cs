namespace Passeio.Entidades
{
    public class Local
    {
        public Local(string titulo, string descricao, string localização, byte imagem, string usuarioCriador)
        {
            Titulo = titulo;
            Descricao = descricao;
            Localização = localização;
            Imagem = imagem;
            UsuarioCriador = usuarioCriador;
            Comentarios = new List<Comentario>();
            DataDeCriacao = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Localização { get; private set; }
        public Byte Imagem { get; private set; }
        public string UsuarioCriador { get; private set; }
        public List<Comentario> Comentarios { get; private set; }
        public DateTime DataDeCriacao { get; private set; }
        public DateTime DataDeAtualizacao { get; private set; }

        public Local Visualizar(Guid id)
        {
            return null;
        }
        public void Editar(string titulo, string descricao, string localizacao, Byte imagem )
        {
            Titulo = titulo;
            Descricao = descricao;
            Localização = localizacao;
            Imagem = imagem;
            DataDeAtualizacao = DateTime.Now;
        }
    }
}
