namespace EscolaDeIdiomas.Models
{
    public class TurmaModel
    {
        public TurmaModel()
        {
            
        }
        public TurmaModel(int id, string codigo, string nivel)
        {
            Id = id;
            Codigo = codigo;
            Nivel = nivel;
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nivel { get; set; }
        //public ICollection<AlunoModel> Aluno { get; set; } = [];

    }
}
