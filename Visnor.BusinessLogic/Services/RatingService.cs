using Visnor.BusinessLogic.Interfaces;
using Visnor.Models;
using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Services;

public class RatingService : IRatingService
{
    private readonly ApplicationContext _applicationContext;

    public RatingService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public Rating CreateRating(int filmId)
    {
        var rating = new Rating
        {
            Value = 0.0,
            FilmId = filmId
        };

        _applicationContext.Ratings.Add(rating);

        return rating;
    }

    public double GetRating(int filmId)
    {
        var rating = _applicationContext.Ratings.FirstOrDefault(r => r.FilmId == filmId);

        if (rating != null)
        {
            return rating.Value;
        }

        return 0;
    }

    public void CalculateRating(int filmId, IQueryable<Viewing> viewing)
    {
        var viewings = viewing.Where(g => g.FilmId == filmId).ToList();

        var sum = viewings.Sum(v => v.Grade);

        var newGrade = sum / viewings.Count;
        
        var rating = _applicationContext.Ratings.FirstOrDefault(r => r.FilmId == filmId);

        if (rating != null)
        {
            rating.Value = newGrade;

            _applicationContext.Ratings.Update(rating);
        }
    }
}