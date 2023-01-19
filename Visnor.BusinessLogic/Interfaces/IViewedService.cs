using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Interfaces;

public interface IViewedService
{
    List<Viewing> GetViewedFilmByUser(int userId);
}