namespace Cinema.Services.Implementations;

public class ShowtimeService : IShowtimeService
{
    private readonly IShowtimeRepository _showtimeRepository;
    private readonly IMediator _mediator;
    private readonly ITheaterRepository _theaterRepository;


    public ShowtimeService(IShowtimeRepository showtimeRepository, IMediator mediator,
        ITheaterRepository theaterRepository)
    {
        _showtimeRepository = showtimeRepository;
        _mediator = mediator;
        _theaterRepository = theaterRepository;
    }

    public async Task<IEnumerable<Showtime>> GetShowtimesByTheaterAsync(Guid theaterId)
    {
        return await _showtimeRepository.GetShowtimesByTheaterAsync(theaterId);
    }

    public async Task<IEnumerable<Showtime>> GetShowtimesByMovieAsync(Guid movieId)
    {
        return await _showtimeRepository.GetShowtimesByMovieAsync(movieId);
    }

    public async Task<Showtime> CreateShowtimeAsync(ShowtimePayload showtimePayload)
    {
        var theater = await _theaterRepository.GetTheaterByIdAsync(showtimePayload.TheaterId);
        if (theater == null)
        {
            throw new BadRequestApiException($"Theater with id {showtimePayload.TheaterId} does not exists");
        }

        var validationResult = await _mediator.Send(new ValidateMovieIdCommand(showtimePayload.MovieId));
        if (!validationResult)
        {
            throw new BadRequestApiException($"Movie with id {showtimePayload.MovieId} does not exists");
        }

        if (showtimePayload.PriceForOneSeatUsd <= 0)
        {
            throw new BadRequestApiException($"Price should be more than zero");
        }

        var showtime = new Showtime
        {
            TheaterId = showtimePayload.TheaterId,
            MovieId = showtimePayload.MovieId,
            DateTimeUtc = showtimePayload.DateTimeUtc,
            AvailableSeatsJson = theater.SeatingArrangementJson,
            PriceForOneSeatUsd = showtimePayload.PriceForOneSeatUsd
        };
        return await _showtimeRepository.CreateShowtimeAsync(showtime);
    }

    public Task<Showtime> GetByIdAsync(Guid id) => _showtimeRepository.GetByIdAsync(id);

    public Task UpdateAsync(Showtime Showtime) => _showtimeRepository.UpdateAsync(Showtime);
}
