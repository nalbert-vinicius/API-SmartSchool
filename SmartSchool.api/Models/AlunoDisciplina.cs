using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.api.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina() { }
        public int AlunoId { get; set; }
        public int DisciplinaId { get; set; }
        public  Aluno Aluno { get; set; }
        public Disciplina Disciplina { get; set; }
        public DateTime DataIni { get; set; } =DateTime.Now;
        public DateTime? DataFim { get; set; }
        public double? Nota { get; set; } = null;

        public AlunoDisciplina(int alunoId, int disciplinaId)
        {
            AlunoId = alunoId;
            DisciplinaId = disciplinaId;
        }
    }
}
