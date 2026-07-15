namespace EscolaDeCursos.Aplicacao.Modulos.ModuloInstrutor;

public record ListarInstrutorDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string Cpf
);

public record CadastrarInstrutorDto(
    string Nome,
    string Telefone,
    string Email,
    string Cpf
);

public record EditarInstrutorDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string Cpf
);

public record DetalhesInstrutorDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string Cpf
);

public record OpcaoInstrutorDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string Cpf
);



