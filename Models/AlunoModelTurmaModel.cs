namespace EscolaDeIdiomas.Models
{
    public class AlunoModelTurmaModel
    {
        public AlunoModelTurmaModel()
        {
            
        }

        public AlunoModelTurmaModel(int alunoId, AlunoModel alunoModel, int turmaId, TurmaModel turmaModel)
        {
            AlunoId = alunoId;
            AlunoModel = alunoModel;
            TurmaId = turmaId;
            TurmaModel = turmaModel;
        }

        public int AlunoId { get; set; }  // FK para 'AlunoModel'
        public AlunoModel AlunoModel { get; set; }

        public int TurmaId { get; set; }  // FK para 'TurmaModel'
        public TurmaModel TurmaModel { get; set; }
    }
}
