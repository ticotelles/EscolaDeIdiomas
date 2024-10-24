using Azure;
using EscolaDeIdiomas.Mappings;
using EscolaDeIdiomas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace EscolaDeIdiomas.Data
{
    public class ContextoDB : DbContext
    {

        public ContextoDB(DbContextOptions<ContextoDB> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());


            modelBuilder.Entity<AlunoModelTurmaModel>()
                .HasKey(at => new { at.TurmaId, at.AlunoId});

            modelBuilder.Entity<AlunoModelTurmaModel>()
                .HasOne(at => at.TurmaModel)
                .WithMany(at => at.Alunos)
                .HasForeignKey(at => at.TurmaId);
            modelBuilder.Entity<AlunoModelTurmaModel>()
                .HasOne(at => at.AlunoModel)
                .WithMany(at => at.Turmas)
                .HasForeignKey(at => at.AlunoId);



            //modelBuilder.Entity<AlunoTurmaModel>()
            //    .HasKey(bc => new { bc.AlunoId, bc.TurmaId });

            //modelBuilder.Entity<AlunoTurmaModel>()
            //       .HasOne(bc => bc.Aluno)
            //       .WithMany(b => b.AlunosTurmas)
            //       .HasForeignKey(bc => bc.AlunoId)
            //        .HasPrincipalKey(nameof(AlunoTurmaModel.AlunoId));

            //modelBuilder.Entity<AlunoTurmaModel>()
            //       .HasOne(bc => bc.Turma)
            //       .WithMany(c => c.AlunosTurmas)
            //       .HasForeignKey(bc => bc.TurmaId);


            //  modelBuilder.Entity<AlunoModel>()
            //.HasMany(e => e.Turmas)
            //.WithMany(e => e.Alunos)
            //.UsingEntity(
            //    "AlunoTurma",
            //    l => l.HasOne(typeof(TurmaModel)).WithMany().HasForeignKey("TurmaId").HasPrincipalKey(nameof(TurmaModel.Id)),
            //    r => r.HasOne(typeof(AlunoModel)).WithMany().HasForeignKey("AlunoId").HasPrincipalKey(nameof(AlunoModel.Id)),
            //    j => j.HasKey("AlunoId", "TurmaId"));

        }

        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<TurmaModel> Turmas { get; set; }
        public DbSet<AlunoModelTurmaModel> AlunoModelTurmaModel { get; set; }


    }
}
