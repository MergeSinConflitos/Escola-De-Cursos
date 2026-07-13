using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;
using EscolaDeCursos.Aplicacao.Modulos.ModuloNivelDeDificuldade;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso;

public class CursoController(
    ServicoCurso servicoCurso,
    ServicoCategoria servicoCategoria,
    ServicoNivelDeDificuldade servicoNivelDeDificuldade,
    IMapper mapeador) : Controller
{
    [HttpGet]
    public ActionResult Listar(
      string pesquisa,
      Guid? categoriaId,
      Guid? nivelDeDificuldadeId)
    {
        List<ListarCursosDto> dtos =
            servicoCurso.Pesquisar(
                pesquisa,
                categoriaId,
                nivelDeDificuldadeId
            );


        List<ListarCursosViewModel> vms =
            mapeador.Map<List<ListarCursosViewModel>>(dtos);


        ViewBag.Pesquisa = pesquisa;
        ViewBag.CategoriaId = categoriaId;
        ViewBag.NivelDeDificuldadeId = nivelDeDificuldadeId;


        ViewBag.Categorias = CarregarCategorias();
        ViewBag.NiveisDeDificuldade = CarregarNiveisDeDificuldade();


        return View(vms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarCursoViewModel cadastrarVm = new(
            string.Empty,
            0,
            null,
            null,
            CarregarCategorias(),
            CarregarNiveisDeDificuldade());

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarCursoViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
        {
            cadastrarVm = cadastrarVm with
            {
                Categorias = CarregarCategorias(),
                NiveisDeDificuldade = CarregarNiveisDeDificuldade()
            };

            return View(cadastrarVm);
        }

        CadastrarCursoDto dto =
            mapeador.Map<CadastrarCursoDto>(cadastrarVm);

        Result resultado =
            servicoCurso.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            cadastrarVm = cadastrarVm with
            {
                Categorias = CarregarCategorias(),
                NiveisDeDificuldade = CarregarNiveisDeDificuldade()
            };

            return View(cadastrarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(Guid id)
    {
        Result<DetalhesCursoDto> resultado =
            servicoCurso.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        EditarCursoViewModel editarVm =
            mapeador.Map<EditarCursoViewModel>(resultado.Value);

        editarVm = editarVm with
        {
            Categorias = CarregarCategorias(),
            NiveisDeDificuldade = CarregarNiveisDeDificuldade()
        };

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarCursoViewModel editarVm)
    {
        if (!ModelState.IsValid)
        {
            editarVm = editarVm with
            {
                Categorias = CarregarCategorias(),
                NiveisDeDificuldade = CarregarNiveisDeDificuldade()
            };

            return View(editarVm);
        }

        EditarCursoDto dto =
            mapeador.Map<EditarCursoDto>(editarVm);

        Result resultado =
            servicoCurso.Editar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            editarVm = editarVm with
            {
                Categorias = CarregarCategorias(),
                NiveisDeDificuldade = CarregarNiveisDeDificuldade()
            };

            return View(editarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(Guid id)
    {
        Result<DetalhesCursoDto> resultado =
            servicoCurso.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        ExcluirCursoViewModel excluirVm =
            mapeador.Map<ExcluirCursoViewModel>(resultado.Value);

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirCursoViewModel excluirVm)
    {
        Result resultado =
            servicoCurso.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }

    private List<OpcaoCategoriaViewModel> CarregarCategorias()
    {
        return mapeador.Map<List<OpcaoCategoriaViewModel>>(
            servicoCategoria.SelecionarOpcoes());
    }

    private List<OpcaoNivelDeDificuldadeViewModel> CarregarNiveisDeDificuldade()
    {
        return mapeador.Map<List<OpcaoNivelDeDificuldadeViewModel>>(
            servicoNivelDeDificuldade.SelecionarOpcoes());
    }
}
