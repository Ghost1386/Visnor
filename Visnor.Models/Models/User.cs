using System.ComponentModel.DataAnnotations;

namespace Visnor.Models.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
    
    public int Favorite { get; set; }

    public int Role { get; set; }
}