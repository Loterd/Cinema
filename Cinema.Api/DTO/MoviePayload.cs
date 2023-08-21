using System.ComponentModel.DataAnnotations;

namespace Cinema.Models;

public class MoviePayload
{
    [Required]
    [MaxLength(255)]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    [MaxLength(100)]
    public string Genre { get; set; }

    [Required]
    public int DurationMinutes { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Director { get; set; }
}





