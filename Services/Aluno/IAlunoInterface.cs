using EscolaDeIdiomas.Dto;
using EscolaDeIdiomas.Models;

namespace EscolaDeIdiomas.Services.Aluno
{
    public interface IAlunoInterface
    {
        Task<ResponseModel<List<AlunoModel>>> ListarAlunos();
        Task<ResponseModel<AlunoModel>> BuscarPorAlunoId(int id);
        Task<ResponseModel<AlunoModel>> BuscarAlunoPorCPF(string cpf);
        Task<ResponseModel<List<AlunoModel>>> CadastrarAluno(AlunoCadastroDto alunoCadastroDto);
        Task<ResponseModel<List<AlunoModel>>> EditarAluno(AlunoEditarDto alunoEditarDto);
        Task<ResponseModel<List<AlunoModel>>> DeletarAluno(int id);

    }
}
