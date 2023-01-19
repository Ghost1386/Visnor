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

    public void CreateRating(Film film)
    {
        var rating = new Rating
        {
            Value = 0.0,
            FilmId = film.FilmId
        };

        _applicationContext.Ratings.Add(rating);
    }

    public void CalculateRating(int id, IQueryable<Viewing> viewing)
    {
        var viewings = viewing.Where(g => g.FilmId == id).ToList();

        var sum = 0;

        foreach (var grades in viewings)
        {
            sum += grades.Grade;
        }

        var newGrade = sum / viewings.Count;
        
        var rating = _applicationContext.Ratings.FirstOrDefault(r => r.FilmId == id);

        if (rating != null)
        {
            rating.Value = newGrade;

            _applicationContext.Ratings.Update(rating);
        }
    }
}