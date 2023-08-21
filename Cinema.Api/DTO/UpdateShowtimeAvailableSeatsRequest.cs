namespace Cinema.Models;

public class UpdateShowtimeAvailableSeatsRequest
{
    public Guid Id { get; set; }
    public SeatArrangement[][] AvailableSeats { get; set; }
}