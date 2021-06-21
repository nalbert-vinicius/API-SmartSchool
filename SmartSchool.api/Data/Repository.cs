using Microsoft.EntityFrameworkCore;
using SmartSchool.api.Models;
using System.Linq;

namespace SmartSchool.api.Data
{
    public class Repository : IRepository
    {
        public readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }

        public void add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }



        //Alunos
        public Aluno[] GetAllAlunos(bool includeProfessor)
        {
            //incluindo aluno dentro da query
            IQueryable<Aluno> query = _context.Alunos;
            
            if (includeProfessor)
            {
                //consulta alunos tranzendo professor e disciplinas
                query = query.Include(a => a.AlunosDisciplinas)
                    //inclui a tablea AlunoDisciplina
                    .ThenInclude(ad => ad.Disciplina)
                    //inclui a tablea Disciplina
                    .ThenInclude(p => p.Professor);
                    //inclui a tablea professor
            }
            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray();
        }

        public Aluno[] GetAllAlunosByDisciplinas(int disciplinaId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                //consulta alunos tranzendo professor e disciplinas
                query = query.Include(a => a.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(p => p.Professor);
            }
            query = query.AsNoTracking()
                .OrderBy(a => a.Id)
                .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId));

            return query.ToArray();
        }

        public Aluno GetAllAlunosById(int alunoId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                //consulta alunos tranzendo professor e disciplinas
                query = query.Include(a => a.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(p => p.Professor);
            }
            query = query.AsNoTracking()
                .OrderBy(a => a.Id)
                .Where(a=> a.Id == alunoId);

            return query.FirstOrDefault();
        }





        //Professores
        public Professor[] GetAllProfessores(bool includeAluno = false)
        {
            //incluindo professor dentro da querry
            IQueryable<Professor> query = _context.Professores;
            if (includeAluno)
            {
                //incluindo disciplina
                query = query.Include(a => a.Disciplina)
                    //incluindo aluno disciplina
                    .ThenInclude(ad => ad.AlunosDisciplinas)
                    //incluindo aluno
                    .ThenInclude(al => al.Aluno);
            }
            //ordenar por ID
            query = query.AsNoTracking().OrderBy(x => x.Id);

            return query.ToArray();
        }

        public Professor[] GetAllProfessoresByDisciplinas(int disciplinaId, bool includeAluno = false)
        {
            //incluindo professor dentro da querry
            IQueryable<Professor> query = _context.Professores;
            if (includeAluno)
            {
                //incluindo disciplina
                query = query.Include(a => a.Disciplina)
                    //incluindo aluno disciplina
                    .ThenInclude(ad => ad.AlunosDisciplinas)
                    //incluindo aluno
                    .ThenInclude(al => al.Aluno);
            }
            //ordenar por ID
            query = query.AsNoTracking()
                .OrderBy(x => x.Id)
                .Where(a => a.Disciplina.Any(dc => dc.Id == disciplinaId));

            return query.ToArray();
        }

        public Professor GetAllProfessoresById(int idP, bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;
            if (includeAluno)
            {
                query = query.Include(x => x.Disciplina)
                    .ThenInclude(x => x.AlunosDisciplinas)
                    .ThenInclude(x => x.Aluno);
            }

            query = query.AsNoTracking()
                .OrderBy(x => x.Id)
                .Where(x => x.Id == idP);

            return query.FirstOrDefault();
        }

    }
}