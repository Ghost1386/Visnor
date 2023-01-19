using Microsoft.AspNetCore.Http;
using Visnor.Models.Models;

namespace Visnor.Common.DTO_S.FilmDto;

public class CreateFilmDto
{
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
    
    public IFormFile Photo { get; set; }
    
    public string VideoUrl { get; set; }
    
    public Rating Grade { get; set; }
}