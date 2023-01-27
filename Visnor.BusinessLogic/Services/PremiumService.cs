using Visnor.BusinessLogic.Interfaces;
using Visnor.Models;
using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Services;

public class PremiumService : IPremiumService
{
    private readonly ApplicationContext _applicationContext;

    public PremiumService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public void CreatePremium(int userId)
    {
        var premium = new Premium
        {
            UserId = userId,
            Availability = false
        };

        _applicationContext.Premiums.Add(premium);
    }

    public void ChangePremium(int userId)
    {
        var premium = _applicationContext.Premiums.FirstOrDefault(p => p.UserId == userId);

        if (premium != null)
        {
            premium.Availability = true;

            _applicationContext.Premiums.Update(premium);
        }
    }
}