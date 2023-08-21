namespace Cinema.Repositories.Interfaces;

public interface IUserReservationRepository
{
    Task<UserReservation> AddAsync(UserReservation userReservation);
    Task UpdateAsync(UserReservation userReservation);
    Task<UserReservation> GetByIdAsync(Guid id);
}