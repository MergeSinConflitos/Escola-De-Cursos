using EscolaDeCursos.Dominio.Compartilhado;


namespace EscolaDeCursos.Dominio.Modulos.ModuloAluno;

public interface IRepositorioAluno : IRepositorio<Aluno>
{
    List<Aluno> SelecionarPorNome(string nome);
}