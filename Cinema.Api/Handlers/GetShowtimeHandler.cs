namespace Cinema.Handlers;

public class GetShowtimeHandler: IRequestHandler<GetShowtimeCommand, Showtime>
{
    private readonly IShowtimeService _showtimeService;

    public GetShowtimeHandler(IShowtimeService showtimeService)
    {
        _showtimeService = showtimeService;
    }

    public Task<Showtime> Handle(GetShowtimeCommand request, CancellationToken cancellationToken)
    {
        return _showtimeService.GetByIdAsync(request.Request);
    }
}