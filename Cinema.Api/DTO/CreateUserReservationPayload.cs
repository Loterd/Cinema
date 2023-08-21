namespace Cinema.Models;

public class CreateUserReservationPayload
{
    public Guid ShowTimeId { get; set; }
    public Guid UserId { get; set; }
    public int[] ReservedRowNumberSeats { get; set; }
    public int[] ReservedPlaceNumberSeats { get; set; }
}