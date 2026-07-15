namespace EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;

public record ListarAlunoDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email
);

public record CadastrarAlunoDto(
    string Nome,
    string Telefone,
    string Email
);

public record EditarAlunoDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email
);

public record DetalhesAlunoDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email
);

public record OpcaoAlunoDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email
);