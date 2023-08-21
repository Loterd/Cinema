namespace Cinema.Repositories.Interfaces;

public interface ITheaterRepository
{
    Task<IEnumerable<Theater>> GetAllTheatersAsync();
    Task<Theater> GetTheaterByIdAsync(Guid id);
    Task<Theater> CreateTheaterAsync(Theater theater);
}