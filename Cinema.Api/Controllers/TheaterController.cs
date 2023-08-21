using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TheaterController : ControllerBase
{
    private readonly ITheaterService _theaterService;

    public TheaterController(ITheaterService theaterService)
    {
        _theaterService = theaterService;
    }
    
    /// <summary>
    /// Returns all theaters
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Theater>), 200)]
    public async Task<IActionResult> GetAllTheaters()
    {
        var results = await _theaterService.GetAllTheatersAsync();
        return Ok(results);
    }

    /// <summary>
    /// Returns theater by id
    /// </summary>
    [HttpGet("{id:Guid}")]
    [ProducesResponseType(typeof(Theater), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetTheaterById(Guid id)
    {
        var theater = _theaterService.GetTheaterByIdAsync(id);
        if (theater == null)
        {
            return NotFound();
        }
        return Ok(theater);
    }

    /// <summary>
    /// Creates a new theater
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(Theater), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateTheater([FromBody] TheaterPayload theater)
    {
        if (theater == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdTheater = await _theaterService.CreateTheaterAsync(theater);
        return CreatedAtAction(nameof(CreateTheater), new { id = createdTheater.Id }, createdTheater);
    }
}