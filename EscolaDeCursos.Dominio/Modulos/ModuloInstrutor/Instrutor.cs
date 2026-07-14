using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio.Modulos.ModuloInstrutor;

public class Instrutor : EntidadeBase<Instrutor>
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;

    public Instrutor() { }

    public Instrutor(string nome, string telefone, string email, string cpf)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
        Cpf = cpf;
    }

    public override void Atualizar(Instrutor entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Telefone = entidadeAtualizada.Telefone;
        Email = entidadeAtualizada.Email;
        Cpf = entidadeAtualizada.Cpf;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O campo \"Nome\" é obrigatório.");
        else if (Nome.Length < 2 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 2 e 100 caracteres.");

        if (string.IsNullOrWhiteSpace(Email))
            erros.Add("O campo \"E-mail\" é obrigatório.");
        else if (!Email.Contains('@') || !Email.Contains('.'))
            erros.Add("Informe um e-mail válido.");

        if (string.IsNullOrWhiteSpace(Telefone))
            erros.Add("O campo \"Telefone\" é obrigatório.");
        else
        {
            string telefoneDigitos = new string(Telefone.Where(char.IsDigit).ToArray());
            if (telefoneDigitos.Length < 10 || telefoneDigitos.Length > 11)
                erros.Add("O telefone deve conter entre 10 e 11 dígitos.");
        }

        if (string.IsNullOrWhiteSpace(Cpf))
            erros.Add("O campo \"CPF\" é obrigatório.");
        else
        {
            string cpfDigitos = new string(Cpf.Where(char.IsDigit).ToArray());
            if (cpfDigitos.Length != 11)
                erros.Add("O CPF deve conter 11 dígitos.");
        }

        return erros;
    }
}