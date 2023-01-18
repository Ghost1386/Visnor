namespace Visnor.Common.DTO_S.UserDto;

public class CreateUserDto
{
    public string Email { get; set; }

    public string Password { get; set; }
    
    public int Favorite { get; set; }

    public int Role { get; set; }
}