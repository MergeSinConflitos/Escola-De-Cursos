using System;
using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCategoria;

public class CategoriaController(
    ServicoCategoria servicoCategoria,
    IMapper mapeador) : Controller
{
    [HttpGet]
    public ActionResult Listar(string pesquisa)
    {
        List<ListarCategoriasDto> dtos;


        if (string.IsNullOrWhiteSpace(pesquisa))
            dtos = servicoCategoria.SelecionarTodos();
        else
            dtos = servicoCategoria.PesquisarPorNome(pesquisa);


        List<ListarCategoriasViewModel> listarVms =
            mapeador.Map<List<ListarCategoriasViewModel>>(dtos);


        ViewBag.Pesquisa = pesquisa;


        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarCategoriaViewModel cadastrarVm =
            new CadastrarCategoriaViewModel(string.Empty);

        return View(cadastrarVm);
    }


    [HttpPost]
    public ActionResult Cadastrar(CadastrarCategoriaViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);


        CadastrarCategoriaDto dto =
            mapeador.Map<CadastrarCategoriaDto>(cadastrarVm);


        Result resultado =
            servicoCategoria.Cadastrar(dto);


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
        Result<DetalhesCategoriaDto> resultado =
            servicoCategoria.SelecionarPorId(id);


        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }


        EditarCategoriaViewModel editarVm =
            mapeador.Map<EditarCategoriaViewModel>(resultado.Value);


        return View(editarVm);
    }


    [HttpPost]
    public ActionResult Editar(EditarCategoriaViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);


        EditarCategoriaDto dto =
            mapeador.Map<EditarCategoriaDto>(editarVm);


        Result resultado =
            servicoCategoria.Editar(dto);


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
        Result<DetalhesCategoriaDto> resultado =
            servicoCategoria.SelecionarPorId(id);


        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }


        ExcluirCategoriaViewModel excluirVm =
            mapeador.Map<ExcluirCategoriaViewModel>(resultado.Value);


        return View(excluirVm);
    }


    [HttpPost]
    public ActionResult Excluir(ExcluirCategoriaViewModel excluirVm)
    {
        Result resultado =
            servicoCategoria.Excluir(excluirVm.Id);


        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);


        return RedirectToAction(nameof(Listar));
    }
}