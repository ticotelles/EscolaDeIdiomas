using EscolaDeIdiomas.Data;
using EscolaDeIdiomas.Services.Aluno;
using EscolaDeIdiomas.Services.Turma;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ContextoDB>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ContextoDB")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAlunoInterface, AlunoService>();
builder.Services.AddScoped<ITurmaInterface, TurmaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
