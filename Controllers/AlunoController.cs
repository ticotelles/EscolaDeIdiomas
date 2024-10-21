using EscolaDeIdiomas.Data;
using EscolaDeIdiomas.Dto;
using EscolaDeIdiomas.Models;
using EscolaDeIdiomas.Services.Aluno;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeIdiomas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {


        private readonly IAlunoInterface _alunoInterface;
        public AlunoController(IAlunoInterface alunoInterface)
        {
            _alunoInterface = alunoInterface;
        }

        [HttpGet("ListarAlunos")]
        public async Task<ActionResult<ResponseModel<List<AlunoModel>>>> ListarAlunos()
        {


            var alunos = await _alunoInterface.ListarAlunos();
            return Ok(alunos);

        }

        [HttpGet("BuscarAlunoPorId/{id}")]
        public async Task<ActionResult<ResponseModel<AlunoModel>>> BuscarAlunoPorId(int id)
        {
            var alunos = await _alunoInterface.BuscarPorAlunoId(id);
            return Ok(alunos);

        }

        [HttpGet("BuscarAlunoPorCPF/{cpf}")]
        public async Task<ActionResult<ResponseModel<AlunoModel>>> BuscarAlunoPorCPF(string cpf)
        {
            var aluno = await _alunoInterface.BuscarAlunoPorCPF(cpf);
            return Ok(aluno);
        }

        [HttpPost("CadastrarAluno")]
        public async Task<ActionResult<ResponseModel<List<AlunoModel>>>> CadastrarAluno(AlunoCadastroDto alunoCadastroDto)
        {
            
            var alunos = await _alunoInterface.CadastrarAluno(alunoCadastroDto);
            return Ok(alunos);

        }

        [HttpPut("EditarAluno")]
        public async Task<ActionResult<ResponseModel<List<AlunoModel>>>> EditarAluno(AlunoEditarDto alunoEditarDto)
        {
            var alunos = await _alunoInterface.EditarAluno(alunoEditarDto);
            return Ok(alunos);
        }

        [HttpDelete("DeletarAluno")]
        public async Task<ActionResult<ResponseModel<List<AlunoModel>>>> DeletarAluno(int id)
        {
            var alunos = await _alunoInterface.DeletarAluno(id);
            return Ok(alunos);
        }


    }
}
