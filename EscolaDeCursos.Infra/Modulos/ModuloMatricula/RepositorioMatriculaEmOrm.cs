using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using Microsoft.EntityFrameworkCore;

public class RepositorioMatriculaEmOrm(EscolaDeCursosDbContext dbContext) :
    RepositorioBaseEmOrm<Matricula>(dbContext), IRepositorioMatricula
{
    
    public override List<Matricula> SelecionarTodos()
    {
        return dbContext.Set<Matricula>()
            .Include(m => m.Aluno)
            .Include(m => m.Turma)
                .ThenInclude(t => t.Curso)
            .Include(m => m.Turma)
                .ThenInclude(t => t.Instrutor)
            .ToList();
    }

    
    public List<Matricula> SelecionarPorAluno(Guid alunoId)
    {
        return dbContext.Set<Matricula>()
            .Include(m => m.Aluno)
            .Include(m => m.Turma)
                .ThenInclude(t => t.Curso)
            .Include(m => m.Turma)
                .ThenInclude(t => t.Instrutor)
            .Where(m => m.Aluno.Id == alunoId)
            .ToList();
    }

    public List<Matricula> SelecionarPorTurma(Guid turmaId)
    {
        return dbContext.Set<Matricula>()
            .Include(m => m.Aluno)
            .Include(m => m.Turma)
                .ThenInclude(t => t.Curso)
            .Include(m => m.Turma)
                .ThenInclude(t => t.Instrutor)
            .Where(m => m.Turma.Id == turmaId)
            .ToList();
    }
    
    
    public override Matricula? SelecionarPorId(Guid id)
    {
        return dbContext.Set<Matricula>()
            .Include(m => m.Aluno)
            .Include(m => m.Turma)
                .ThenInclude(t => t.Curso)
            .Include(m => m.Turma)
                .ThenInclude(t => t.Instrutor)
            .FirstOrDefault(m => m.Id == id);
    }
}