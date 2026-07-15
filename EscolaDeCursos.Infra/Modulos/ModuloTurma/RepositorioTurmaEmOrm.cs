using EscolaDeCursos.Dominio.Modulos.ModuloTuma;
using EscolaDeCursos.Infra.Compartilhado.Orm;

namespace EscolaDeCursos.Infra.Modulos.ModuloTurma;

public sealed class RepositorioTurmaEmOrm(EscolaDeCursosDbContext dbContext) :
    RepositorioBaseEmOrm<Turma>(dbContext), IRepositorioTurma
{

}