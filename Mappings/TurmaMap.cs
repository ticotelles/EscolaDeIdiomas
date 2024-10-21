using EscolaDeIdiomas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeIdiomas.Mappings
{
    public class TurmaMap : IEntityTypeConfiguration<TurmaModel>
    {
        public void Configure(EntityTypeBuilder<TurmaModel> builder)
        {
            builder.ToTable("Turma");

            builder.Property(p => p.Codigo)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(p => p.Nivel)
                .HasColumnType("varchar(20)")
                .IsRequired();


            builder.HasData(new TurmaModel(1, "Eng01", "Iniciante"));
            builder.HasData(new TurmaModel(2, "Eng02", "Intermediario"));
            builder.HasData(new TurmaModel(3, "Eng03", "Avançado"));
        }
    }
}
