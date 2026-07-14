using System.ComponentModel.DataAnnotations;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAluno;

public record ListarAlunosViewModel(
    Guid Id,
    string Nome,
    string Telefone,
    string Email
);

public record CadastrarAlunoViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Telefone\" deve ser preenchido.")]
    [Phone(ErrorMessage = "O campo \"Telefone\" deve ser um número de telefone válido.")]
    string Telefone,

    [Required(ErrorMessage = "O campo \"Email\" deve ser preenchido.")]
    [EmailAddress(ErrorMessage = "O campo \"Email\" deve ser um endereço de email válido.")]
    string Email
);

public record EditarAlunoViewModel(
    Guid Id,
 [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Telefone\" deve ser preenchido.")]
    [Phone(ErrorMessage = "O campo \"Telefone\" deve ser um número de telefone válido.")]
    string Telefone,

    [Required(ErrorMessage = "O campo \"Email\" deve ser preenchido.")]
    [EmailAddress(ErrorMessage = "O campo \"Email\" deve ser um endereço de email válido.")]
    string Email
);

public record ExcluirAlunoViewModel(
   Guid Id,
    string Nome,
    string Telefone,
    string Email
);
