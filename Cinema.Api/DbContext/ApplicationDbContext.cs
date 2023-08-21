namespace Cinema.DbContext;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public virtual DbSet<Movie> Movies { get; set; }
    public virtual DbSet<Showtime> Showtimes { get; set; }
    public virtual DbSet<Theater> Theaters { get; set; }
    public virtual DbSet<UserReservation> UserReservations { get; set; }
}