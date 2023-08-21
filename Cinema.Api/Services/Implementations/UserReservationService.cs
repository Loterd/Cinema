namespace Cinema.Services.Implementations;

public class UserReservationService : IUserReservationService
{
    private readonly IUserReservationRepository _userReservationRepository;
    private readonly IMediator _mediator;
    private static readonly SemaphoreSlim _lock = new(1);

    public UserReservationService(IUserReservationRepository userReservationRepository, IMediator mediator)
    {
        _userReservationRepository = userReservationRepository;
        _mediator = mediator;
    }

    public async Task<UserReservation> CreateReservation(CreateUserReservationPayload payload)
    {
        await _lock.WaitAsync();

        try
        {
            var showtime = await _mediator.Send(new GetShowtimeCommand(payload.ShowTimeId));
            if (showtime == null)
            {
                throw new BadRequestApiException($"Showtime with id {payload.ShowTimeId} does not exists");
            }

            if (showtime.DateTimeUtc < DateTime.UtcNow)
            {
                throw new BadRequestApiException("Showtime happened in the past");
            }

            ValidateSeatsAvailability(payload, showtime);
            
            await ReserveSeatForShowtime(showtime);

            var result = await _userReservationRepository.AddAsync(new UserReservation
            {
                ShowTimeId = payload.ShowTimeId,
                ReservationTimeUtc = DateTime.UtcNow,
                ReservedRowNumberSeats = payload.ReservedRowNumberSeats,
                ReservedPlaceNumberSeats = payload.ReservedPlaceNumberSeats,
                UserId = payload.UserId,
                Status = UserReservationStatus.New,
                TotalPriceUsd = showtime.PriceForOneSeatUsd * payload.ReservedRowNumberSeats.Length
            });
            return result;
        }
        finally
        {
            _lock.Release();
        }
    }
    
    private void ValidateSeatsAvailability(CreateUserReservationPayload payload, Showtime showtime)
    {
        if (payload.ReservedRowNumberSeats.Length != payload.ReservedPlaceNumberSeats.Length
            || payload.ReservedRowNumberSeats.Length == 0
            || payload.ReservedPlaceNumberSeats.Length == 0)
        {
            throw new BadRequestApiException("Places numbers specified incorrect");
        }

        foreach (var seat in payload.ReservedRowNumberSeats)
        {
            foreach (var place in payload.ReservedPlaceNumberSeats)
            {
                if (showtime.AvailableSeats.Length <= seat || showtime.AvailableSeats[seat].Length <= place)
                {
                    throw new BadRequestApiException("Places numbers specified incorrect");
                }

                var seatArrangement = showtime.AvailableSeats[seat][place];
                if (seatArrangement != SeatArrangement.Available)
                {
                    throw new BadRequestApiException($"Seat {seat}-{place} are not available");
                }

                showtime.AvailableSeats[seat][place] = SeatArrangement.Reserved;
            }
        }
    }

    private async Task ReserveSeatForShowtime(Showtime showtime)
    {
        var command = new UpdateShowtimeAvailableSeatsCommand(new UpdateShowtimeAvailableSeatsRequest
        {
            Id = showtime.Id,
            AvailableSeats = showtime.AvailableSeats
        });
        await _mediator.Send(command);
    }

    public async Task ConfirmReservation(Guid id)
    {
        var userReservation = await _userReservationRepository.GetByIdAsync(id);
        if (userReservation == null)
        {
            throw new NotFoundApiException($"UserReservation with id {id} does not exists");
        }

        if (userReservation.Status == UserReservationStatus.Booked)
        {
            throw new BadRequestApiException("UserReservation already booked");
        }
        
        if (userReservation.Status == UserReservationStatus.Deleted)
        {
            throw new BadRequestApiException("UserReservation already overdue");
        }

        userReservation.Status = UserReservationStatus.Booked;
        await _userReservationRepository.UpdateAsync(userReservation);
        
        await BookSeatsForShowtime(userReservation);
    }

    private async Task BookSeatsForShowtime(UserReservation userReservation)
    {
        var showtime = await _mediator.Send(new GetShowtimeCommand(userReservation.ShowTimeId));
        foreach (var seat in userReservation.ReservedRowNumberSeats)
        {
            foreach (var place in userReservation.ReservedPlaceNumberSeats)
            {
                showtime.AvailableSeats[seat][place] = SeatArrangement.Booked;
            }
        }

        var command = new UpdateShowtimeAvailableSeatsCommand(new UpdateShowtimeAvailableSeatsRequest
        {
            Id = showtime.Id,
            AvailableSeats = showtime.AvailableSeats
        });
        await _mediator.Send(command);
    }
}
