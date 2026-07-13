

using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;

public interface IRepositorioMatricula : IRepositorio<Matricula>
{
    List<Matricula> SelecionarPorAluno(Guid alunoId);
    List<Matricula> SelecionarPorTurma(Guid turmaId);
}