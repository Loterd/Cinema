namespace Cinema.Repositories.Implementations;

public class UserReservationRepository : IUserReservationRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserReservationRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserReservation> AddAsync(UserReservation userReservation)
    {
        _dbContext.UserReservations.Add(userReservation);
        await _dbContext.SaveChangesAsync();
        return userReservation;
    }

    public  async Task UpdateAsync(UserReservation userReservation)
    {
        _dbContext.UserReservations.Update(userReservation);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<UserReservation> GetByIdAsync(Guid id)
    {
        return await _dbContext.UserReservations.FindAsync(id);
    }
}