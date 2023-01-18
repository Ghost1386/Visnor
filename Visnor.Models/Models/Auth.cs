namespace Visnor.Models.Models;

public class Auth
{
    public int AuthId { get; set; }
    
    public string Email { get; set; }

    public byte[] Salt { get; set; }
}