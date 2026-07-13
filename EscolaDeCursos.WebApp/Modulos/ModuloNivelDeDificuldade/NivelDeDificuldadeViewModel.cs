using System;

namespace EscolaDeCursos.WebApp.Modulos.ModuloNivelDeDificuldade;

using System.ComponentModel.DataAnnotations;
using EscolaDeCursos.Dominio.Modulos.ModuloNivelDeDificuldade;

public record ListarNivelDeDificuldadeViewModel(
    Guid Id,
    string Nome,
    string? Descricao,
    Classificacao Classificacao
);


public record CadastrarNivelDeDificuldadeViewModel(

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 50 caracteres.")]
    string Nome,


    [Required(ErrorMessage = "O campo \"Descrição\" deve ser preenchido.")]
    string Descricao,


    [Required(ErrorMessage = "A classificação deve ser selecionada.")]
    Classificacao Classificacao
);



public record EditarNivelDeDificuldadeViewModel(
    Guid Id,


    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 50 caracteres.")]
    string Nome,


    [Required(ErrorMessage = "O campo \"Descrição\" deve ser preenchido.")]
    string Descricao,


    [Required(ErrorMessage = "A classificação deve ser selecionada.")]
    Classificacao Classificacao
);



public record ExcluirNivelDeDificuldadeViewModel(
    Guid Id,
    string Nome,
    string? Descricao,
    Classificacao Classificacao
);

