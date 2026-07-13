using System;

using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Aplicacao.Modulos.ModuloEtapa;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Dominio.Modulos.ModuloNivelDeDificuldade;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;

public class ServicoCurso : ServicoBase<Curso>
{
    private readonly IRepositorioCurso repositorioCurso;
    private readonly IRepositorioCategoria repositorioCategoria;
    private readonly IRepositorioNivelDeDificuldade repositorioNivelDeDificuldade;
    //private readonly IRepositorioTurma repositorioTurma;

    public ServicoCurso(
        IRepositorioCurso repositorioCurso,
        IRepositorioCategoria repositorioCategoria,
        IRepositorioNivelDeDificuldade repositorioNivelDeDificuldade)
    //IRepositorioTurma repositorioTurma)
    {
        this.repositorioCurso = repositorioCurso;
        this.repositorioCategoria = repositorioCategoria;
        this.repositorioNivelDeDificuldade = repositorioNivelDeDificuldade;
        //this.repositorioTurma = repositorioTurma;
    }

    public Result Cadastrar(CadastrarCursoDto dto)
    {
        if (ExisteCursoComMesmoNome(dto.Nome))
            return Falha(nameof(dto.Nome), "Já existe um curso com este nome.");

        Categoria? categoria = repositorioCategoria.SelecionarPorId(dto.CategoriaId);

        if (categoria == null)
            return Falha(nameof(dto.CategoriaId), "Categoria não encontrada.");

        NivelDeDificuldade? nivel =
            repositorioNivelDeDificuldade.SelecionarPorId(dto.NivelDeDificuldadeId);

        if (nivel == null)
            return Falha(nameof(dto.NivelDeDificuldadeId), "Nível de dificuldade não encontrado.");

        Curso novoCurso = new(
            dto.Nome,
            dto.CargaHoraria,
            categoria,
            nivel
        );

        Result resultadoValidacao = ValidarEntidade(novoCurso);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioCurso.Cadastrar(novoCurso);

        return Result.Ok();
    }

    public Result Editar(EditarCursoDto dto)
    {
        if (ExisteCursoComMesmoNome(dto.Nome, dto.Id))
            return Falha(nameof(dto.Nome), "Já existe um curso com este nome.");

        Categoria? categoria = repositorioCategoria.SelecionarPorId(dto.CategoriaId);

        if (categoria == null)
            return Falha(nameof(dto.CategoriaId), "Categoria não encontrada.");

        NivelDeDificuldade? nivel =
            repositorioNivelDeDificuldade.SelecionarPorId(dto.NivelDeDificuldadeId);

        if (nivel == null)
            return Falha(nameof(dto.NivelDeDificuldadeId), "Nível de dificuldade não encontrada.");

        Curso cursoAtualizado = new(
            dto.Nome,
            dto.CargaHoraria,
            categoria,
            nivel
        );

        Result resultadoValidacao = ValidarEntidade(cursoAtualizado);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        bool conseguiuEditar = repositorioCurso.Editar(dto.Id, cursoAtualizado);

        if (!conseguiuEditar)
            return Falha(string.Empty, "Curso não encontrado.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Curso? curso = repositorioCurso.SelecionarPorId(id);

        if (curso == null)
            return Falha(string.Empty, "Curso não encontrado.");

        /*
        if (PossuiTurmasVinculadas(id))
            return Falha(
                string.Empty,
                "Não é possível excluir este curso, pois existem turmas cadastradas."
            );
        */

        repositorioCurso.Excluir(id);

        return Result.Ok();
    }

    public List<ListarCursosDto> SelecionarTodos()
    {
        return repositorioCurso
     .SelecionarTodos()
     .Select(c => new ListarCursosDto(
         c.Id,
         c.Nome,
         c.CargaHoraria,
         c.Categoria.Nome,
         c.NivelDeDificuldade.Nome
     ))
     .ToList();
    }

    public Result<DetalhesCursoDto> SelecionarPorId(Guid id)
    {
        Curso? curso = repositorioCurso.SelecionarPorId(id);

        if (curso == null)
            return Result.Fail("Curso não encontrado.");

        return Result.Ok(
            new DetalhesCursoDto(
                curso.Id,
                curso.Nome,
                curso.CargaHoraria,
                curso.Categoria.Id,
                curso.Categoria.Nome,
                curso.NivelDeDificuldade.Id,
                curso.NivelDeDificuldade.Nome
            )
        );
    }

    public List<OpcaoCursoDto> SelecionarOpcoes()
    {
        return repositorioCurso
            .SelecionarTodos()
            .Select(c => new OpcaoCursoDto(
                c.Id,
                c.Nome
            ))
            .ToList();
    }

    public List<ListarCursosDto> PesquisarPorNome(string nome)
    {
        string nomeNormalizado = nome.Trim().ToLower();

        return repositorioCurso
            .Filtrar(c => c.Nome.ToLower().Contains(nomeNormalizado))
             .Select(c => new ListarCursosDto(
         c.Id,
         c.Nome,
         c.CargaHoraria,
         c.Categoria.Nome,
         c.NivelDeDificuldade.Nome
     ))
     .ToList();
    }

    public List<ListarCursosDto> Pesquisar(
     string? nome,
     Guid? categoriaId,
     Guid? nivelDeDificuldadeId)
    {
        List<Curso> cursos = repositorioCurso.SelecionarTodos();


        if (!string.IsNullOrWhiteSpace(nome))
        {
            string nomeNormalizado = nome.Trim().ToLower();

            cursos = cursos
                .Where(c => c.Nome.ToLower().Contains(nomeNormalizado))
                .ToList();
        }


        if (categoriaId.HasValue)
        {
            cursos = cursos
                .Where(c => c.Categoria.Id == categoriaId.Value)
                .ToList();
        }


        if (nivelDeDificuldadeId.HasValue)
        {
            cursos = cursos
                .Where(c => c.NivelDeDificuldade.Id == nivelDeDificuldadeId.Value)
                .ToList();
        }


        return cursos
            .Select(c => new ListarCursosDto(
                c.Id,
                c.Nome,
                c.CargaHoraria,
                c.Categoria.Nome,
                c.NivelDeDificuldade.Nome
            ))
            .ToList();
    }

    private bool ExisteCursoComMesmoNome(string nome, Guid? idIgnorado = null)
    {
        string nomeNormalizado = NormalizarNome(nome);

        return repositorioCurso
            .SelecionarTodos()
            .Any(c =>
                c.Id != idIgnorado &&
                NormalizarNome(c.Nome) == nomeNormalizado);
    }

    /*
    private bool PossuiTurmasVinculadas(Guid cursoId)
    {
        return repositorioTurma
            .SelecionarTodos()
            .Any(t => t.Curso.Id == cursoId);
    }
    */

    private static string NormalizarNome(string nome)
    {
        return nome.Trim().ToLowerInvariant();
    }
}
