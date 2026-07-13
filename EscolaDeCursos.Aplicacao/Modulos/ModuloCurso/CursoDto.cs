using System;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;

public record ListarCursosDto(
    Guid Id,
    string Nome,
    int CargaHoraria,
    Guid CategoriaId,
    string CategoriaNome,
    Guid NivelDeDificuldadeId,
    string NivelDeDificuldadeNome
);

public record CadastrarCursoDto(
    string Nome,
    int CargaHoraria,
    Guid CategoriaId,
    Guid NivelDeDificuldadeId
);

public record EditarCursoDto(
    Guid Id,
    string Nome,
    int CargaHoraria,
    Guid CategoriaId,
    Guid NivelDeDificuldadeId
);

public record DetalhesCursoDto(
    Guid Id,
    string Nome,
    int CargaHoraria,
    Guid CategoriaId,
    string CategoriaNome,
    Guid NivelDeDificuldadeId,
    string NivelDeDificuldadeNome
);
