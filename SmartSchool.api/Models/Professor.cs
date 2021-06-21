using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.api.Models
{
    public class Professor
    {
        public Professor() { }
        public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;

        public IEnumerable<Disciplina> Disciplina { get; set; }

        public Professor(int id, int registro, string nome, string sobrenome)
        {
            Id = id;
            this.Registro = registro;
            Nome = nome;
            this.Sobrenome = sobrenome;
        }
    }
}
