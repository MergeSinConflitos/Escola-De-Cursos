using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Infra.Compartilhado.Orm;

namespace EscolaDeCursos.Infra.Modulos.ModuloAluno;

public sealed class RepositorioAlunoEmOrm(EscolaDeCursosDbContext dbContext) :
    RepositorioBaseEmOrm<Aluno>(dbContext), IRepositorioAluno
{
    public List<Aluno> SelecionarPorNome(string nome)
    {
        return dbContext.Alunos
            .Where(a => a.Nome.Contains(nome))
            .ToList();
    }
}