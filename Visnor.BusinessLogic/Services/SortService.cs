using Visnor.BusinessLogic.Interfaces;
using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Services;

public class SortService : ISortService
{
    private readonly IFilmService _filmService;
    private readonly IViewedService _viewedService;

    public SortService(IFilmService filmService, IViewedService viewedService)
    {
        _filmService = filmService;
        _viewedService = viewedService;
    }

    public List<Film> GetNewFilm()
    {
        var films = _filmService.GetAllFilm();

        films.Reverse();
        
        var sortedFilms = films.Take(10).ToList();

        return sortedFilms; 
    }

    public List<Film> GetRecommendedFilm(int userId)
    {
        throw new NotImplementedException();
    }

    public List<Film> GetViewedFilm(int userId)
    {
        var viewings = _viewedService.GetViewedFilmByUser(userId).AsQueryable();

        var films = _filmService.GetAllFilm().AsQueryable();

        var sortedFilms = new List<Film>();

        foreach (var film in films)
        {
            foreach (var viewing in viewings)
            {
                if (viewing.FilmId == film.FilmId)
                {
                    sortedFilms.Add(film);
                }
            }
        }

        return sortedFilms;
    }
}