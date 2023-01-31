using Microsoft.AspNetCore.Mvc;
using Visnor.BusinessLogic.Interfaces;

namespace Visnor.Controllers;

public class HomeController : Controller
{
    private readonly IFilmService _filmService;

    public HomeController(IFilmService filmService)
    {
        _filmService = filmService;
    }

    public IActionResult HomePage()
    {
        return View(_filmService.GetAllFilm());
    }
}