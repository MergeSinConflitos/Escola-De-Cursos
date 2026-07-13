using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Dominio.Modulos.ModuloEtapa;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloEtapa;

public class ServicoEtapa : ServicoBase<Etapa>
{
    private readonly IRepositorioEtapa repositorioEtapa;
    private readonly IRepositorioCurso repositorioCurso;


    public ServicoEtapa(
        IRepositorioEtapa repositorioEtapa,
        IRepositorioCurso repositorioCurso)
    {
        this.repositorioEtapa = repositorioEtapa;
        this.repositorioCurso = repositorioCurso;
    }



    public Result Cadastrar(CadastrarEtapaDto dto)
    {
        Curso? curso =
            repositorioCurso.SelecionarPorId(dto.CursoId);


        if (curso == null)
            return Falha(nameof(dto.CursoId), "Curso não encontrado.");



        Etapa novaEtapa = new(
            dto.Nome,
            dto.Duracao,
            dto.Ordem,
            curso
        );



        Result resultadoValidacao =
            ValidarEntidade(novaEtapa);



        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;



        repositorioEtapa.Cadastrar(novaEtapa);


        return Result.Ok();
    }




    public Result Editar(EditarEtapaDto dto)
    {
        Curso? curso =
            repositorioCurso.SelecionarPorId(dto.CursoId);


        if (curso == null)
            return Falha(nameof(dto.CursoId), "Curso não encontrado.");



        Etapa etapaAtualizada = new(
            dto.Nome,
            dto.Duracao,
            dto.Ordem,
            curso
        );



        Result resultadoValidacao =
            ValidarEntidade(etapaAtualizada);



        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;



        bool conseguiuEditar =
            repositorioEtapa.Editar(dto.Id, etapaAtualizada);



        if (!conseguiuEditar)
            return Falha(string.Empty, "Etapa não encontrada.");



        return Result.Ok();
    }




    public Result Excluir(Guid id)
    {
        Etapa? etapa =
            repositorioEtapa.SelecionarPorId(id);



        if (etapa == null)
            return Falha(string.Empty, "Etapa não encontrada.");



        repositorioEtapa.Excluir(id);



        return Result.Ok();
    }





    public List<ListarEtapasDto> SelecionarTodos()
    {
        return repositorioEtapa
            .SelecionarTodos()
            .Select(e => new ListarEtapasDto(
                e.Id,
                e.Nome,
                e.Duracao,
                e.Ordem,
                e.Curso.Id,
                e.Curso.Nome
            ))
            .ToList();
    }





    public Result<DetalhesEtapaDto> SelecionarPorId(Guid id)
    {
        Etapa? etapa =
            repositorioEtapa.SelecionarPorId(id);



        if (etapa == null)
            return Result.Fail("Etapa não encontrada.");



        return Result.Ok(
            new DetalhesEtapaDto(
                etapa.Id,
                etapa.Nome,
                etapa.Duracao,
                etapa.Ordem,
                etapa.Curso.Id,
                etapa.Curso.Nome
            )
        );
    }





    public List<ListarEtapasDto> SelecionarPorCurso(Guid cursoId)
    {
        return repositorioEtapa
            .Filtrar(e => e.Curso.Id == cursoId)
            .Select(e => new ListarEtapasDto(
                e.Id,
                e.Nome,
                e.Duracao,
                e.Ordem,
                e.Curso.Id,
                e.Curso.Nome
            ))
            .ToList();
    }




    private bool ExisteEtapaComMesmoNome(
        string nome,
        Guid cursoId,
        Guid? idIgnorado = null)
    {
        string nomeNormalizado =
            nome.Trim().ToLower();



        return repositorioEtapa
            .Filtrar(e => e.Curso.Id == cursoId)
            .Any(e =>
                e.Id != idIgnorado &&
                e.Nome.Trim().ToLower() == nomeNormalizado
            );
    }
}