using System;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso;

public record OpcaoCategoriaViewModel(
    Guid Id,
    string Nome
);

public record OpcaoNivelDeDificuldadeViewModel(
    Guid Id,
    string Nome
);

public record ListarCursosViewModel(
    Guid Id,
    string Nome,
    int CargaHoraria,
    string Categoria,
    string NivelDeDificuldade
);

public record CadastrarCursoViewModel(

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    string Nome,

    [Range(1, int.MaxValue, ErrorMessage = "A carga horária deve ser maior que zero.")]
    int CargaHoraria,

    [Required(ErrorMessage = "Selecione uma categoria.")]
    Guid? CategoriaId,

    [Required(ErrorMessage = "Selecione um nível de dificuldade.")]
    Guid? NivelDeDificuldadeId,

    [ValidateNever]
    List<OpcaoCategoriaViewModel> Categorias,

    [ValidateNever]
    List<OpcaoNivelDeDificuldadeViewModel> NiveisDeDificuldade
);

public record EditarCursoViewModel(

    Guid Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    string Nome,

    [Range(1, int.MaxValue, ErrorMessage = "A carga horária deve ser maior que zero.")]
    int CargaHoraria,

    [Required(ErrorMessage = "Selecione uma categoria.")]
    Guid? CategoriaId,

    [Required(ErrorMessage = "Selecione um nível de dificuldade.")]
    Guid? NivelDeDificuldadeId,

    [ValidateNever]
    List<OpcaoCategoriaViewModel> Categorias,

    [ValidateNever]
    List<OpcaoNivelDeDificuldadeViewModel> NiveisDeDificuldade
);

public record ExcluirCursoViewModel(
    Guid Id,
    string Nome,
    int CargaHoraria,
    string CategoriaNome,
    string NivelDeDificuldadeNome
);