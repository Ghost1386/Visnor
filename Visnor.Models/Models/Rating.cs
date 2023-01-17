using System.ComponentModel.DataAnnotations;

namespace Visnor.Models.Models;

public class Rating
{
    [Key]
    public int RatingId { get; set; }
    
    public double Value { get; set; }
    
    public Film Film { get; set; }
}