using Microsoft.EntityFrameworkCore;
using Passeio.Entidades;

namespace Passeio.Contexto
{
    public class PasseioContexto : DbContext
    {
        public PasseioContexto(DbContextOptions<PasseioContexto> options): base(options) 
        {
            this.Database.Migrate();
        }

        public DbSet<Local> Locais { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
