using Visnor.Common.DTO_S.AuthDto;
using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Interfaces;

public interface IAuthService
{
    AuthResponse Login(LoginDto model);

    string Registration(RegistrationDto model);
}