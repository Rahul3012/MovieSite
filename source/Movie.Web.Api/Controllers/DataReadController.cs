namespace Movie.Web.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Movie.Common.Enum;
    using Movie.Data.Engine.Interface;

    [Route("api/v1/[controller]")]
    public class DataReadController : Controller
    {
        readonly IDataReadRepository _dataReadRepository;

        public DataReadController(IDataReadRepository dataReadRepository)
        {
            _dataReadRepository = dataReadRepository;
        }

        [HttpGet]
        [Route("movies")]
        public async Task<ActionResult> GetMovies()
        {
            var movies = await _dataReadRepository.GetMovieDetails().ConfigureAwait(false);
            if (movies.Any())
            {
                return Ok(movies);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("movies/{movieId}")]
        public async Task<ActionResult> GetMovie(int movieId)
        {
            var movie = await _dataReadRepository.GetMovieDetail(movieId).ConfigureAwait(false);
            if (movie != null)
            {
                return Ok(movie);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("actor/{actorId}")]
        public async Task<ActionResult> GetActor(int actorId)
        {
            var actor = await _dataReadRepository.GetActor(actorId).ConfigureAwait(false);
            if (actor != null)
            {
                return Ok(actor);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("producer/{producerId}")]
        public async Task<ActionResult> GetProducer(int producerId)
        {
            var producer = await _dataReadRepository.GetProducer(producerId).ConfigureAwait(false);
            if (producer != null)
            {
                return Ok(producer);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("crewnames/{type}")]
        public async Task<ActionResult> GetCrewNames(PersonType type)
        {
            var crewNames = await _dataReadRepository.GetCrewNames(type).ConfigureAwait(false);
            if(crewNames.Any())
            {
                return Ok(crewNames);
            }
            return NoContent();
        }
    }
}
