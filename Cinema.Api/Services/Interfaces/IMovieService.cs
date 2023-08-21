namespace Cinema.Services.Interfaces;

public interface IMovieService
{
    Task<IEnumerable<Movie>> GetAllMoviesAsync();
    Task<Movie> GetMovieByIdAsync(Guid id);
    Task<Movie> CreateMovieAsync(MoviePayload moviePayload);
    Task<Movie> UpdateMovieAsync(Guid id, MoviePayload moviePayload);
    Task DeleteMovieAsync(Guid id);
}