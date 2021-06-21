using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.api.Models
{
    public class AlunoCurso
    {
        public AlunoCurso() { }
        public int AlunoId { get; set; }
        public int CursoId { get; set; }
        public  Aluno Aluno { get; set; }
        public Curso Curso { get; set; }
        public DateTime DataIni { get; set; } =DateTime.Now;
        public DateTime? DataFim { get; set; }

        public AlunoCurso(int alunoId, int cursoid)
        {
            AlunoId = alunoId;
            CursoId = cursoid;
        }
    }
}
