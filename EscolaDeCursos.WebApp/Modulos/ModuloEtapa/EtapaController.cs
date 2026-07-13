using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloEtapa;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloEtapa;

public class EtapaController(
    ServicoEtapa servicoEtapa,
    ServicoCurso servicoCurso,
    IMapper mapeador) : Controller
{

    [HttpGet]
    public ActionResult Listar(
    string pesquisa,
    Guid? cursoId)
    {
        List<ListarEtapasDto> dtos =
            servicoEtapa.Pesquisar(
                pesquisa,
                cursoId
            );


        List<ListarEtapasViewModel> vms =
            mapeador.Map<List<ListarEtapasViewModel>>(dtos);


        ViewBag.Pesquisa = pesquisa;
        ViewBag.CursoId = cursoId;

        ViewBag.Cursos = CarregarCursos();


        return View(vms);
    }



    [HttpGet]
    public ActionResult Cadastrar(Guid cursoId)
    {
        CadastrarEtapaViewModel vm =
            new(
                string.Empty,
                0,
                0,
                cursoId,
                CarregarCursos()
            );


        return View(vm);
    }



    [HttpPost]
    public ActionResult Cadastrar(CadastrarEtapaViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
        {
            cadastrarVm = cadastrarVm with
            {
                Cursos = CarregarCursos()
            };

            return View(cadastrarVm);
        }


        CadastrarEtapaDto dto =
            mapeador.Map<CadastrarEtapaDto>(cadastrarVm);



        Result resultado =
            servicoEtapa.Cadastrar(dto);



        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);


            cadastrarVm = cadastrarVm with
            {
                Cursos = CarregarCursos()
            };


            return View(cadastrarVm);
        }



        return RedirectToAction(nameof(Listar));
    }





    [HttpGet]
    public ActionResult Editar(Guid id)
    {
        Result<DetalhesEtapaDto> resultado =
            servicoEtapa.SelecionarPorId(id);



        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }



        EditarEtapaViewModel vm =
            mapeador.Map<EditarEtapaViewModel>(resultado.Value);



        vm = vm with
        {
            Cursos = CarregarCursos()
        };


        return View(vm);
    }





    [HttpPost]
    public ActionResult Editar(EditarEtapaViewModel editarVm)
    {
        if (!ModelState.IsValid)
        {
            editarVm = editarVm with
            {
                Cursos = CarregarCursos()
            };

            return View(editarVm);
        }



        EditarEtapaDto dto =
            mapeador.Map<EditarEtapaDto>(editarVm);



        Result resultado =
            servicoEtapa.Editar(dto);



        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);


            editarVm = editarVm with
            {
                Cursos = CarregarCursos()
            };


            return View(editarVm);
        }



        return RedirectToAction(nameof(Listar));
    }





    [HttpGet]
    public ActionResult Excluir(Guid id)
    {
        Result<DetalhesEtapaDto> resultado =
            servicoEtapa.SelecionarPorId(id);



        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }



        ExcluirEtapaViewModel vm =
            mapeador.Map<ExcluirEtapaViewModel>(resultado.Value);



        return View(vm);
    }





    [HttpPost]
    public ActionResult Excluir(ExcluirEtapaViewModel excluirVm)
    {
        Result resultado =
            servicoEtapa.Excluir(excluirVm.Id);



        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);



        return RedirectToAction(nameof(Listar));
    }





    private List<OpcaoCursoViewModel> CarregarCursos()
    {
        return servicoCurso
            .SelecionarOpcoes()
            .Select(c => new OpcaoCursoViewModel(
                c.Id,
                c.Nome
            ))
            .ToList();
    }
}