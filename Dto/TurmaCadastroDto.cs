﻿using EscolaDeIdiomas.Models;

namespace EscolaDeIdiomas.Dto
{
    public class TurmaCadastroDto
    {
        public string Codigo { get; set; }
        public string Nivel { get; set; }

        public TurmaAlunoVinculoDto AlunoModel { get; set; }
    }
}
