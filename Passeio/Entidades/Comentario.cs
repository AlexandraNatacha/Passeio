namespace Passeio.Entidades
{
    public class Comentario
    {
        public Comentario(string descricao, string usuarioAutor)
        {
            Descricao = descricao;
            UsuarioAutor = usuarioAutor;
            DataDeCriacao = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string UsuarioAutor{ get; set; }
        public DateTime DataDeCriacao { get; set; }

        public void CriarComentario() {}
        public List<Comentario> ListarComentarios() { }
        public void DeletarComentario(Guid id) { }
    }
}
