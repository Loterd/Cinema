using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Cinema.Models;

public class Showtime : BaseModel
{
    [Column("theater_id")]
    public Guid TheaterId { get; set; }
    
    [Column("movie_id")]
    public Guid MovieId { get; set; }
    
    [Column("datetime_utc")]
    public DateTime DateTimeUtc { get; set; }
    
    [Column("available_seats")]
    public string AvailableSeatsJson { get; set; }

    [NotMapped]
    public SeatArrangement[][] AvailableSeats
    {
        get => JsonConvert.DeserializeObject<SeatArrangement[][]>(AvailableSeatsJson);
        set => AvailableSeatsJson = JsonConvert.SerializeObject(value);
    }
    
    [Column("price_for_one_seat_usd")]
    public decimal PriceForOneSeatUsd { get; set; }
}