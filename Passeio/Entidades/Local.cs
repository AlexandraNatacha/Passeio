namespace Passeio.Entidades
{
    public class Local
    {
        public Local(string titulo, string descricao, string localizacao, byte imagem, string usuarioCriador)
        {
            Titulo = titulo;
            Descricao = descricao;
            Localizacao = localizacao;
            Imagem = imagem;
            UsuarioCriador = usuarioCriador;
            Comentarios = new List<Comentario>();
            DataDeCriacao = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Localizacao { get; private set; }
        public Byte Imagem { get; private set; }
        public string UsuarioCriador { get; private set; }
        public List<Comentario> Comentarios { get; private set; }
        public DateTime DataDeCriacao { get; private set; }
        public DateTime DataDeAtualizacao { get; private set; }

        public void Editar(string titulo, string descricao, string localizacao, Byte imagem )
        {
            Titulo = titulo;
            Descricao = descricao;
            Localizacao = localizacao;
            Imagem = imagem;
            DataDeAtualizacao = DateTime.Now;
        }
    }
}
