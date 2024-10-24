using EscolaDeIdiomas.Models;

namespace EscolaDeIdiomas.Dto
{
    public class AlunoCadastroDto
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }

        public AlunoTurmaVinculoDto TurmaModel { get; set; }
    }
}
