namespace Movie.Web.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Movie.Models.Contract;
    using Movie.Operation.Engine.EngineInterface;
    using Movie.Operation.Engine.Validator.Interface;

    [Route("api/v1/[controller]")]
    public class DataProcessController : Controller
    {
        readonly IDataProcessEngine _dataProcessEngine;
        readonly IMovieValidation _movieValidation;
        
        public DataProcessController(IDataProcessEngine dataProcessEngine, IMovieValidation movieValidation)
        {
            _dataProcessEngine = dataProcessEngine;
            _movieValidation = movieValidation; 
        }

        [HttpPost]
        [Route("movie/add")]
        public async Task<ActionResult> AddMovie([FromBody] MovieDetail movieDetail)
        {
            var validation = _movieValidation.ValidateRequest(movieDetail);
            if (validation.Any())
            {
                return BadRequest(validation);
            }
            var (isMovieAdded, message) = await _dataProcessEngine.AddMovie(movieDetail).ConfigureAwait(false);
            if (isMovieAdded)
                return Ok(message);
            return BadRequest(message);
        }

        [HttpPost]
        [Route("actor/add")]
        public async Task<ActionResult> AddActor([FromBody] Actor actor)
        {
            var (isActorAdded, message) = await _dataProcessEngine.AddActor(actor).ConfigureAwait(false);
            if (isActorAdded)
                return Ok(message);
            return BadRequest(message);
        }

        [HttpPost]
        [Route("producer/add")]
        public async Task<ActionResult> AddProducer([FromBody] Producer producer)
        {
            var (isProducerAdded, message) = await _dataProcessEngine.AddProducer(producer).ConfigureAwait(false);
            if (isProducerAdded)
                return Ok(message);
            return BadRequest(message);
        }

        [HttpPut]
        [Route("movie/{movieId}/update")]
        public async Task<ActionResult> UpdateMovie(int movieId, [FromBody] MovieDetail movieDetail)
        {
            var validation = _movieValidation.ValidateRequest(movieDetail);
            if (validation.Any())
            {
                return BadRequest(validation);
            }
            var (isMovieUpdated, message) = await _dataProcessEngine.UpdateMovie(movieId, movieDetail).ConfigureAwait(false);
            if (isMovieUpdated)
                return Ok(message);
            return BadRequest(message);
        }

        [HttpPut]
        [Route("actor/{actorId}/update")]
        public async Task<ActionResult> UpdateActor(int actorId, [FromBody] Actor actor)
        {
            var (isActorUpdated, message) = await _dataProcessEngine.UpdateActor(actorId, actor).ConfigureAwait(false);
            if (isActorUpdated)
                return Ok(message);
            return BadRequest(message);
        }

        [HttpPut]
        [Route("producer/{producerId}/update")]
        public async Task<ActionResult> UpdateProducer(int producerId, [FromBody] Producer producer)
        {
            var (isProducerUpdated, message) = await _dataProcessEngine.UpdateProducer(producerId, producer).ConfigureAwait(false);
            if (isProducerUpdated)
                return Ok(message);
            return BadRequest(message);
        }
    }
}
