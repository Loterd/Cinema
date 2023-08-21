using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    /// <summary>
    /// Returns all movies
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Movie>), 200)]
    public async Task<IActionResult> GetAllMovies()
    {
        var movies = await _movieService.GetAllMoviesAsync();
        return Ok(movies);
    }

    /// <summary>
    /// Returns movie by id
    /// </summary>
    [HttpGet("{id:Guid}")]
    [ProducesResponseType(typeof(Movie), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetMovieById(Guid id)
    {
        var movie = _movieService.GetMovieByIdAsync(id);
        if (movie == null)
        {
            return NotFound();
        }
        return Ok(movie);
    }

    /// <summary>
    /// Creates a new movie
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(Movie), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateMovie([FromBody] MoviePayload movie)
    {
        if (movie == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdMovie = await _movieService.CreateMovieAsync(movie);
        return CreatedAtAction(nameof(CreateMovie), new { id = createdMovie.Id }, createdMovie);
    }

    /// <summary>
    /// Update existing movie
    /// </summary>
    [HttpPut("{id:Guid}")]
    [ProducesResponseType(typeof(Movie), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateMovie(Guid id, [FromBody] MoviePayload movie)
    {
        if (movie == null)
        {
            return BadRequest();
        }
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updatedMovie = await _movieService.UpdateMovieAsync(id, movie);
        return Ok(updatedMovie);
    }

    /// <summary>
    /// Deletes existing movie
    /// </summary>
    [HttpDelete("{id:Guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteMovie(Guid id)
    {
        await _movieService.DeleteMovieAsync(id);
        return NoContent();
    }
}