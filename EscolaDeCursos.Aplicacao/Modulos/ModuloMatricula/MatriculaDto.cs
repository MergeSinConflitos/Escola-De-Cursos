using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloMatricula;


public record ListarMatriculasDto(
    Guid Id,
    DateTime DataInscricao,
    string Situacao,
    string AlunoNome,
    string TurmaNome,
    string CursoNome, 
    string InstrutorNome
);


public record CadastrarMatriculaDto(
    Guid AlunoId,
    Guid TurmaId,
    DateTime DataInscricao
    
);


public record EditarMatriculaDto(
    Guid Id,
    SituacaoMatricula Situacao
);


public record DetalhesMatriculaDto(
    Guid Id,
    DateTime DataInscricao,
    SituacaoMatricula Situacao,
    Guid AlunoId,
    string AlunoNome,
    string AlunoEmail,
    Guid TurmaId,
    string TurmaNome,
    string CursoNome
);


public record OpcaoAlunoDto(
    Guid Id,
    string Nome
);

public record OpcaoTurmaDto(
    Guid Id, 
    string Nome
);