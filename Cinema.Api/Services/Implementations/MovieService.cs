namespace Cinema.Services.Implementations;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
    {
        return await _movieRepository.GetAllAsync();
    }

    public async Task<Movie> GetMovieByIdAsync(Guid id)
    {
        return await _movieRepository.GetByIdAsync(id);
    }

    public async Task<Movie> CreateMovieAsync(MoviePayload moviePayload)
    {
        var movie = new Movie
        {
            Title = moviePayload.Title,
            Description = moviePayload.Description,
            DurationMinutes = moviePayload.DurationMinutes,
            Genre = moviePayload.Genre,
            Director = moviePayload.Director
        };
        
        var createdMovie = await _movieRepository.AddAsync(movie);
        return createdMovie;
    }

    public async Task<Movie> UpdateMovieAsync(Guid id, MoviePayload moviePayload)
    {
        var existingMovie = await _movieRepository.GetByIdAsync(id);
        if (existingMovie == null)
        {
            throw new NotFoundApiException($"Movie with id: {id} not found");
        }
        
        existingMovie.Title = moviePayload.Title;
        existingMovie.Description = moviePayload.Description;
        existingMovie.Genre = moviePayload.Genre;
        existingMovie.DurationMinutes = moviePayload.DurationMinutes;

        await _movieRepository.UpdateAsync(existingMovie);
        return existingMovie;
    }

    public async Task DeleteMovieAsync(Guid id)
    {
        var existingMovie = await _movieRepository.GetByIdAsync(id);
        if (existingMovie == null)
        {
            throw new NotFoundApiException($"Movie with id: {id} not found");
        }
        
       await _movieRepository.DeleteAsync(existingMovie);
    }
}
