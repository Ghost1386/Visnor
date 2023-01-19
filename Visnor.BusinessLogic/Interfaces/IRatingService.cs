using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Interfaces;

public interface IRatingService
{
    void CreateRating(Film film);
    
    void CalculateRating(int id, IQueryable<Viewing> viewing);
}