namespace Cinema.Services.Interfaces;

public interface IUserReservationService
{
    Task<UserReservation> CreateReservation(CreateUserReservationPayload payload);
    Task ConfirmReservation(Guid id);
}