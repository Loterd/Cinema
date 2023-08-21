using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserReservationsController : ControllerBase
{
    private readonly IUserReservationService _userReservationService;

    public UserReservationsController(IUserReservationService userReservationService)
    {
        _userReservationService = userReservationService;
    }

    /// <summary>
    /// Creates a new user reservation
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(UserReservation), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateReservation([FromBody] CreateUserReservationPayload payload)
    {
        if (payload == null)
        {
            return BadRequest();
        }

        var createdReservation = await _userReservationService.CreateReservation(payload);
        return CreatedAtAction(nameof(CreateReservation), new { id = createdReservation.Id }, createdReservation);
    }

    /// <summary>
    /// Confirms existing user reservation
    /// </summary>
    [HttpPost("{id:Guid}/confirm")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> ConfirmReservation(Guid id)
    {
        await _userReservationService.ConfirmReservation(id);
        return NoContent();
    }
}
