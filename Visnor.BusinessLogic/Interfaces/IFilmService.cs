using Visnor.Common.DTO_S.FilmDto;

namespace Visnor.BusinessLogic.Interfaces;

public interface IFilmService
{
    List<GetFilmDto> GetAllFilm();

    List<GetFilmDto> GetNewFilm();

    List<GetFilmDto> GetRecommendedFilm();

    List<GetFilmDto> GetViewedFilm();

    GetFilmDto GetFilm(SearchFilmDto model);

    void CreateFilm(CreateFilmDto model);

    void EditFilm(SearchFilmDto model);
}