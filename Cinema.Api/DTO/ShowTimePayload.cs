using System.ComponentModel.DataAnnotations;

namespace Cinema.Models;

public class ShowtimePayload
{
    [Required]
    public Guid TheaterId { get; set; }
    
    [Required]
    public Guid MovieId { get; set; }
    
    [Required]
    public DateTime DateTimeUtc { get; set; }
    
    [Required]
    public decimal PriceForOneSeatUsd { get; set; }
}