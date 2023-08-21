namespace Cinema.Repositories.Implementations;

public class TheaterRepository : ITheaterRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TheaterRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Theater>> GetAllTheatersAsync()
    {
        return await _dbContext.Theaters.ToListAsync();
    }

    public async Task<Theater> GetTheaterByIdAsync(Guid id)
    {
        return await _dbContext.Theaters.FindAsync(id);
    }

    public async Task<Theater> CreateTheaterAsync(Theater theater)
    {
        _dbContext.Theaters.Add(theater);
        await _dbContext.SaveChangesAsync();

        return theater;
    }
}