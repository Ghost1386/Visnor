using Microsoft.AspNetCore.Mvc;
using Visnor.BusinessLogic.Interfaces;
using Visnor.Common.DTO_S.FilmDto;

namespace Visnor.Controllers;

public class AdminController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ErrorsController _errorsController;
    private readonly IFilmService _filmService;
    private readonly IUserService _userService;
    

    public AdminController(ILogger<HomeController> logger, ErrorsController errorsController, 
        IFilmService filmService, IUserService userService)
    {
        _logger = logger;
        _errorsController = errorsController;
        _filmService = filmService;
        _userService = userService;
    }

    public IActionResult CreateFilm()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateFilm(CreateFilmDto createFilmDto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _filmService.CreateFilm(createFilmDto);

                return RedirectToAction(nameof(CreateFilm));
            }

            return RedirectToAction("HomePage", "Home");
        }
        catch (Exception ex)
        {
            _logger.LogError($"{DateTime.UtcNow}: {ex.Message}");
            
            return _errorsController.ErrorsPage(500, "Internal Server Error");
        }
        
    }
}