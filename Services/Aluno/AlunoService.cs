using EscolaDeIdiomas.Data;
using EscolaDeIdiomas.Dto;
using EscolaDeIdiomas.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EscolaDeIdiomas.Services.Aluno
{
    public class AlunoService : IAlunoInterface
    {
        private readonly ContextoDB _contexto;
        public AlunoService(ContextoDB contexto)
        {
            _contexto = contexto;
        }
        public async Task<ResponseModel<AlunoModel>> BuscarAlunoPorCPF(string cpf)
        {
            ResponseModel<AlunoModel> resposta = new ResponseModel<AlunoModel>();
            try
            {

                var aluno = await _contexto.Alunos.FirstOrDefaultAsync(alunoBanco => alunoBanco.CPF == cpf);
                if (aluno == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = aluno;
                resposta.Mensagem = "Aluno Localizado!";
                return resposta;


            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AlunoModel>> BuscarPorAlunoId(int id)
        {
            ResponseModel<AlunoModel> resposta = new ResponseModel<AlunoModel>();
            try
            {

                var aluno = await _contexto.Alunos.FirstOrDefaultAsync(alunoBanco => alunoBanco.Id == id);
                if (aluno == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = aluno;
                resposta.Mensagem = "Aluno Localizado!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AlunoModel>>> CadastrarAluno(AlunoCadastroDto alunoCadastroDto)
        {
            ResponseModel<List<AlunoModel>> resposta = new ResponseModel<List<AlunoModel>>();
            try
            {
                var aluno = new AlunoModel()
                {
                    Nome = alunoCadastroDto.Nome,
                    CPF = alunoCadastroDto.CPF,
                    Email = alunoCadastroDto.Email
                };

                _contexto.Add(aluno);
                await _contexto.SaveChangesAsync();
                
                resposta.Dados = await _contexto.Alunos.ToListAsync();
                resposta.Mensagem = "Aluno Cadastrado com sucesso!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AlunoModel>>> DeletarAluno(int id)
        {
            ResponseModel<List<AlunoModel>> resposta = new ResponseModel<List<AlunoModel>>();

            try
            {
                var aluno = await _contexto.Alunos.FirstOrDefaultAsync(alunoBanco => alunoBanco.Id == id);

                if(aluno == null)
                {
                    resposta.Mensagem = "Erro ao Deletar, Aluno não encontrado!";
                    return resposta;
                }

                _contexto.Remove(aluno);
                await _contexto.SaveChangesAsync();

                resposta.Dados = await _contexto.Alunos.ToListAsync();
                resposta.Mensagem = "Aluno deletado com sucesso!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AlunoModel>>> EditarAluno(AlunoEditarDto alunoEditarDto)
        {
            ResponseModel<List<AlunoModel>> resposta = new ResponseModel<List<AlunoModel>>();

            try
            {
                var aluno = await _contexto.Alunos
                    .FirstOrDefaultAsync(alunoBanco => alunoBanco.Id == alunoEditarDto.Id);

                if (aluno == null)
                {
                    resposta.Mensagem = "Erro ao Editar, Aluno não encontrado!";
                    return resposta;
                }

                aluno.Nome = alunoEditarDto.Nome;
                aluno.Email = alunoEditarDto.Email;
                aluno.CPF = alunoEditarDto.CPF;

                _contexto.Update(aluno);
                await _contexto.SaveChangesAsync();
                resposta.Mensagem = "Aluno editado com sucesso!";
                resposta.Dados = await _contexto.Alunos.ToListAsync();
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AlunoModel>>> ListarAlunos()
        {
            ResponseModel<List<AlunoModel>> resposta = new ResponseModel<List<AlunoModel>>();
            try
            {
                var alunos = await _contexto.Alunos.ToListAsync();

                resposta.Dados = alunos;

                resposta.Mensagem = "Todos os Alunos foram coletados!";

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
