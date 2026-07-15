

using EscolaDeCursos.Dominio.Modulos.ModuloInstrutor;
using EscolaDeCursos.Infra.Compartilhado.Orm;

public sealed class RepositorioInstrutorEmOrm(EscolaDeCursosDbContext dbContext): 
    RepositorioBaseEmOrm<Instrutor>(dbContext), IRepositorioInstrutor;