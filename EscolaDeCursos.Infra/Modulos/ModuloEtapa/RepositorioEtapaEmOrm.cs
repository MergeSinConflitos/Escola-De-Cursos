using System;
using EscolaDeCursos.Dominio.Modulos.ModuloEtapa;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Modulos.ModuloEtapa;

public sealed class RepositorioEtapaEmOrm(EscolaDeCursosDbContext dbContext) :
    RepositorioBaseEmOrm<Etapa>(dbContext), IRepositorioEtapa
{
    public override List<Etapa> SelecionarTodos()
    {
        return dbContext.Etapas
            .Include(e => e.Curso)
            .ToList();
    }


    public override Etapa? SelecionarPorId(Guid id)
    {
        return dbContext.Etapas
            .Include(e => e.Curso)
            .FirstOrDefault(e => e.Id == id);
    }
}