using System;
using System.Collections.Generic;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;


public record ListarTurmasDto(
    Guid Id,
    string Nome,
    string Periodo,      // Se muestra el nombre del enum (ej: "Manhã")
    DateTime DataInicio,
    DateTime DataTermino,
    int QuantidadeMaxAlunos,
    string CursoNome,
    string InstrutorNome,
    int TotalAlunosMatriculados,
    bool EstaCheia
);


public record CadastrarTurmaDto(
    string Nome,
    int Periodo, 
    DateTime DataInicio,
    DateTime DataTermino,
    int QuantidadeMaxAlunos,
    Guid CursoId,
    Guid InstrutorId
);


public record EditarTurmaDto(
    Guid Id,
    string Nome,
    int Periodo,
    DateTime DataInicio,
    DateTime DataTermino,
    int QuantidadeMaxAlunos,
    Guid CursoId,
    Guid InstrutorId
);


public record DetalhesTurmaDto(
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
    List<AlunoMatriculadoDto> AlunosMatriculados
);


public record AlunoMatriculadoDto(
    Guid Id,
    string Nome,
    string Email,
    DateTime DataMatricula,
    string Status
);

public record OpcaoTurmaDto(
    Guid Id,
    string Nome
);