

using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using EscolaDeCursos.Infra.Compartilhado.Orm;

public class RepositorioMatriculaEmOrm(EscolaDeCursosDbContext dbContext) :
    RepositorioBaseEmOrm<Matricula>(dbContext), IRepositorioMatricula
{
    public List<Matricula> SelecionarPorAluno(Guid alunoId)
    {
        throw new NotImplementedException();
    }

    public List<Matricula> SelecionarPorTurma(Guid turmaId)
    {
        throw new NotImplementedException();
    }
}