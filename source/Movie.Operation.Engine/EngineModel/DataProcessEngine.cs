namespace Movie.Operation.Engine.EngineModel
{
    using Movie.Models.Contract;
    using SQL = Movie.Models.SQL;
    using Movie.Data.Engine.Interface;
    using Movie.Operation.Engine.EngineInterface;
    using System.Threading.Tasks;
    using Movie.Common.Enum;

    public class DataProcessEngine : IDataProcessEngine
    {
        IDataProcessRepository _dataProcessRepository;
        IDataReadRepository _dataReadRepository;

        public DataProcessEngine(IDataProcessRepository dataProcessRepository, IDataReadRepository dataReadRepository)
        {
            _dataProcessRepository = dataProcessRepository;
            _dataReadRepository = dataReadRepository;
        }

        public async Task<(bool, string)> AddActor(Actor actor)
        {
            var actorDetail = new SQL.Actor()
            {
                Type = actor.Type,
                Name = actor.Name,
                Bio = actor.Bio,
                DOB = actor.DOB,
                Gender = actor.Gender
            };
            var isActorAdded = await _dataProcessRepository.AddActor(actorDetail).ConfigureAwait(false);
            if (isActorAdded)
                return (true, "Actor added successfully");
            return (false, "Cannot add actor. Check logs for more information");
        }

        public async Task<(bool, string)> AddMovie(MovieDetail movieDetail)
        {
            var actorsNames = await GetCrewNames(movieDetail.ActorIds, PersonType.Actor).ConfigureAwait(false);
            var producersNames = await GetCrewNames(movieDetail.ProducerIds, PersonType.Producer).ConfigureAwait(false);
            var movie = new SQL.MovieDetail()
            {
                Name = movieDetail.Name,
                ReleasedDate = movieDetail.ReleasedDate,
                Plot = movieDetail.Plot,
                Producers = producersNames,
                Actors = actorsNames,
                Poster = movieDetail.Poster
            };
            var isMovieAdded = await _dataProcessRepository.AddMovie(movie).ConfigureAwait(false);
            if (isMovieAdded)
                return (true, "Movie added successfully");
            return (false, "Cannot add movie. Check logs for more information");
        }

        public async Task<(bool, string)> AddProducer(Producer producer)
        {
            var producerDetail = new SQL.Producer()
            {
                Type = producer.Type,
                Name = producer.Name,
                Bio = producer.Bio,
                DOB = producer.DOB,
                Gender = producer.Gender,
                Company = producer.Company
            };
            var isProducerAdded = await _dataProcessRepository.AddProducer(producerDetail).ConfigureAwait(false);
            if (isProducerAdded)
                return (true, "Producer added successfully");
            return (false, "Cannot add producer. Check logs for more information");
        }

        public async Task<(bool, string)> UpdateActor(int actorId, Actor actor)
        {
            var actorDetail = new SQL.Actor()
            {
                Type = actor.Type,
                Name = actor.Name,
                Bio = actor.Bio,
                DOB = actor.DOB,
                Gender = actor.Gender
            };
            var isActorAdded = await _dataProcessRepository.UpdateActor(actorId, actorDetail).ConfigureAwait(false);
            if (isActorAdded)
                return (true, "Actor updated successfully");
            return (false, "Cannot add actor. Check logs for more information");
        }

        public async Task<(bool, string)> UpdateMovie(int movieId, MovieDetail movieDetail)
        {
            var actorsNames = await GetCrewNames(movieDetail.ActorIds, PersonType.Actor).ConfigureAwait(false);
            var producersNames = await GetCrewNames(movieDetail.ProducerIds, PersonType.Producer).ConfigureAwait(false);
            var movie = new SQL.MovieDetail()
            {
                Name = movieDetail.Name,
                ReleasedDate = movieDetail.ReleasedDate,
                Plot = movieDetail.Plot,
                Producers = producersNames,
                Actors = actorsNames
            };
            var isMovieAdded = await _dataProcessRepository.UpdateMovie(movieId, movie).ConfigureAwait(false);
            if (isMovieAdded)
                return (true, "Movie updated successfully");
            return (false, "Cannot add movie. Check logs for more information");
        }

        public async Task<(bool, string)> UpdateProducer(int producerId, Producer producer)
        {
            var producerDetail = new SQL.Producer()
            {
                Type = producer.Type,
                Name = producer.Name,
                Bio = producer.Bio,
                DOB = producer.DOB,
                Gender = producer.Gender,
                Company = producer.Company
            };
            var isProducerAdded = await _dataProcessRepository.UpdateProducer(producerId, producerDetail).ConfigureAwait(false);
            if (isProducerAdded)
                return (true, "Producer updated successfully");
            return (false, "Cannot update producer. Check logs for more information");
        }

        private async Task<string> GetCrewNames(IList<int> Ids, PersonType personType)
        {
            return await _dataReadRepository.GetCrewNamesByIds(Ids, personType).ConfigureAwait(false);
        }
    }
}
