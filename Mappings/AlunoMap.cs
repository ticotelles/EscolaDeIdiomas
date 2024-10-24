using EscolaDeIdiomas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeIdiomas.Mappings
{
    public class AlunoMap : IEntityTypeConfiguration<AlunoModel>
    {
        public void Configure(EntityTypeBuilder<AlunoModel> builder)
        {
            builder.ToTable("Aluno");

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.CPF)
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

        }
    }
}
