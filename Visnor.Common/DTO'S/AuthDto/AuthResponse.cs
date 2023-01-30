using Visnor.Common.Enums;

namespace Visnor.Common.DTO_S.AuthDto;

public class AuthResponse
{
    public int UserId { get; set; }
    
    public string Token { get; set; }
    
    public string Email { get; set; }
    
    public Role Role { get; set; }
}