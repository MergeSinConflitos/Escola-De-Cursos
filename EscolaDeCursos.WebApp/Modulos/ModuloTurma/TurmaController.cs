using System;
using System.Collections.Generic;
using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;
using EscolaDeCursos.Aplicacao.Modulos.ModuloInstrutor;
using EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloTurma
{
    public class TurmaController(
        ServicoTurma servicoTurma,
        ServicoCurso servicoCurso,
        ServicoInstrutor servicoInstrutor,
        IMapper mapeador) : Controller
    {
        
        [HttpGet]
        public ActionResult Listar()
        {
            
            List<ListarTurmasDto> dtos = servicoTurma.SelecionarTodos();

            List<ListarTurmaViewModel> listarVms = mapeador.Map<List<ListarTurmaViewModel>>(dtos);

            
            ViewBag.Cursos = CarregarCursos();
            ViewBag.Instrutores = CarregarInstrutores();

            return View(listarVms);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            CadastrarTurmaViewModel cadastrarVm = new(
                Nome: string.Empty,
                Periodo: 0,
                DataInicio: DateTime.Now,
                DataTermino: DateTime.Now,
                QuantidadeMaxAlunos: 10,
                CursoId: null,
                InstrutorId: null,
                Cursos: CarregarCursos(),
                Instrutores: CarregarInstrutores()
            );

            return View(cadastrarVm);
        }

        
        [HttpPost]
        public ActionResult Cadastrar(CadastrarTurmaViewModel cadastrarVm)
        {
            if (!ModelState.IsValid)
            {
                cadastrarVm = cadastrarVm with
                {
                    Cursos = CarregarCursos(),
                    Instrutores = CarregarInstrutores()
                };
                return View(cadastrarVm);
            }

            CadastrarTurmaDto dto = mapeador.Map<CadastrarTurmaDto>(cadastrarVm);

            Result resultado = servicoTurma.Cadastrar(dto);

            if (resultado.IsFailed)
            {
                ModelState.AddModelError(resultado);

                cadastrarVm = cadastrarVm with
                {
                    Cursos = CarregarCursos(),
                    Instrutores = CarregarInstrutores()
                };
                return View(cadastrarVm);
            }

            return RedirectToAction(nameof(Listar));
        }

        
        [HttpGet]
        public ActionResult Editar(Guid id)
        {
            Result<DetalhesTurmaDto> resultado = servicoTurma.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                TempData.AddErrorMessage(resultado);
                return RedirectToAction(nameof(Listar));
            }

            EditarTurmaViewModel editarVm = mapeador.Map<EditarTurmaViewModel>(resultado.Value);

            editarVm = editarVm with
            {
                Cursos = CarregarCursos(),
                Instrutores = CarregarInstrutores()
            };

            return View(editarVm);
        }

        
        [HttpPost]
        public ActionResult Editar(EditarTurmaViewModel editarVm)
        {
            if (!ModelState.IsValid)
            {
                editarVm = editarVm with
                {
                    Cursos = CarregarCursos(),
                    Instrutores = CarregarInstrutores()
                };
                return View(editarVm);
            }

            EditarTurmaDto dto = mapeador.Map<EditarTurmaDto>(editarVm);

            Result resultado = servicoTurma.Editar(dto);

            if (resultado.IsFailed)
            {
                ModelState.AddModelError(resultado);

                editarVm = editarVm with
                {
                    Cursos = CarregarCursos(),
                    Instrutores = CarregarInstrutores()
                };
                return View(editarVm);
            }

            return RedirectToAction(nameof(Listar));
        }

        
        [HttpGet]
        public ActionResult Excluir(Guid id)
        {
            Result<DetalhesTurmaDto> resultado = servicoTurma.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                TempData.AddErrorMessage(resultado);
                return RedirectToAction(nameof(Listar));
            }

            ExcluirTurmaViewModel excluirVm = mapeador.Map<ExcluirTurmaViewModel>(resultado.Value);

            return View(excluirVm);
        }

        
        [HttpPost]
        public ActionResult Excluir(ExcluirTurmaViewModel excluirVm)
        {
            Result resultado = servicoTurma.Excluir(excluirVm.Id);

            if (resultado.IsFailed)
            {
                TempData.AddErrorMessage(resultado);
                return RedirectToAction(nameof(Listar));
            }

            return RedirectToAction(nameof(Listar));
        }

        private List<OpcaoCursoViewModel> CarregarCursos()
        {
            return mapeador.Map<List<OpcaoCursoViewModel>>(servicoCurso.SelecionarOpcoes());
        }

        private List<OpcaoInstrutorViewModel> CarregarInstrutores()
        {
            
            return mapeador.Map<List<OpcaoInstrutorViewModel>>(servicoInstrutor.SelecionarOpcoes());
        }
    }
}