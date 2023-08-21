using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShowtimesController : ControllerBase
{
    private readonly IShowtimeService _showtimeService;

    public ShowtimesController(IShowtimeService showtimeService)
    {
        _showtimeService = showtimeService;
    }

    /// <summary>
    /// Returns showtime for provided theaterId
    /// </summary>
    [HttpGet("theater/{theaterId:Guid}")]
    [ProducesResponseType(typeof(IEnumerable<Showtime>), 200)]
    public async Task<IActionResult> GetShowtimesByTheater(Guid theaterId)
    {
        var showtimes = await _showtimeService.GetShowtimesByTheaterAsync(theaterId);
        return Ok(showtimes);
    }

    /// <summary>
    /// Returns showtime for provided movieId
    /// </summary>
    [HttpGet("movie/{movieId:Guid}")]
    [ProducesResponseType(typeof(IEnumerable<Showtime>), 200)]
    public async Task<IActionResult> GetShowtimesByMovie(Guid movieId)
    {
        var showtimes = await _showtimeService.GetShowtimesByMovieAsync(movieId);
        return Ok(showtimes);
    }

    /// <summary>
    /// Returns showtime showtime id
    /// </summary>
    [HttpGet("{id:Guid}")]
    [ProducesResponseType(typeof(Showtime), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var showtime = await _showtimeService.GetByIdAsync(id);
        if (showtime == null)
        {
            return NotFound();
        }
        return Ok(showtime);
    }

    /// <summary>
    /// Creates a new showtime
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(Showtime), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateShowtime([FromBody] ShowtimePayload showtimePayload)
    {
        if (showtimePayload == null)
        {
            return BadRequest();
        }
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdShowtime = await _showtimeService.CreateShowtimeAsync(showtimePayload);
        return CreatedAtAction(nameof(GetById), new { id = createdShowtime.Id }, createdShowtime);
    }
}
