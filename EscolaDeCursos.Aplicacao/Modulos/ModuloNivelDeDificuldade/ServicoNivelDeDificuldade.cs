using System;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloNivelDeDificuldade;

using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloNivelDeDificuldade;
using FluentResults;

public class ServicoNivelDeDificuldade : ServicoBase<NivelDeDificuldade>
{
    private readonly IRepositorioNivelDeDificuldade repositorioNivelDeDificuldade;
    //private readonly IRepositorioCurso repositorioCurso;


    public ServicoNivelDeDificuldade(
        IRepositorioNivelDeDificuldade repositorioNivelDeDificuldade)
    //  IRepositorioCurso repositorioCurso)
    {
        this.repositorioNivelDeDificuldade = repositorioNivelDeDificuldade;
        //this.repositorioCurso = repositorioCurso;
    }



    public Result Cadastrar(CadastrarNivelDeDificuldadeDto dto)
    {
        if (ExisteNivelComMesmoNome(dto.Nome))
            return Falha(nameof(dto.Nome), "Já existe um nível de dificuldade com este nome.");


        NivelDeDificuldade novoNivel = new NivelDeDificuldade(
            dto.Nome,
            dto.Descricao,
            dto.Classificacao
        );


        Result resultadoValidacao = ValidarEntidade(novoNivel);


        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;


        repositorioNivelDeDificuldade.Cadastrar(novoNivel);


        return Result.Ok();
    }



    public Result Editar(EditarNivelDeDificuldadeDto dto)
    {
        if (ExisteNivelComMesmoNome(dto.Nome, dto.Id))
            return Falha(nameof(dto.Nome), "Já existe um nível de dificuldade com este nome.");


        NivelDeDificuldade nivelAtualizado = new NivelDeDificuldade(
            dto.Nome,
            dto.Descricao,
            dto.Classificacao
        );


        Result resultadoValidacao = ValidarEntidade(nivelAtualizado);


        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;



        bool conseguiuEditar =
            repositorioNivelDeDificuldade.Editar(dto.Id, nivelAtualizado);



        if (!conseguiuEditar)
            return Falha(string.Empty, "Nível de dificuldade não encontrado.");



        return Result.Ok();
    }





    public Result Excluir(Guid id)
    {
        NivelDeDificuldade? nivel =
            repositorioNivelDeDificuldade.SelecionarPorId(id);



        if (nivel == null)
            return Falha(string.Empty, "Nível de dificuldade não encontrado.");


        /*
        if (PossuiCursosVinculados(id))
        {
            return Falha(
                string.Empty,
                "Não é possível excluir este nível de dificuldade, pois existem cursos vinculados."
            );
        }
        */



        repositorioNivelDeDificuldade.Excluir(id);



        return Result.Ok();
    }






    public List<ListarNivelDeDificuldadeDto> SelecionarTodos()
    {
        return repositorioNivelDeDificuldade
            .SelecionarTodos()
            .Select(n => new ListarNivelDeDificuldadeDto(
                n.Id,
                n.Nome,
                n.Descricao,
                n.Classificacao
            ))
            .ToList();
    }






    public Result<DetalhesNivelDeDificuldadeDto> SelecionarPorId(Guid id)
    {
        NivelDeDificuldade? nivel =
            repositorioNivelDeDificuldade.SelecionarPorId(id);



        if (nivel == null)
            return Result.Fail("Nível de dificuldade não encontrado.");



        return Result.Ok(
            new DetalhesNivelDeDificuldadeDto(
                nivel.Id,
                nivel.Nome,
                nivel.Descricao,
                nivel.Classificacao
            )
        );
    }






    public List<ListarNivelDeDificuldadeDto> PesquisarPorNome(string nome)
    {
        string nomeNormalizado = nome.Trim().ToLower();



        return repositorioNivelDeDificuldade
            .Filtrar(n => n.Nome.ToLower().Contains(nomeNormalizado))
            .Select(n => new ListarNivelDeDificuldadeDto(
                n.Id,
                n.Nome,
                n.Descricao,
                n.Classificacao
            ))
            .ToList();
    }


    public List<ListarNivelDeDificuldadeDto> Pesquisar(
    string? nome,
    Classificacao? classificacao)
    {
        List<NivelDeDificuldade> niveis =
            repositorioNivelDeDificuldade.SelecionarTodos();


        if (!string.IsNullOrWhiteSpace(nome))
        {
            string nomeNormalizado = nome.Trim().ToLower();

            niveis = niveis
                .Where(n => n.Nome.ToLower().Contains(nomeNormalizado))
                .ToList();
        }


        if (classificacao.HasValue)
        {
            niveis = niveis
                .Where(n => n.Classificacao == classificacao.Value)
                .ToList();
        }


        return niveis
            .Select(n => new ListarNivelDeDificuldadeDto(
                n.Id,
                n.Nome,
                n.Descricao,
                n.Classificacao
            ))
            .ToList();
    }



    private bool ExisteNivelComMesmoNome(string nome, Guid? idIgnorado = null)
    {
        string nomeNormalizado = nome.Trim().ToLower();



        return repositorioNivelDeDificuldade
            .SelecionarTodos()
            .Any(n =>
                n.Id != idIgnorado &&
                n.Nome.Trim().ToLower() == nomeNormalizado
            );
    }

    /*
    private bool PossuiCursosVinculados(Guid nivelId)
    {
        return repositorioCurso
            .SelecionarTodos()
            .Any(c => c.NivelDeDificuldade.Id == nivelId);
    }
    */
}