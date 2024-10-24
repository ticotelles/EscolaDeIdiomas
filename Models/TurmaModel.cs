using Azure;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EscolaDeIdiomas.Models
{
    public class TurmaModel
    {
        public TurmaModel()
        {
            
        }
        public TurmaModel(int id, string codigo, string nivel, ICollection<AlunoModelTurmaModel> alunos)
        {
            Id = id;
            Codigo = codigo;
            Nivel = nivel;
            Alunos = alunos;
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nivel { get; set; }

        [JsonIgnore]
        public ICollection<AlunoModelTurmaModel> Alunos { get; set; }
    }
}
