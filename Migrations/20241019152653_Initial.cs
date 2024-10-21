using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EscolaDeIdiomas.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar(10)", nullable: false),
                    Nivel = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Aluno",
                columns: new[] { "Id", "CPF", "Email", "Nome" },
                values: new object[,]
                {
                    { 1, "10032136692", "arthur1@gmail.com", "Arthur1" },
                    { 2, "20032136692", "arthur2@gmail.com", "Arthur2" },
                    { 3, "30032136692", "arthur3@gmail.com", "Arthur3" },
                    { 4, "40032136692", "arthur4@gmail.com", "Arthur4" },
                    { 5, "50032136692", "arthur5@gmail.com", "Arthur5" },
                    { 6, "60032136692", "arthur6@gmail.com", "Arthur6" },
                    { 7, "70032136692", "arthur7@gmail.com", "Arthur7" }
                });

            migrationBuilder.InsertData(
                table: "Turma",
                columns: new[] { "Id", "Codigo", "Nivel" },
                values: new object[,]
                {
                    { 1, "Eng01", "Iniciante" },
                    { 2, "Eng02", "Intermediario" },
                    { 3, "Eng03", "Avançado" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Turma");
        }
    }
}
