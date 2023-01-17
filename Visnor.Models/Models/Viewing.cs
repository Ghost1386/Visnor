namespace Visnor.Models.Models;

public class Viewing
{
    public int ViewingId { get; set; }
    
    public User UserId { get; set; }
    
    public Film FilmId { get; set; }
    
    public int Grade { get; set; }
}