namespace Cinema.Repositories.Implementations;

public class MovieRepository : IMovieRepository
{
    private readonly ApplicationDbContext _dbContext;

    public MovieRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        return await _dbContext.Movies.ToListAsync();
    }

    public async Task<Movie> GetByIdAsync(Guid id)
    {
        return await _dbContext.Movies.FindAsync(id);
    }

    public async Task<Movie> AddAsync(Movie movie)
    {
        _dbContext.Movies.Add(movie);
        await _dbContext.SaveChangesAsync();
        return movie;
    }

    public async Task UpdateAsync(Movie movie)
    {
        _dbContext.Movies.Update(movie);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Movie movie)
    {
        _dbContext.Movies.Remove(movie);
        await _dbContext.SaveChangesAsync();
    }
}
