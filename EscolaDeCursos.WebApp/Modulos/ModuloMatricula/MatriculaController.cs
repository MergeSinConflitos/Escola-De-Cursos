using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloMatricula;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloMatricula;

public class MatriculaController(ServicoMatricula servicoMatricula, IMapper mapeador) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarMatriculasDto> dtos = servicoMatricula.SelecionarTodos();

        List<ListarMatriculasViewModel> listarVms = mapeador.Map<List<ListarMatriculasViewModel>>(dtos);

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarMatriculaViewModel cadastrarVm = new CadastrarMatriculaViewModel(
            null,
            null,
            DateTime.Now,
            SelecionarAlunos(),
            SelecionarTurmas()
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarMatriculaViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm with
            {
                Alunos = SelecionarAlunos(),
                Turmas = SelecionarTurmas()
            });

        CadastrarMatriculaDto dto = mapeador.Map<CadastrarMatriculaDto>(cadastrarVm);

        Result resultado = servicoMatricula.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);   

            return View(cadastrarVm with
            {
                Alunos = SelecionarAlunos(),
                Turmas = SelecionarTurmas()
            });
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(Guid id)
    {
        Result<DetalhesMatriculaDto> resultado = servicoMatricula.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(Listar));
        }

        EditarMatriculaViewModel editarVm = mapeador.Map<EditarMatriculaViewModel>(resultado.Value);

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarMatriculaViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        EditarMatriculaDto dto = mapeador.Map<EditarMatriculaDto>(editarVm);

        Result resultado = servicoMatricula.Editar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);
            return View(editarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Cancelar(Guid id)
    {
        Result<DetalhesMatriculaDto> resultado = servicoMatricula.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(Listar));
        }

        CancelarMatriculaViewModel cancelarVm = mapeador.Map<CancelarMatriculaViewModel>(resultado.Value);

        return View(cancelarVm);
    }

    [HttpPost]
    public ActionResult Cancelar(CancelarMatriculaViewModel cancelarVm)
    {
        Result resultado = servicoMatricula.Excluir(cancelarVm.Id);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult ListarPorAluno(Guid alunoId)
    {
        List<ListarMatriculasDto> dtos = servicoMatricula.SelecionarPorAluno(alunoId);

        List<ListarMatriculasViewModel> listarVms = mapeador.Map<List<ListarMatriculasViewModel>>(dtos);

        ViewBag.AlunoId = alunoId;

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult ListarPorTurma(Guid turmaId)
    {
        List<ListarMatriculasDto> dtos = servicoMatricula.SelecionarPorTurma(turmaId);

        List<ListarMatriculasViewModel> listarVms = mapeador.Map<List<ListarMatriculasViewModel>>(dtos);

        ViewBag.TurmaId = turmaId;

        return View(listarVms);
    }

    private List<OpcaoAlunoViewModel> SelecionarAlunos()
    {
        List<OpcaoAlunoDto> dtos = servicoMatricula.SelecionarOpcoesAlunos();

        return mapeador.Map<List<OpcaoAlunoViewModel>>(dtos);
    }

    private List<OpcaoTurmaViewModel> SelecionarTurmas()
    {
        List<OpcaoTurmaDto> dtos = servicoMatricula.SelecionarOpcoesTurmas();

        return mapeador.Map<List<OpcaoTurmaViewModel>>(dtos);
    }
}