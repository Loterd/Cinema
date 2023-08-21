using System.ComponentModel.DataAnnotations;

namespace Cinema.Models;

public class TheaterPayload
{
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
    
    [Required]
    [MinLength(4)]
    public SeatArrangement[][] SeatingArrangement { get; set; }
}