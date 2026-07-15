using System.ComponentModel.DataAnnotations;

namespace EscolaDeCursos.WebApp.Modulos.ModuloInstrutor;

public record ListarInstrutorViewModel(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string Cpf
);

public record CadastrarInstrutorViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Telefone\" deve ser preenchido.")]
    [Phone(ErrorMessage = "O campo \"Telefone\" deve ser um número de telefone válido.")]
    string Telefone,

    [Required(ErrorMessage = "O campo \"Email\" deve ser preenchido.")]
    [EmailAddress(ErrorMessage = "O campo \"Email\" deve ser um endereço de email válido.")]
    string Email,

    [Required(ErrorMessage = "O campo CPF é obrigatório")]
    [RegularExpression(
      @"^\d{11}$",
        ErrorMessage = "CPF inválido, deve ter 11 digitos")]
    string Cpf

);

public record EditarInstrutorViewModel(
    Guid Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Telefone\" deve ser preenchido.")]
    [Phone(ErrorMessage = "O campo \"Telefone\" deve ser um número de telefone válido.")]
    string Telefone,

    [Required(ErrorMessage = "O campo \"Email\" deve ser preenchido.")]
    [EmailAddress(ErrorMessage = "O campo \"Email\" deve ser um endereço de email válido.")]
    string Email,

    [Required(ErrorMessage = "O campo CPF é obrigatório")]
    [RegularExpression(
      @"^\d{11}$",
        ErrorMessage = "CPF inválido, deve ter 11 digitos")]
    string Cpf

);

public record ExcluirInstrutorViewModel(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string Cpf
);