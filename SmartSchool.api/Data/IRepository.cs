using SmartSchool.api.Models;

namespace SmartSchool.api.Data
{
    public interface IRepository
    {
        void add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        Aluno[] GetAllAlunos(bool includeProfessor);
        Aluno[] GetAllAlunosByDisciplinas(int disciplinaId, bool includeProfessor = false);
        Aluno GetAllAlunosById(int alunoId, bool includeProfessor = false);

        Professor[] GetAllProfessores(bool includeAluno = false);
        Professor[] GetAllProfessoresByDisciplinas(int disciplinaId, bool includeAluno = false);
        Professor GetAllProfessoresById(int idP, bool includeAluno = false);

    }
}