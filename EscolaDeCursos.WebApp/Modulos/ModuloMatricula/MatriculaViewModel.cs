using System.ComponentModel.DataAnnotations;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EscolaDeCursos.WebApp.Modulos.ModuloMatricula;

public record OpcaoAlunoViewModel(Guid Id, string Nome);
public record OpcaoTurmaViewModel(Guid Id, string Nome);

public record ListarMatriculasViewModel(
    Guid Id,
    DateTime DataInscricao,
    string Situacao,
    string AlunoNome,
    string TurmaNome,
    string CursoNome,
    string InstrutorNome
);

public record CadastrarMatriculaViewModel(
    [Required(ErrorMessage = "Selecione um aluno.")]
    Guid? AlunoId,

    [Required(ErrorMessage = "Selecione uma turma.")]
    Guid? TurmaId,

    [Required(ErrorMessage = "A data de inscrição é obrigatória.")]
    DateTime DataInscricao,

    

    [ValidateNever]
    List<OpcaoAlunoViewModel> Alunos,

    [ValidateNever]
    List<OpcaoTurmaViewModel> Turmas
);

public record EditarMatriculaViewModel(
    Guid Id,
    [Required(ErrorMessage = "Selecione uma situação.")]
    SituacaoMatricula Situacao
);

public record CancelarMatriculaViewModel(Guid Id, string AlunoNome, string TurmaNome);