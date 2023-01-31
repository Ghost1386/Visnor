using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Interfaces;

public interface IRatingService
{
    Rating CreateRating(int filmId);
    
    double GetRating(int filmId);
    
    void CalculateRating(int id, IQueryable<Viewing> viewing);
}