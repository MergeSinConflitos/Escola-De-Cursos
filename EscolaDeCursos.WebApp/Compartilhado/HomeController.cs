using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Compartilhado.Apresentacao;

public class HomeController : Controller
{
    [HttpGet]
    [AllowAnonymous]
    public ActionResult Index()
    {
        return View();
    }
}
