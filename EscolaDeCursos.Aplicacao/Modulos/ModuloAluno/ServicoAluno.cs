


using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;

public class ServicoAluno : ServicoBase<Aluno>
{
    private readonly IRepositorioAluno repositorioAluno;
    private readonly IRepositorioMatricula repositorioMatricula;

    public ServicoAluno(IRepositorioAluno repositorioAluno, IRepositorioMatricula repositorioMatricula)
    {
        this.repositorioAluno = repositorioAluno;
        this.repositorioMatricula = repositorioMatricula;
    }

    public Result Cadastrar(CadastrarAlunoDto dto)
    {
        if(ExisteAlunoComMesmoEmail(dto.Email))
     
            return Falha(nameof(dto.Email), "Já existe um aluno com este e-mail.");

        Aluno novoAluno = new Aluno(dto.Nome, dto.Telefone, dto.Email);

        Result resultadoValidacao = ValidarEntidade(novoAluno); 

        if(resultadoValidacao.IsFailed)
            return resultadoValidacao;
        
        repositorioAluno.Cadastrar(novoAluno);
        return Result.Ok();
    }

    public Result Editar(EditarAlunoDto dto)
    {
        if (ExisteAlunoComMesmoEmail(dto.Email, dto.Id))
            return Falha(nameof(dto.Email), "Já existe um aluno com este e-mail.");

        Aluno alunoAtualizada = new Aluno(dto.Nome, dto.Telefone, dto.Email);

        Result resultadoValidacao = ValidarEntidade(alunoAtualizada);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        bool conseguiuEditar = repositorioAluno.Editar(dto.Id, alunoAtualizada);

        if (!conseguiuEditar)
            return Falha(string.Empty, "Aluno não encontrado.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Aluno? aluno = repositorioAluno.SelecionarPorId(id);

        if(aluno == null)
            return Falha(string.Empty, "Aluno não encontrado.");
        
        if(ComMatriculaAtiva(id))
            return Falha(string.Empty,
            "Aluno possui matrícula activa e não pode ser excluído."
        );

        repositorioAluno.Excluir(id);
        return Result.Ok();
    }

    public List<ListarAlunoDto> SelecionarTodos()
    {
        return repositorioAluno.SelecionarTodos()
            .Select(a => new ListarAlunoDto(
                a.Id,
                a.Nome,
                a.Telefone,
                a.Email
            ))
            .ToList();
    }

    public Result<DetalhesAlunoDto> SelecionarPorId(Guid id){
        
        Aluno? aluno = repositorioAluno.SelecionarPorId(id);

        if(aluno == null)
            return Result.Fail("aluno não encontrado.");

        return Result.Ok(new DetalhesAlunoDto(
            aluno.Id,
            aluno.Nome,
            aluno.Telefone,
            aluno.Email
        ));
    }

    public List<OpcaoAlunoDto> SelecionarOpcoes()
    {
        return repositorioAluno.SelecionarTodos()
        .Select(a => new OpcaoAlunoDto(
            a.Id,
            a.Nome,
            a.Telefone,
            a.Email
        ))
        .ToList();
    }

    private bool ComMatriculaAtiva(Guid alunoId)
    {
        return repositorioMatricula.SelecionarTodos()
            .Any(m => m.Aluno.Id == alunoId && m.Situacao == SituacaoMatricula.Ativa);
    }

    private bool ExisteAlunoComMesmoEmail(string email, Guid? id = null)
    {
        return repositorioAluno.SelecionarTodos()
            .Any(a => a.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && a.Id != id); //testear
    }

    public List<ListarAlunoDto> PesquisarPorNome(string nome)
    {
        string nomeNormalizado = nome.Trim().ToLower();

        return repositorioAluno
            .Filtrar(a => a.Nome.ToLower().Contains(nomeNormalizado))
            .Select(a => new ListarAlunoDto(
                a.Id,
                a.Nome,
                a.Telefone,
                a.Email
            ))
            .ToList();
    }

}