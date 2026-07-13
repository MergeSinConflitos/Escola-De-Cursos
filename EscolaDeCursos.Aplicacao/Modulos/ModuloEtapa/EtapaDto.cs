using System;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloEtapa;

public record ListarEtapasDto(
    Guid Id,
    string Nome,
    int Duracao,
    int Ordem,
    Guid CursoId,
    string CursoNome
);


public record CadastrarEtapaDto(
    string Nome,
    int Duracao,
    int Ordem,
    Guid CursoId
);


public record EditarEtapaDto(
    Guid Id,
    string Nome,
    int Duracao,
    int Ordem,
    Guid CursoId
);


public record DetalhesEtapaDto(
    Guid Id,
    string Nome,
    int Duracao,
    int Ordem,
    Guid CursoId,
    string CursoNome
);