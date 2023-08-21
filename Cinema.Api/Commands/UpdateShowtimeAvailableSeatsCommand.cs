namespace Cinema.Commands;

public class UpdateShowtimeAvailableSeatsCommand : IRequest
{
    public UpdateShowtimeAvailableSeatsCommand(UpdateShowtimeAvailableSeatsRequest request)
    {
        Request = request;
    }

    public UpdateShowtimeAvailableSeatsRequest Request { get; set; }
}