namespace Cinema.Commands;

public class ValidateMovieIdCommand : IRequest<bool>
{
    public ValidateMovieIdCommand(Guid request)
    {
    }

    public Guid Request { get; set; }
}