using Visnor.Common.DTO_S.UserDto;

namespace Visnor.BusinessLogic.Interfaces;

public interface IUserService
{
    List<GetUserDto> GetAllUser();
    
    GetUserDto GetUser(SearchUserDto model);
    
    void CreateUser(CreateUserDto model);

    void EditUser(SearchUserDto model);
    
    void BannedUser(SearchUserDto model);
}