namespace Cinema.Services.Interfaces;

public interface IShowtimeService
{
    Task<IEnumerable<Showtime>> GetShowtimesByTheaterAsync(Guid theaterId);
    Task<IEnumerable<Showtime>> GetShowtimesByMovieAsync(Guid movieId);
    Task<Showtime> CreateShowtimeAsync(ShowtimePayload showtimePayload);
    Task<Showtime> GetByIdAsync(Guid id);
    Task UpdateAsync(Showtime Showtime);
}