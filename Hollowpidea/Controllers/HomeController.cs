using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hollowpidea.Models;
using Hollowpidea.Services;

namespace Hollowpidea.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHollowService _hollowService;

    public HomeController(ILogger<HomeController> logger, IHollowService hollowService)
    {
        _logger = logger;
        _hollowService = hollowService;
    }

    public IActionResult Index(string tribo)
    {
        var hollows = _hollowService.GetHollowpideaDto();
        ViewData["filter"] = string.IsNullOrEmpty(tribo) ? "all" : tribo;
        return View(hollows);
    }

    public IActionResult Details(int Numero)
    {
        var Personagem = _hollowService.GetDetailedPersonagem(Numero);
        return View(Personagem);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id 
                    ?? HttpContext.TraceIdentifier });
    }
}
