using Visnor.Common.DTO_S.UserDto;
using Visnor.Models.Models;

namespace Visnor.BusinessLogic.Interfaces;

public interface IUserService
{
    List<User> GetAllUser();
    
    User GetUser(SearchUserDto model);
    
    void CreateUser(CreateUserDto model);

    void EditUser(SearchUserDto model);
    
    void BannedUser(SearchUserDto model);
}