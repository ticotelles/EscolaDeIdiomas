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
                var turma = _contexto.Turmas.FirstOrDefaultAsync(turmaBanco =>  turmaBanco.Id == id);
                if (turma == null)
                {
                    resposta.Mensagem = "Erro ao Deletar, turma não encontrado!";
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
