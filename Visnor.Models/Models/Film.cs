using System.ComponentModel.DataAnnotations;

namespace Visnor.Models.Models;

public class Film
{
    [Key]
    public int FilmId { get; set; }

    public string Title { get; set; }
    
    public string Description { get; set; }

    public int Year { get; set; }
    
    public string Country { get; set; }
    
    public string Genre { get; set; }
    
    public string Producer { get; set; }

    public string Actors { get; set; }
    
    public int Age { get; set; }
    
    public string Duration { get; set; }
    
    public int Budget { get; set; }
    
    public string Photo { get; set; }
    
    public string VideoUrl { get; set; }
    
    public Rating Grade { get; set; }
}