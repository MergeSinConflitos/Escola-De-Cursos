using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EscolaDeCursos.WebApp.Modulos.ModuloTurma;

public record OpcaoCursoViewModel(
    Guid Id,
    string Nome
);

public record OpcaoInstrutorViewModel(
    Guid Id,
    string Nome
);

public record ListarTurmaViewModel(
    Guid Id,
    string Nome,
    string Periodo,
    DateTime DataInicio,
    DateTime DataTermino,
    int QuantidadeMaxAlunos,
    string CursoNome,
    string InstrutorNome,
    int TotalAlunosMatriculados,
    bool EstaCheia
);

public record CadastrarTurmaViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Período\" deve ser selecionado.")]
    int Periodo,

    [Required(ErrorMessage = "O campo \"Data de Início\" deve ser preenchido.")]
    DateTime DataInicio,

    [Required(ErrorMessage = "O campo \"Data de Término\" deve ser preenchido.")]
    DateTime DataTermino,

    [Required(ErrorMessage = "A quantidade máxima de alunos deve ser maior que zero.")]
    [Range(1, int.MaxValue, ErrorMessage = "A quantidade máxima de alunos deve ser maior que zero.")]
    int QuantidadeMaxAlunos,

    [Required(ErrorMessage = "Selecione um curso.")]
    Guid? CursoId,

    [Required(ErrorMessage = "Selecione um instrutor.")]
    Guid? InstrutorId,

    [ValidateNever]
    List<OpcaoCursoViewModel> Cursos,

    [ValidateNever]
    List<OpcaoInstrutorViewModel> Instrutores
);

public record EditarTurmaViewModel(
    Guid Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Período\" deve ser selecionado.")]
    int Periodo,

    [Required(ErrorMessage = "O campo \"Data de Início\" deve ser preenchido.")]
    DateTime DataInicio,

    [Required(ErrorMessage = "O campo \"Data de Término\" deve ser preenchido.")]
    DateTime DataTermino,

    [Required(ErrorMessage = "A quantidade máxima de alunos deve ser maior que zero.")]
    [Range(1, int.MaxValue, ErrorMessage = "A quantidade máxima de alunos deve ser maior que zero.")]
    int QuantidadeMaxAlunos,

    [Required(ErrorMessage = "Selecione um curso.")]
    Guid? CursoId,

    [Required(ErrorMessage = "Selecione um instrutor.")]
    Guid? InstrutorId,

    [ValidateNever]
    List<OpcaoCursoViewModel> Cursos,

    [ValidateNever]
    List<OpcaoInstrutorViewModel> Instrutores
);

public record ExcluirTurmaViewModel(
    Guid Id,
    string Nome,
    string Periodo,
    DateTime DataInicio,
    DateTime DataTermino,
    int QuantidadeMaxAlunos,
    string CursoNome,
    string InstrutorNome
);

public record DetalhesTurmaViewModel(
    Guid Id,
    string Nome,
    int Periodo,
    string PeriodoNome,
    DateTime DataInicio,
    DateTime DataTermino,
    int QuantidadeMaxAlunos,
    Guid CursoId,
    string CursoNome,
    Guid InstrutorId,
    string InstrutorNome,
    List<AlunoMatriculadoViewModel> AlunosMatriculados
);

public record AlunoMatriculadoViewModel(
    Guid Id,
    string Nome,
    string Email,
    DateTime DataInscricao,
    string Situacao
);