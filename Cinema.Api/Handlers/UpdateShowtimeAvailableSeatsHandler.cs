using Newtonsoft.Json;

namespace Cinema.Handlers;

public class UpdateShowtimeAvailableSeatsHandler : IRequestHandler<UpdateShowtimeAvailableSeatsCommand>
{
    private readonly IShowtimeService _showtimeService;

    public UpdateShowtimeAvailableSeatsHandler(IShowtimeService showtimeService)
    {
        _showtimeService = showtimeService;
    }

    public async Task Handle(UpdateShowtimeAvailableSeatsCommand request, CancellationToken cancellationToken)
    {
        var showtime = await _showtimeService.GetByIdAsync(request.Request.Id);
        showtime.AvailableSeatsJson = JsonConvert.SerializeObject(request.Request.AvailableSeats);
        await _showtimeService.UpdateAsync(showtime);
    }
}