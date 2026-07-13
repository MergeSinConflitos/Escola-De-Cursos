using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EscolaDeCursos.WebApp.Modulos.ModuloEtapa;


public record ListarEtapasViewModel(
    Guid Id,
    string Nome,
    int Duracao,
    int Ordem,
    Guid CursoId,
    string CursoNome
);



public record CadastrarEtapaViewModel(

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2,
        ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    string Nome,


    [Range(1, int.MaxValue,
        ErrorMessage = "Informe uma duração válida.")]
    int Duracao,


    [Range(1, int.MaxValue,
        ErrorMessage = "Informe uma ordem válida.")]
    int Ordem,


    [Required(ErrorMessage = "Selecione um curso.")]
    Guid? CursoId,


    [ValidateNever]
    List<OpcaoCursoViewModel> Cursos
);



public record EditarEtapaViewModel(

    Guid Id,


    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2,
        ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    string Nome,


    [Range(1, int.MaxValue,
        ErrorMessage = "Informe uma duração válida.")]
    int Duracao,


    [Range(1, int.MaxValue,
        ErrorMessage = "Informe uma ordem válida.")]
    int Ordem,


    [Required(ErrorMessage = "Selecione um curso.")]
    Guid? CursoId,


    [ValidateNever]
    List<OpcaoCursoViewModel> Cursos
);



public record ExcluirEtapaViewModel(
    Guid Id,
    string Nome
);

public record OpcaoCursoViewModel(
    Guid Id,
    string Nome
);