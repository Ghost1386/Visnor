using System.ComponentModel.DataAnnotations;

namespace Visnor.Models.Models;

public class Ban
{
    [Key]
    public int BanId { get; set; }
    
    public int UserId { get; set; }
    
    public string Email { get; set; }
    
    public string Reason { get; set; }
}