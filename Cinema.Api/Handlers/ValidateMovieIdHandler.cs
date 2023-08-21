namespace Cinema.Handlers;

public class ValidateMovieIdHandler: IRequestHandler<ValidateMovieIdCommand, bool>
{
    private readonly IMovieService _movieService;

    public ValidateMovieIdHandler(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public async Task<bool> Handle(ValidateMovieIdCommand request, CancellationToken cancellationToken)
    {
        var movie = await _movieService.GetMovieByIdAsync(request.Request);

        return movie != null;
    }
}