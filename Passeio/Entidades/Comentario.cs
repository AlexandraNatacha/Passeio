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

        public void Criar() {}
        public List<Comentario> Listar()
        {
            return null;
        }
        public void Deletar(Guid id) { }
    }
}
