using Movie.Models.Contract;

namespace Movie.Operation.Engine.EngineInterface
{
    public interface IDataProcessEngine
    {
        Task<(bool, string)> AddMovie(MovieDetail actor);
        Task<(bool, string)> AddActor(Actor actor);
        Task<(bool, string)> AddProducer(Producer producer);
        Task<(bool, string)> UpdateMovie(int movieId, MovieDetail movieDetail);
        Task<(bool, string)> UpdateActor(int actorId, Actor actor);
        Task<(bool, string)> UpdateProducer(int producerId, Producer producer);
    }
}