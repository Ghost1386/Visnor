using Visnor.BusinessLogic.Interfaces;
using Visnor.Models;
using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Services;

public class ViewedService : IViewedService
{
    private readonly ApplicationContext _applicationContext;

    public ViewedService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public List<Viewing> GetViewedFilmByUser(int userId)
    {
        var viewings = _applicationContext.Viewings.Where(v => v.UserId == userId);

        return viewings.ToList();
    }
}