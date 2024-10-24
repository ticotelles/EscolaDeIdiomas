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

        }
    }
}
