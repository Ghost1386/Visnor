using Visnor.BusinessLogic.Interfaces;
using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Services;

public class SortService : ISortService
{
    public IQueryable<Film> GetNewFilm()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Film> GetRecommendedFilm()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Film> GetViewedFilm()
    {
        throw new NotImplementedException();
    }
}