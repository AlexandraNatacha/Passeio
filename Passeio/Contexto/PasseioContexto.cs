using Microsoft.EntityFrameworkCore;
using Passeio.Entidades;
using System.Reflection.Emit;

namespace Passeio.Contexto
{
    public class PasseioContexto : DbContext
    {
        public PasseioContexto(DbContextOptions<PasseioContexto> options): base(options) {}

        public DbSet<Local> Locais { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dbPasseio;Integrated Security=True;Connect Timeout=30";
            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
