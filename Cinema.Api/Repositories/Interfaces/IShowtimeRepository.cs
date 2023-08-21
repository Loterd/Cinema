namespace Cinema.Repositories.Interfaces;

public interface IShowtimeRepository
{
    Task<IEnumerable<Showtime>> GetShowtimesByTheaterAsync(Guid theaterId);
    Task<IEnumerable<Showtime>> GetShowtimesByMovieAsync(Guid movieId);
    Task<Showtime> CreateShowtimeAsync(Showtime showtime);
    Task<Showtime> GetByIdAsync(Guid id);
    Task UpdateAsync(Showtime Showtime);
}