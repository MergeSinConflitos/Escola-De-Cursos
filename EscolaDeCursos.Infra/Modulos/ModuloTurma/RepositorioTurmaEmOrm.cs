using EscolaDeCursos.Dominio.Modulos.ModuloTuma;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Modulos.ModuloTurma;

public sealed class RepositorioTurmaEmOrm(EscolaDeCursosDbContext dbContext) :
    RepositorioBaseEmOrm<Turma>(dbContext), IRepositorioTurma
{
    public override List<Turma> SelecionarTodos() //testeando??
    {
        return dbContext.Set<Turma>()
            .Include(t => t.Curso)
            .Include(t => t.Instrutor)
            .Include(t => t.Matriculas)
            .ToList();
    }
}