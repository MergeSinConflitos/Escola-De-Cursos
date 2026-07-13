using System;
using EscolaDeCursos.Dominio.Modulos.ModuloNivelDeDificuldade;
using EscolaDeCursos.Infra.Compartilhado.Orm;

namespace EscolaDeCursos.Infra.Modulos.ModuloNivelDeDificuldade;

public sealed class RepositorioNivelDeDificuldadeEmOrm(EscolaDeCursosDbContext dbContext) :
    RepositorioBaseEmOrm<NivelDeDificuldade>(dbContext), IRepositorioNivelDeDificuldade
{
}