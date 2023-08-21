namespace Cinema.Services.Interfaces;

public interface ITheaterService
{
    Task<IEnumerable<Theater>> GetAllTheatersAsync();
    Task<Theater> GetTheaterByIdAsync(Guid id);
    Task<Theater> CreateTheaterAsync(TheaterPayload theaterPayload);
}