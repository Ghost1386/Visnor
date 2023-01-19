using Visnor.BusinessLogic.Interfaces;
using Visnor.Common.DTO_S.FilmDto;
using Visnor.Models;
using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Services;

public class FilmService : IFilmService
{
    private readonly ApplicationContext _applicationContext;
    private readonly ISortService _sortService;
    private readonly IPhotoService _photoService;
    private readonly IRatingService _ratingService;

    public FilmService(ApplicationContext applicationContext, ISortService sortService, IPhotoService photoService, IRatingService ratingService)
    {
        _applicationContext = applicationContext;
        _sortService = sortService;
        _photoService = photoService;
        _ratingService = ratingService;
    }

    public List<Film> GetAllFilm()
    {
        return _applicationContext.Films.ToList();
    }

    public List<Film> GetNewFilm()
    {
        return _sortService.GetNewFilm();
    }

    public List<Film> GetRecommendedFilm(int userId)
    {
        return _sortService.GetRecommendedFilm(userId);
    }

    public List<Film> GetViewedFilm(int userId)
    {
        return _sortService.GetViewedFilm(userId);
    }

    public Film GetFilm(SearchFilmDto model)
    {
        var film = _applicationContext.Films.FirstOrDefault(f => f.Title == model.Title 
                                                        && f.Year == model.Year);

        return film ?? new Film();
    }

    public void CreateFilm(CreateFilmDto model)
    {
        var index = GetAllFilm().Count;
        
        var film = new Film
        {
            Title = model.Title,
            Description = model.Description,
            Year = model.Year,
            Country = model.Country,
            Genre = model.Genre,
            Producer = model.Producer,
            Actors = model.Actors,
            Age = model.Age,
            Duration = model.Duration,
            Budget = model.Budget,
            Photo = _photoService.ConvertPhotoInByteString(model.Photo),
            VideoUrl = model.VideoUrl,
            Grade = _ratingService.CreateRating(index + 1)
        };

        _applicationContext.Films.Add(film);
    }
}