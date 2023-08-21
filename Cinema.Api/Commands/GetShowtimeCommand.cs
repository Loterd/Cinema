namespace Cinema.Commands;

public class GetShowtimeCommand : IRequest<Showtime>
{
    public GetShowtimeCommand(Guid request)
    {
    }

    public Guid Request { get; set; }
}