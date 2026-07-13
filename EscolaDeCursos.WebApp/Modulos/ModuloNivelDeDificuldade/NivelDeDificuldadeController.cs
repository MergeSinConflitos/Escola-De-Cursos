using System;

namespace EscolaDeCursos.WebApp.Modulos.ModuloNivelDeDificuldade;

using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloNivelDeDificuldade;
using EscolaDeCursos.Dominio.Modulos.ModuloNivelDeDificuldade;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

public class NivelDeDificuldadeController(
    ServicoNivelDeDificuldade servicoNivelDeDificuldade,
    IMapper mapeador) : Controller
{

    [HttpGet]
    public ActionResult Listar(
     string pesquisa,
     Classificacao? classificacao)
    {
        List<ListarNivelDeDificuldadeDto> dtos =
            servicoNivelDeDificuldade.Pesquisar(
                pesquisa,
                classificacao
            );


        List<ListarNivelDeDificuldadeViewModel> listarVms =
            mapeador.Map<List<ListarNivelDeDificuldadeViewModel>>(dtos);


        ViewBag.Pesquisa = pesquisa;
        ViewBag.Classificacao = classificacao;


        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarNivelDeDificuldadeViewModel cadastrarVm = new CadastrarNivelDeDificuldadeViewModel(
            string.Empty,
            string.Empty,
            Classificacao.Basico
        );

        return View(cadastrarVm);
    }


    [HttpPost]
    public ActionResult Cadastrar(
        CadastrarNivelDeDificuldadeViewModel cadastrarVm)
    {

        if (!ModelState.IsValid)
            return View(cadastrarVm);



        CadastrarNivelDeDificuldadeDto dto =
            mapeador.Map<CadastrarNivelDeDificuldadeDto>(cadastrarVm);



        Result resultado =
            servicoNivelDeDificuldade.Cadastrar(dto);



        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(cadastrarVm);
        }



        return RedirectToAction(nameof(Listar));
    }





    [HttpGet]
    public ActionResult Editar(Guid id)
    {
        Result<DetalhesNivelDeDificuldadeDto> resultado =
            servicoNivelDeDificuldade.SelecionarPorId(id);



        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }



        EditarNivelDeDificuldadeViewModel editarVm =
            mapeador.Map<EditarNivelDeDificuldadeViewModel>(
                resultado.Value
            );



        return View(editarVm);
    }





    [HttpPost]
    public ActionResult Editar(
        EditarNivelDeDificuldadeViewModel editarVm)
    {

        if (!ModelState.IsValid)
            return View(editarVm);



        EditarNivelDeDificuldadeDto dto =
            mapeador.Map<EditarNivelDeDificuldadeDto>(editarVm);



        Result resultado =
            servicoNivelDeDificuldade.Editar(dto);




        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(editarVm);
        }



        return RedirectToAction(nameof(Listar));
    }





    [HttpGet]
    public ActionResult Excluir(Guid id)
    {
        Result<DetalhesNivelDeDificuldadeDto> resultado =
            servicoNivelDeDificuldade.SelecionarPorId(id);




        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }



        ExcluirNivelDeDificuldadeViewModel excluirVm =
            mapeador.Map<ExcluirNivelDeDificuldadeViewModel>(
                resultado.Value
            );



        return View(excluirVm);
    }





    [HttpPost]
    public ActionResult Excluir(
        ExcluirNivelDeDificuldadeViewModel excluirVm)
    {

        Result resultado =
            servicoNivelDeDificuldade.Excluir(excluirVm.Id);



        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);



        return RedirectToAction(nameof(Listar));
    }
}