using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Interfaces;

public interface IRatingService
{
    Rating CreateRating(int filmId);
    
    void CalculateRating(int id, IQueryable<Viewing> viewing);
}