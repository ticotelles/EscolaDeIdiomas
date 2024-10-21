using EscolaDeIdiomas.Mappings;
using EscolaDeIdiomas.Models;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeIdiomas.Data
{
    public class ContextoDB : DbContext
    {

        public ContextoDB(DbContextOptions<ContextoDB> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
        }

        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<TurmaModel> Turmas { get; set; }


    }
}
