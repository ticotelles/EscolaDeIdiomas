
using EscolaDeIdiomas.Dto;
using EscolaDeIdiomas.Models;
using EscolaDeIdiomas.Services.Turma;
using Microsoft.AspNetCore.Mvc;



namespace EscolaDeIdiomas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaInterface _turmaInterface;

        public TurmaController(ITurmaInterface turmaInterface)
        {
            _turmaInterface = turmaInterface;
        }

        [HttpGet("ListarTurma")]
        public async Task<ActionResult<ResponseModel<List<TurmaModel>>>> ListarTurma()
        {
            var turma = await _turmaInterface.ListarTurma();
            return Ok(turma);
        }

        [HttpPost("CadastrarTurma")]
        public async Task<ActionResult<ResponseModel<List<TurmaModel>>>> CadastrarTurma(TurmaCadastroDto turmaCadastroDto)
        {
            var turma = await _turmaInterface.CadastrarTurma(turmaCadastroDto);
            return Ok(turma);
        }

        [HttpDelete("DeletarTurma")]
        public async Task<ActionResult<ResponseModel<List<TurmaModel>>>> DeletarTurma(int id)
        {
            var turma = await _turmaInterface.DeletarTurma(id);
            return Ok(turma);
        }





    }
}
