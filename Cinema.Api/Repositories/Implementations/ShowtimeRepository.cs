namespace Cinema.Repositories.Implementations;

public class ShowtimeRepository : IShowtimeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ShowtimeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Showtime>> GetShowtimesByTheaterAsync(Guid theaterId)
    {
        return await _dbContext.Showtimes.Where(t => t.TheaterId == theaterId).ToListAsync();
    }

    public async Task<IEnumerable<Showtime>> GetShowtimesByMovieAsync(Guid movieId)
    {
        return await _dbContext.Showtimes.Where(t => t.MovieId == movieId).ToListAsync();
    }

    public async Task<Showtime> CreateShowtimeAsync(Showtime showtime)
    {
        _dbContext.Showtimes.Add(showtime);
        await _dbContext.SaveChangesAsync();
        return showtime;
    }

    public async Task<Showtime> GetByIdAsync(Guid id)
    {
        return await _dbContext.Showtimes.FindAsync(id);
    }

    public async Task UpdateAsync(Showtime Showtime)
    {
        _dbContext.Showtimes.Update(Showtime);
        await _dbContext.SaveChangesAsync();
    }
}