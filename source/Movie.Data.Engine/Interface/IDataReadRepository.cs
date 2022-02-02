namespace Movie.Data.Engine.Interface
{
    using Movie.Common.Enum;
    using Movie.Models.UI;

    public interface IDataReadRepository
    {
        Task<IList<MovieDetail>> GetMovieDetails();
        Task<MovieDetail> GetMovieDetail(int id);
        Task<Actor> GetActor(int id);
        Task<Producer> GetProducer(int id);
        Task<string> GetCrewNamesByIds(IList<int> Ids, PersonType personType);
        Task<IList<string>> GetCrewNames(PersonType personType);
    }
}
