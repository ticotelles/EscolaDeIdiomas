using EscolaDeIdiomas.Data;
using EscolaDeIdiomas.Dto;
using EscolaDeIdiomas.Models;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeIdiomas.Services.Turma
{
    public class TurmaService : ITurmaInterface
    {
        private readonly ContextoDB _contexto;
        public TurmaService(ContextoDB contexto)
        {
            _contexto = contexto;
        }

        public async Task<ResponseModel<List<TurmaModel>>> CadastrarTurma(TurmaCadastroDto turmaCadastroDto)
        {
            ResponseModel<List<TurmaModel>> resposta = new ResponseModel<List<TurmaModel>>();
            try
            {

                var turma = new TurmaModel()
                {
                    Codigo = turmaCadastroDto.Codigo,
                    Nivel = turmaCadastroDto.Nivel
                };

                _contexto.Add(turma);
                await _contexto.SaveChangesAsync();


                if (turmaCadastroDto.AlunoModel != null)
                {
                    var aluno = await _contexto.Alunos
                            .FirstOrDefaultAsync(a => a.AlunoId == turmaCadastroDto.AlunoModel.Id);


                    if (aluno == null)
                    {
                        aluno = new AlunoModel
                        {
                            AlunoId = turmaCadastroDto.AlunoModel.Id
                        };

                        _contexto.Alunos.Add(aluno);
                        await _contexto.SaveChangesAsync();
                    }

                    var alunoTurma = new AlunoModelTurmaModel
                    {
                        AlunoId = aluno.AlunoId,
                        TurmaId = turma.Id
                    };

                    _contexto.AlunoModelTurmaModel.Add(alunoTurma);
                    await _contexto.SaveChangesAsync();

                }

                resposta.Dados = await _contexto.Turmas.ToListAsync();
                resposta.Mensagem = "Turma cadastrado com sucesso!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
                
            }
        }

        public async Task<ResponseModel<List<TurmaModel>>> DeletarTurma(int id)
        {
            ResponseModel<List<TurmaModel>> resposta = new ResponseModel<List<TurmaModel>>();

            try
            {

                //var excluirturma = await _contexto.Turmas

                var turma = await _contexto.Turmas.FirstOrDefaultAsync(turmaBanco =>  turmaBanco.Id == id);
                if (turma == null)
                {
                    resposta.Mensagem = "Erro ao Deletar, turma não encontrado!";
                    return resposta;
                }

                _contexto.Remove(turma);

                await _contexto.SaveChangesAsync();
                resposta.Dados = await _contexto.Turmas.ToListAsync();
                resposta.Mensagem = "Turma Deletado com sucesso!";
                return resposta;


            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<TurmaModel>>> ListarTurma()
        {
            ResponseModel<List<TurmaModel>> resposta = new ResponseModel<List<TurmaModel>>();
            try
            {
                var turma = await _contexto.Turmas.ToListAsync();
                resposta.Dados = turma;
                resposta.Mensagem = "Todas as Turmas foram listadas!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta; 
            }
        }
    }
}
