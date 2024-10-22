using System.ComponentModel.DataAnnotations;

namespace EscolaDeIdiomas.Models
{
    public class AlunoModel
    {

        public AlunoModel()
        {
            
        }
        public AlunoModel(int id, string nome, string cpf, string email)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Email = email;
        }

        //[Key]
        public int Id { get; set; }


        //[Required(ErrorMessage = "O nome é Obrigatório.", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        //[Required(ErrorMessage = "O CPF é Obrigatório.", AllowEmptyStrings = false)]
        public string CPF { get; set; }

        //[Required(ErrorMessage = "O E-mail é Obrigatorio.", AllowEmptyStrings = false)]
        public string Email { get; set; }
        //public ICollection<TurmaModel> Turma { get; set; } = [];

    }
}
