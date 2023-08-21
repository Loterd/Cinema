using Cinema.Models;
using Cinema.Repositories.Interfaces;
using Cinema.Services.Implementations;
using Cinema.Services.Interfaces;
using Moq;

namespace Cinema.Tests;

public class MovieServiceTests
    {
        private Mock<IMovieRepository> _mockMovieRepository;
        private IMovieService _movieService;

        public MovieServiceTests()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
            _movieService = new MovieService(_mockMovieRepository.Object);
        }

        [Fact]
        public async Task GetAllMoviesAsync_ReturnsListOfMovies()
        {
            var movies = new List<Movie>
            {
                new Movie { Id = Guid.NewGuid(), Title = "Movie 1" },
                new Movie { Id = Guid.NewGuid(), Title = "Movie 2" }
            };

            _mockMovieRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(movies);

            var result = await _movieService.GetAllMoviesAsync();

            Assert.Equal(movies, result);
        }

        [Fact]
        public async Task GetMovieByIdAsync_ExistingId_ReturnsMovie()
        {
            var movieId = Guid.NewGuid();
            var movie = new Movie { Id = movieId, Title = "Movie 1" };

            _mockMovieRepository.Setup(repo => repo.GetByIdAsync(movieId)).ReturnsAsync(movie);

            var result = await _movieService.GetMovieByIdAsync(movieId);

            Assert.Equal(movie, result);
        }

        [Fact]
        public async Task GetMovieByIdAsync_NonExistingId_ReturnsNull()
        {
            var nonExistingId = Guid.NewGuid();

            _mockMovieRepository.Setup(repo => repo.GetByIdAsync(nonExistingId)).ReturnsAsync((Movie)null);

            var result = await _movieService.GetMovieByIdAsync(nonExistingId);

            Assert.Null(result);
        }

        [Fact]
        public async Task CreateMovieAsync_ValidPayload_CreatesMovie()
        {
            var moviePayload = new MoviePayload
            {
                Title = "New Movie",
                Description = "Description",
                DurationMinutes = 120,
                Genre = "Action",
                Director = "Director"
            };

            var createdMovie = new Movie
            {
                Id = Guid.NewGuid(),
                Title = moviePayload.Title,
                Description = moviePayload.Description,
                DurationMinutes = moviePayload.DurationMinutes,
                Genre = moviePayload.Genre,
                Director = moviePayload.Director
            };

            _mockMovieRepository.Setup(repo => repo.AddAsync(It.IsAny<Movie>())).ReturnsAsync(createdMovie);

            var result = await _movieService.CreateMovieAsync(moviePayload);

            Assert.Equal(createdMovie, result);
        }
    }