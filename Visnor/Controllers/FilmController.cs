using Microsoft.AspNetCore.Mvc;
using Visnor.BusinessLogic.Interfaces;
using Visnor.Common.DTO_S.FilmDto;
using Visnor.Models.Models;

namespace Visnor.Controllers;

public class FilmController : Controller
{
    private readonly ILogger<FilmController> _logger;
    private readonly ErrorsController _errorsController;
    private readonly IFilmService _filmService;

    public FilmController(ILogger<FilmController> logger, ErrorsController errorsController, 
        IFilmService filmService)
    {
        _logger = logger;
        _errorsController = errorsController;
        _filmService = filmService;
    }
    
    [HttpPost]
    public IActionResult GetFilms(int userId)
    {
        try
        {
            var allFilm = _filmService.GetAllFilm();

            var newFilm = _filmService.GetNewFilm();

            var recommendedFilm = _filmService.GetRecommendedFilm(userId);

            var viewedFilm = _filmService.GetViewedFilm(userId);

            if (allFilm != null && newFilm != null && 
                recommendedFilm != null && viewedFilm != null)
            {
                var films = new List<Film>();

                films.AddRange(allFilm);
                films.AddRange(newFilm);
                films.AddRange(recommendedFilm);
                films.AddRange(viewedFilm);
                
                return Ok(films);
            }
            
            _logger.LogInformation($"{DateTime.UtcNow}: Failed to display movies for user {userId}");

            return _errorsController.ErrorsPage(204, "No Content");
        }
        catch (Exception ex)
        {
            _logger.LogError($"{DateTime.UtcNow}: {ex.Message}");
            
            return _errorsController.ErrorsPage(500, "Internal Server Error");
        }
    }

    [HttpGet]
    public IActionResult GetFilm(SearchFilmDto searchFilmDto)
    {
        try
        {
            var film = _filmService.GetFilm(searchFilmDto);

            if (film != null)
            {
                return Ok(film);
            }

            return Ok("Could not find a movie for this query.");
        }
        catch (Exception ex)
        {
            _logger.LogError($"{DateTime.UtcNow}: {ex.Message}");
            
            return _errorsController.ErrorsPage(500, "Internal Server Error");
        }
    }
}