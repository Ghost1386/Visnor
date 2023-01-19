namespace Visnor.Models.Models;

public class Viewing
{
    public int ViewingId { get; set; }
    
    public int UserId { get; set; }
    
    public User User { get; set; }
    
    public int FilmId { get; set; }
    
    public Film Film { get; set; }
    
    public int Grade { get; set; }
}