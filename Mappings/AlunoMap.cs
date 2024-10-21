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

            builder.HasData(new AlunoModel(1, "Arthur1", "10032136692", "arthur1@gmail.com"));
            builder.HasData(new AlunoModel(2, "Arthur2", "20032136692", "arthur2@gmail.com"));
            builder.HasData(new AlunoModel(3, "Arthur3", "30032136692", "arthur3@gmail.com"));

            builder.HasData(new AlunoModel(4, "Arthur4", "40032136692", "arthur4@gmail.com"));
            builder.HasData(new AlunoModel(5, "Arthur5", "50032136692", "arthur5@gmail.com"));
            builder.HasData(new AlunoModel(6, "Arthur6", "60032136692", "arthur6@gmail.com"));
            builder.HasData(new AlunoModel(7, "Arthur7", "70032136692", "arthur7@gmail.com"));
        }
    }
}
