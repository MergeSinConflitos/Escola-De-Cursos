using System;
using System.Collections.Generic;
using System.Linq;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Dominio.Modulos.ModuloInstrutor;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using EscolaDeCursos.Dominio.Modulos.ModuloTuma;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;

public class ServicoTurma : ServicoBase<Turma>
{
    private readonly IRepositorioTurma repositorioTurma;
    private readonly IRepositorioCurso repositorioCurso;
    private readonly IRepositorioInstrutor repositorioInstrutor;

    public ServicoTurma(
        IRepositorioTurma repositorioTurma,
        IRepositorioCurso repositorioCurso,
        IRepositorioInstrutor repositorioInstrutor)
    {
        this.repositorioTurma = repositorioTurma;
        this.repositorioCurso = repositorioCurso;
        this.repositorioInstrutor = repositorioInstrutor;
    }

    
    public Result Cadastrar(CadastrarTurmaDto dto)
    {
        Curso? curso = repositorioCurso.SelecionarPorId(dto.CursoId);

        if (curso == null)
            return Falha(nameof(dto.CursoId), "Curso não encontrado.");

        Instrutor? instrutor = repositorioInstrutor.SelecionarPorId(dto.InstrutorId);
        if (instrutor == null)
            return Falha(nameof(dto.InstrutorId), "Instrutor não encontrado.");

        if (!Enum.IsDefined(typeof(Periodo), dto.Periodo))
            return Falha(nameof(dto.Periodo), "Período inválido.");
        
        Turma novaTurma = new(
            dto.Nome,
            (Periodo)dto.Periodo,
            dto.DataInicio,
            dto.DataTermino,
            dto.QuantidadeMaxAlunos,
            curso,
            instrutor
        );

        Result resultadoValidacao = ValidarEntidade(novaTurma);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioTurma.Cadastrar(novaTurma);
        return Result.Ok();
    }

    public Result Editar(EditarTurmaDto dto)
    {
        Turma? turmaExistente = repositorioTurma.SelecionarPorId(dto.Id);
        
        if (turmaExistente == null)
            return Falha(string.Empty, "Turma não encontrada.");

        Curso? curso = repositorioCurso.SelecionarPorId(dto.CursoId);
        if (curso == null)
            return Falha(nameof(dto.CursoId), "Curso não encontrado.");

        Instrutor? instrutor = repositorioInstrutor.SelecionarPorId(dto.InstrutorId);
        if (instrutor == null)
            return Falha(nameof(dto.InstrutorId), "Instrutor não encontrado.");

        Turma turmaAtualizada = new(
            dto.Nome,
            (Periodo)dto.Periodo,
            dto.DataInicio,
            dto.DataTermino,
            dto.QuantidadeMaxAlunos,
            curso,
            instrutor
        );

        Result resultadoValidacao = ValidarEntidade(turmaAtualizada);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        bool conseguiuEditar = repositorioTurma.Editar(dto.Id, turmaAtualizada);

        if (!conseguiuEditar)
            return Falha(string.Empty, "Erro ao atualizar turma.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Turma? turma = repositorioTurma.SelecionarPorId(id);

        if (turma == null)
            return Falha(string.Empty, "Turma não encontrada.");

        if (turma.PossuiMatriculas())
            return Falha(
                string.Empty, 
                "Não é possível excluir turma com matrículas cadastradas."
            );

        repositorioTurma.Excluir(id);
        return Result.Ok();
    }


    public List<ListarTurmasDto> SelecionarTodos()
    {
        var turmas = repositorioTurma.SelecionarTodos();

        return turmas.Select(t => new ListarTurmasDto(
            t.Id,
            t.Nome,
            t.Periodo.ToString(),
            t.DataInicio,
            t.DataTermino,
            t.QuantidadeMaxAlunos,
            t.Curso.Nome,
            t.Instrutor.Nome,
            t.Matriculas?.Count ?? 0,
            t.EstaCheia() 
        )).ToList();
    }

    
    public Result<DetalhesTurmaDto> SelecionarPorId(Guid id)
    {
        Turma? turma = repositorioTurma.SelecionarPorId(id);

        if (turma == null)
            return Result.Fail("Turma não encontrada.");

        var alunosDto = (turma.Matriculas ?? new List<Matricula>()).Select(m => new AlunoMatriculadoDto(
            m.Id,
            m.Aluno.Nome,
            m.Aluno.Email,
            m.DataInscricao, 
            m.Situacao.ToString() 
        )).ToList();

        return Result.Ok(
            new DetalhesTurmaDto(
                turma.Id,
                turma.Nome,
                (int)turma.Periodo,
                turma.Periodo.ToString(),
                turma.DataInicio,
                turma.DataTermino,
                turma.QuantidadeMaxAlunos,
                turma.Curso.Id,
                turma.Curso.Nome,
                turma.Instrutor.Id,
                turma.Instrutor.Nome,
                alunosDto
            )
        );
    }
}