using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using EscolaDeCursos.Dominio.Modulos.ModuloTuma;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloMatricula;

public class ServicoMatricula : ServicoBase<Matricula>
{
    private readonly IRepositorioMatricula repositorioMatricula;
    private readonly IRepositorioAluno repositorioAluno;
    private readonly IRepositorioTurma repositorioTurma;

    public ServicoMatricula(
        IRepositorioMatricula repositorioMatricula,
        IRepositorioAluno repositorioAluno,
        IRepositorioTurma repositorioTurma)
    {
        this.repositorioMatricula = repositorioMatricula;
        this.repositorioAluno = repositorioAluno;
        this.repositorioTurma = repositorioTurma;
    }

    public Result Cadastrar(CadastrarMatriculaDto dto)
    {
        
        Aluno? aluno = repositorioAluno.SelecionarPorId(dto.AlunoId);

        if (aluno == null)
            return Falha(nameof(dto.AlunoId), "Aluno não encontrado.");

        
        Turma? turma = repositorioTurma.SelecionarPorId(dto.TurmaId);

        if (turma == null)
            return Falha(nameof(dto.TurmaId), "Turma não encontrada.");

        
        if (!Enum.IsDefined(typeof(SituacaoMatricula), dto.Situacao))
            return Falha(nameof(dto.Situacao), "Situação inválida.");

        
        Matricula novaMatricula = new(aluno, turma)
        {
            DataInscricao = dto.DataInscricao,
            Situacao = (SituacaoMatricula)dto.Situacao
        };

        
        Result resultadoValidacao = ValidarEntidade(novaMatricula);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioMatricula.Cadastrar(novaMatricula);

        return Result.Ok();
    }

    public Result Editar(EditarMatriculaDto dto)
    {
        Matricula? matricula = repositorioMatricula.SelecionarPorId(dto.Id);

        if (matricula == null)
            return Falha(string.Empty, "Matrícula não encontrada.");


        if (!Enum.IsDefined(typeof(SituacaoMatricula), dto.Situacao))
            return Falha(nameof(dto.Situacao), "Situação inválida.");

    
        matricula.Situacao = (SituacaoMatricula)dto.Situacao;

        Result resultadoValidacao = ValidarEntidade(matricula);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioMatricula.Editar(dto.Id, matricula);

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Matricula? matricula = repositorioMatricula.SelecionarPorId(id);

        if (matricula == null)
            return Falha(string.Empty, "Matrícula não encontrada.");

    
        if (matricula.Situacao != SituacaoMatricula.Ativa)
            return Falha(string.Empty, "Apenas matrículas ativas podem ser canceladas.");

        matricula.Cancelar();
        
        repositorioMatricula.Editar(id, matricula);

        return Result.Ok();
    }

    public List<ListarMatriculasDto> SelecionarTodos()
    {
        var matriculas = repositorioMatricula.SelecionarTodos();

        return matriculas.Select(m => new ListarMatriculasDto(
            m.Id,
            m.DataInscricao,
            m.Situacao.ToString(),
            m.Aluno.Nome,
            m.Turma.Nome,
            m.Turma.Curso.Nome,
            m.Turma.Instrutor.Nome
        )).ToList();
    }

    public List<ListarMatriculasDto> SelecionarPorAluno(Guid alunoId)
    {
        
        var matriculas = repositorioMatricula.SelecionarTodos()
            .Where(m => m.Aluno.Id == alunoId)
            .ToList();

        return matriculas.Select(m => new ListarMatriculasDto(
            m.Id,
            m.DataInscricao,
            m.Situacao.ToString(),
            m.Aluno.Nome,
            m.Turma.Nome,
            m.Turma.Curso.Nome,
            m.Turma.Instrutor.Nome
        )).ToList();
    }

    public List<ListarMatriculasDto> SelecionarPorTurma(Guid turmaId)
    {
        
        var matriculas = repositorioMatricula.SelecionarTodos()
            .Where(m => m.Turma.Id == turmaId)
            .ToList();

        return matriculas.Select(m => new ListarMatriculasDto(
            m.Id,
            m.DataInscricao,
            m.Situacao.ToString(),
            m.Aluno.Nome,
            m.Turma.Nome,
            m.Turma.Curso.Nome,
            m.Turma.Instrutor.Nome
        )).ToList();
    }

    public Result<DetalhesMatriculaDto> SelecionarPorId(Guid id)
    {
        Matricula? matricula = repositorioMatricula.SelecionarPorId(id);
        
        if (matricula == null)
            return Result.Fail("Matrícula não encontrada.");

        return Result.Ok(new DetalhesMatriculaDto(
            matricula.Id,
            matricula.DataInscricao,
            matricula.Situacao.ToString(),
            matricula.Aluno.Id,
            matricula.Aluno.Nome,
            matricula.Aluno.Email,
            matricula.Turma.Id,
            matricula.Turma.Nome,
            matricula.Turma.Curso.Nome
        ));
    }

    public List<OpcaoAlunoDto> SelecionarOpcoesAlunos()
    {
        return repositorioAluno.SelecionarTodos()
            .Select(a => new OpcaoAlunoDto(a.Id, a.Nome))
            .ToList();
    }

    public List<OpcaoTurmaDto> SelecionarOpcoesTurmas()
    {
        return repositorioTurma.SelecionarTodos()
            .Select(t => new OpcaoTurmaDto(t.Id, t.Nome))
            .ToList();
    }
}