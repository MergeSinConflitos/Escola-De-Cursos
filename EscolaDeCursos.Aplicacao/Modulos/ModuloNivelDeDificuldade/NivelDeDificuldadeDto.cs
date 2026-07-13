using System;
using EscolaDeCursos.Dominio.Modulos.ModuloNivelDeDificuldade;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloNivelDeDificuldade;

public record ListarNivelDeDificuldadeDto(
    Guid Id,
    string Nome,
    string? Descricao,
    Classificacao Classificacao
);


public record CadastrarNivelDeDificuldadeDto(
    string Nome,
    string? Descricao,
    Classificacao Classificacao
);


public record EditarNivelDeDificuldadeDto(
    Guid Id,
    string Nome,
    string? Descricao,
    Classificacao Classificacao
);


public record DetalhesNivelDeDificuldadeDto(
    Guid Id,
    string Nome,
    string? Descricao,
    Classificacao Classificacao
);
