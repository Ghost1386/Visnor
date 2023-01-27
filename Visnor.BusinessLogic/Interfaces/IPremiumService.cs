using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Interfaces;

public interface IPremiumService
{
    void CreatePremium(int userId);

    void ChangePremium(int userId);
}