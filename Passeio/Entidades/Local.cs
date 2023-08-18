using System.Globalization;

namespace Passeio.Entidades
{
    public class Local
    {
        public Local(string titulo, string descricao, string localização, byte imagem, string usuarioCriador, List<Comentario> comentarios)
        {
            Titulo = titulo;
            Descricao = descricao;
            Localização = localização;
            Imagem = imagem;
            UsuarioCriador = usuarioCriador;
            Comentarios = comentarios;
            DataDeCriacao = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Localização { get; set; }
        public Byte Imagem { get; set; }
        public string UsuarioCriador { get; set; }
        public List<Comentario> Comentarios { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public DateTime DataDeAtualizacao { get; set; }

        public Local VisualizarLocal(Guid id){}
        public void CriarLocal() {}
        public Local EditarLugar(Guid id) {}
        public void DeletarLocal(Guid id) {}
    }
}
