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
        var films = GetAllFilm();

        var sortedFilms = _sortService.GetNewFilm(films);
        
        return sortedFilms;
    }

    public List<Film> GetRecommendedFilm(int userId)
    {
        return _sortService.GetRecommendedFilm(userId);
    }

    public List<Film> GetViewedFilm(int userId)
    {
        var films = GetAllFilm();

        var sortedFilms = _sortService.GetViewedFilm(userId, films);
        
        return sortedFilms;
    }

    public List<Film> GetFilm(SearchFilmDto model)
    {
        var films = _applicationContext.Films.AsQueryable();

        if (!string.IsNullOrEmpty(model.Title))
        {
            films = films.Where(f => f.Title == model.Title);
        }
        
        if (model.Year != 0)
        {
            films = films.Where(f => f.Year == model.Year);
        }

        return films.ToList();
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

    public void DeleteFilm(SearchFilmDto model)
    {
        var film = GetFilm(model).FirstOrDefault();

        if (film != null)
        {
            _applicationContext.Films.Remove(film);
        }
    }
}