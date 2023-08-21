using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models;

public class UserReservation: BaseModel
{
    [Column("show_time_id")]
    public Guid ShowTimeId { get; set; }
    
    [Column("user_id")]
    public Guid UserId { get; set; }
    
    [Column("reservation_time_utc")]
    public DateTime ReservationTimeUtc { get; set; }
    
    [Column("status")]
    public UserReservationStatus Status { get; set; }
    
    [Column("reserved_row_number_seats")]
    public int[] ReservedRowNumberSeats { get; set; }
    
    [Column("reserved_place_number_seats")]
    public int[] ReservedPlaceNumberSeats { get; set; }
    
    [Column("total_price_usd")]
    public decimal TotalPriceUsd { get; set; }

}

public enum UserReservationStatus
{
    New = 0,
    Deleted = 1,
    Booked = 3,
}