using Visnor.Common.DTO_S.FilmDto;
using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Interfaces;

public interface IFilmService
{
    List<Film> GetAllFilm();

    List<Film> GetNewFilm();

    List<Film> GetRecommendedFilm(int id);

    List<Film> GetViewedFilm(int id);

    Film GetFilm(SearchFilmDto model);

    void CreateFilm(CreateFilmDto model);
}