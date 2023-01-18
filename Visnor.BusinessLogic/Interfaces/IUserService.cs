using Visnor.Common.DTO_S.UserDto;
using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Interfaces;

public interface IUserService
{
    List<User> GetAllUser();
    
    User GetUser(SearchUserDto model);
    
    string CreateUser(CreateUserDto model);

    string BannedUser(string email, string reason);
}