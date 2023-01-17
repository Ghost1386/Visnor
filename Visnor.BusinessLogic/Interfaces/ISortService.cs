using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Interfaces;

public interface ISortService
{
    IQueryable<Film> GetNewFilm();

    IQueryable<Film> GetRecommendedFilm();

    IQueryable<Film> GetViewedFilm();
}