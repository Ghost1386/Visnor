using Visnor.Common.DTO_S.AuthDto;

namespace Visnor.BusinessLogic.Interfaces;

public interface IAuthService
{
    void Login(LoginDto model);

    void Registration(RegistrationDto model);
}