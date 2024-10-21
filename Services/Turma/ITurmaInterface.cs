using EscolaDeIdiomas.Dto;
using EscolaDeIdiomas.Models;

namespace EscolaDeIdiomas.Services.Turma
{
    public interface ITurmaInterface
    {
        Task<ResponseModel<List<TurmaModel>>> ListarTurma();
        Task<ResponseModel<List<TurmaModel>>> CadastrarTurma(TurmaCadastroDto turmaCadastroDto);
        Task<ResponseModel<List<TurmaModel>>> DeletarTurma(int id);
    }
}
