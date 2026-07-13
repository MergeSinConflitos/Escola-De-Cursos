using System;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Infra.Compartilhado.Orm;

namespace EscolaDeCursos.Infra.Modulos.ModuloCurso;

using Microsoft.EntityFrameworkCore;

public sealed class RepositorioCursoEmOrm(EscolaDeCursosDbContext dbContext) :
    RepositorioBaseEmOrm<Curso>(dbContext), IRepositorioCurso
{
    public override List<Curso> SelecionarTodos()
    {
        return dbContext.Cursos
            .Include(c => c.Categoria)
            .Include(c => c.NivelDeDificuldade)
            .ToList();
    }

    public override Curso? SelecionarPorId(Guid id)
    {
        return dbContext.Cursos
            .Include(c => c.Categoria)
            .Include(c => c.NivelDeDificuldade)
            .FirstOrDefault(c => c.Id == id);
    }
}