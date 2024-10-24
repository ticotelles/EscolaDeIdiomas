﻿// <auto-generated />
using EscolaDeIdiomas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EscolaDeIdiomas.Migrations
{
    [DbContext(typeof(ContextoDB))]
    [Migration("20241024170553_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EscolaDeIdiomas.Models.AlunoModel", b =>
                {
                    b.Property<int>("AlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlunoId"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("AlunoId");

                    b.ToTable("Aluno", (string)null);
                });

            modelBuilder.Entity("EscolaDeIdiomas.Models.AlunoModelTurmaModel", b =>
                {
                    b.Property<int>("TurmaId")
                        .HasColumnType("int");

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.HasKey("TurmaId", "AlunoId");

                    b.HasIndex("AlunoId");

                    b.ToTable("AlunoModelTurmaModel");
                });

            modelBuilder.Entity("EscolaDeIdiomas.Models.TurmaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Nivel")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Turma", (string)null);
                });

            modelBuilder.Entity("EscolaDeIdiomas.Models.AlunoModelTurmaModel", b =>
                {
                    b.HasOne("EscolaDeIdiomas.Models.AlunoModel", "AlunoModel")
                        .WithMany("Turmas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EscolaDeIdiomas.Models.TurmaModel", "TurmaModel")
                        .WithMany("Alunos")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AlunoModel");

                    b.Navigation("TurmaModel");
                });

            modelBuilder.Entity("EscolaDeIdiomas.Models.AlunoModel", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("EscolaDeIdiomas.Models.TurmaModel", b =>
                {
                    b.Navigation("Alunos");
                });
#pragma warning restore 612, 618
        }
    }
}
