using System.ComponentModel;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloInstrutor;
using EscolaDeCursos.Dominio.Modulos.ModuloTuma;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloInstrutor;

public class ServicoInstrutor : ServicoBase<Instrutor>
{
    private readonly IRepositorioInstrutor repositorioInstrutor;
    private readonly IRepositorioTurma repositorioTurma;

    public ServicoInstrutor(IRepositorioInstrutor repositorioInstrutor, IRepositorioTurma repositorioTurma)
    {
        this.repositorioInstrutor = repositorioInstrutor;
        this.repositorioTurma = repositorioTurma;
    }

    public Result Cadastrar(CadastrarInstrutorDto dto)
    {
        if (ExisteInstrutorMesmoCpf(dto.Cpf))
            return Falha(nameof(dto.Cpf), "Já existe um CPF registrado.");

        Instrutor novoInstrutor = new Instrutor(dto.Nome, dto.Telefone, dto.Email, dto.Cpf);

        Result resultadoValidacao = ValidarEntidade(novoInstrutor);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioInstrutor.Cadastrar(novoInstrutor);
        return Result.Ok();
    }

    public Result Editar(EditarInstrutorDto dto)
    {
        if (ExisteInstrutorMesmoCpf(dto.Cpf, dto.Id))
            return Falha(nameof(dto.Cpf), "Já existe um CPF registrado.");

        Instrutor instrutorAtualizado = new Instrutor(dto.Nome, dto.Telefone, dto.Email, dto.Cpf);

        Result resultadoValidacao = ValidarEntidade(instrutorAtualizado);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        bool conseguiuEditar = repositorioInstrutor.Editar(dto.Id, instrutorAtualizado);

        if (!conseguiuEditar)
            return Falha(string.Empty, "Instrutor não encontrado.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Instrutor? instrutor = repositorioInstrutor.SelecionarPorId(id);

        if (instrutor == null)
            return Falha(string.Empty, "Instrutor não encontrado.");

        if (ComTurma(id))
            return Falha(string.Empty, "Não é possível excluir instrutor com turmas vinculadas");

        repositorioInstrutor.Excluir(id);
        return Result.Ok();
    }

    public List<ListarInstrutorDto> SelecionarTodos()
    {
        return repositorioInstrutor.SelecionarTodos()
            .Select(i => new ListarInstrutorDto(
                i.Id,
                i.Nome,
                i.Telefone,
                i.Email,
                i.Cpf
            ))
        .ToList();
    }

    public Result<DetalhesInstrutorDto> SelecionarPorId(Guid id)
    {

        Instrutor? instrutor = repositorioInstrutor.SelecionarPorId(id);

        if (instrutor == null)
            return Result.Fail("Instrutor não encontrado.");

        return Result.Ok(new DetalhesInstrutorDto(
            instrutor.Id,
            instrutor.Nome,
            instrutor.Telefone,
            instrutor.Email,
            instrutor.Cpf
        ));
    }

    public List<ListarInstrutorDto> PesquisarPorNome(string nome)
    {
        string nomeNormalizado = nome.Trim().ToLower();

        return repositorioInstrutor
            .Filtrar(i => i.Nome.ToLower().Contains(nomeNormalizado))
            .Select(i => new ListarInstrutorDto(
                i.Id,
                i.Nome,
                i.Telefone,
                i.Email,
                i.Cpf
            ))
            .ToList();
    }

    public List<OpcaoInstrutorDto> SelecionarOpcoes()
    {
        return repositorioInstrutor.SelecionarTodos()
        .Select(i => new OpcaoInstrutorDto(
            i.Id,
            i.Nome,
            i.Telefone,
            i.Email,
            i.Cpf
        ))
        .ToList();
    }

    private bool ComTurma(Guid instrutorId)
    {
        return repositorioTurma.SelecionarTodos()
            .Any(t => t.Instrutor != null && t.Instrutor.Id == instrutorId);
    }

    private bool ExisteInstrutorMesmoCpf(string cpf, Guid? id = null)
    {
        return repositorioInstrutor.SelecionarTodos()
            .Any(i => i.Cpf == cpf && i.Id != id);
    }
}