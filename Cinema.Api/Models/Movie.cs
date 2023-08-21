using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models;

public class Movie : BaseModel
{
    [Column("title")]
    public string Title { get; set; }

    [Column("description")]
    public string Description { get; set; }
    
    [Column("genre")]
    public string Genre { get; set; }
    
    [Column("duration_minutes")]
    public int DurationMinutes { get; set; }
    
    [Column("director")]
    public string Director { get; set; }
}