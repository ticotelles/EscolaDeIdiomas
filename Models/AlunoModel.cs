using Azure;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EscolaDeIdiomas.Models
{
    public class AlunoModel
    {

        public AlunoModel()
        {   
        }

        public AlunoModel(int alunoId, string nome, string cpf, string email, ICollection<AlunoModelTurmaModel> turmas)
        {
            AlunoId = alunoId;
            Nome = nome;
            CPF = cpf;
            Email = email;
            Turmas = turmas;
        }

        [Key]
        public int AlunoId { get; set; }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public ICollection<AlunoModelTurmaModel> Turmas { get; set; }



    }
}
