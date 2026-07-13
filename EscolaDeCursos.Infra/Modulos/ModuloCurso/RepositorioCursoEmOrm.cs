using System;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Infra.Compartilhado.Orm;

namespace EscolaDeCursos.Infra.Modulos.ModuloCurso;

public sealed class RepositorioCursoEmOrm(EscolaDeCursosDbContext dbContext) :
    RepositorioBaseEmOrm<Curso>(dbContext), IRepositorioCurso
{
}
