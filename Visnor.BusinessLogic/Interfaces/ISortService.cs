using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Interfaces;

public interface ISortService
{
    List<Film> GetNewFilm(List<Film> films);

    List<Film> GetRecommendedFilm(int userId);

    List<Film> GetViewedFilm(int userId, List<Film> films);
}