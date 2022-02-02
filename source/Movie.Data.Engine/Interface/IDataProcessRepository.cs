namespace Movie.Data.Engine.Interface
{
    using Movie.Models.SQL;

    public interface IDataProcessRepository
    {
        Task<bool> AddMovie(MovieDetail actor);
        Task<bool> AddActor(Actor actor);
        Task<bool> AddProducer(Producer producer);
        Task<bool> UpdateMovie(int movieId, MovieDetail movieDetail);
        Task<bool> UpdateActor(int actorId, Actor actor);
        Task<bool> UpdateProducer(int producerId, Producer producer);
    }
}
