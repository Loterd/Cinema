using Newtonsoft.Json;

namespace Cinema.Services.Implementations;

public class TheaterService : ITheaterService
{
    private readonly ITheaterRepository _theaterRepository;

    public TheaterService(ITheaterRepository theaterRepository)
    {
        _theaterRepository = theaterRepository;
    }
    
    public async Task<IEnumerable<Theater>> GetAllTheatersAsync()
    {
        return await _theaterRepository.GetAllTheatersAsync();
    }

    public async Task<Theater> GetTheaterByIdAsync(Guid id)
    {
        return await _theaterRepository.GetTheaterByIdAsync(id);
    }

    public async Task<Theater> CreateTheaterAsync(TheaterPayload theaterPayload)
    {
        var theater = new Theater
        {
            Name = theaterPayload.Name,
            SeatingArrangementJson = JsonConvert.SerializeObject(theaterPayload.SeatingArrangement)
        };
        
        return await _theaterRepository.CreateTheaterAsync(theater);
    }
}