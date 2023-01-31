using Visnor.BusinessLogic.Interfaces;
using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Services;

public class SortService : ISortService
{
    private readonly IViewedService _viewedService;

    public SortService(IViewedService viewedService)
    {
        _viewedService = viewedService;
    }

    public List<Film> GetNewFilm(List<Film> films)
    {
        films.Reverse();
        
        var sortedFilms = films.Take(10).ToList();

        return sortedFilms; 
    }

    public List<Film> GetRecommendedFilm(int userId)
    {
        throw new NotImplementedException();
    }

    public List<Film> GetViewedFilm(int userId, List<Film> films)
    {
        var viewings = _viewedService.GetViewedFilmByUser(userId).AsQueryable();

        films.AsQueryable();

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