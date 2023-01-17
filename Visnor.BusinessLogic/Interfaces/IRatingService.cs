using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Interfaces;

public interface IRatingService
{
    void CalculateRating(Film film);
}