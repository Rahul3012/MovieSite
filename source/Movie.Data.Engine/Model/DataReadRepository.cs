namespace Movie.Data.Engine.Model
{
    using Movie.Models.UI;
    using Movie.Data.Engine.Interface;
    using System.Data;
    using System.Threading.Tasks;
    using Dapper;
    using Movie.Common.Enum;

    public class DataReadRepository : IDataReadRepository
    {
        readonly ISqlConnect _sqlConnect;

        public DataReadRepository(ISqlConnect sqlConnect)
        {
            _sqlConnect = sqlConnect;
        }

        public async Task<Actor> GetActor(int id)
        {
            using (var connection = _sqlConnect.GetDbConnection())
            {
                var param = new DynamicParameters();
                param.Add("@ActorId", id);
                var query = $@"select * from [dbo].[CrewDetail] where Id = @ActorId";
                var result = await connection.QueryFirstOrDefaultAsync<Actor>(query, param, commandType: CommandType.Text).ConfigureAwait(false);
                return result;
            };
        }

        public async Task<MovieDetail> GetMovieDetail(int id)
        {
            using (var connection = _sqlConnect.GetDbConnection())
            {
                var param = new DynamicParameters();
                param.Add("@MovieId", id);
                var query = $@"select * from [dbo].[MovieDetail] where Id = @MovieId";
                var result = await connection.QueryFirstOrDefaultAsync<MovieDetail>(query, param, commandType: CommandType.Text).ConfigureAwait(false);
                return result;
            };
        }

        public async Task<IList<MovieDetail>> GetMovieDetails()
        {
            using (var connection = _sqlConnect.GetDbConnection())
            {
                var param = new DynamicParameters();
                var query = $@"select * from [dbo].[MovieDetail]";
                var result = await connection.QueryAsync<MovieDetail>(query, commandType: CommandType.Text).ConfigureAwait(false);
                return result.ToList();
            };
        }

        public async Task<Producer> GetProducer(int id)
        {
            using (var connection = _sqlConnect.GetDbConnection())
            {
                var param = new DynamicParameters();
                param.Add("@ProducerId", id);
                var query = $@"select * from [dbo].[CrewDetail] where Id = @ProducerId";
                var result = await connection.QueryFirstOrDefaultAsync<Producer>(query, param, commandType: CommandType.Text).ConfigureAwait(false);
                return result;
            };
        }

        public async Task<string> GetCrewNamesByIds(IList<int> Ids, PersonType personType)
        {
            using (var connection = _sqlConnect.GetDbConnection())
            {
                var param = new DynamicParameters();
                var query = "select Name from [dbo].[CrewDetail] where Id in (" + string.Join(",", Ids) + ") and Type = " + ((int)personType);
                var result = await connection.QueryAsync<string>(query, commandType: CommandType.Text).ConfigureAwait(false);
                return string.Join(";", result);
            };
        }

        public async Task<IList<string>> GetCrewNames(PersonType personType)
        {
            using (var connection = _sqlConnect.GetDbConnection())
            {
                var param = new DynamicParameters();
                var query = "select Name from [dbo].[CrewDetail] where Type = " + ((int)personType);
                var result = await connection.QueryAsync<string>(query, commandType: CommandType.Text).ConfigureAwait(false);
                return result.ToList();
            };
        }
    }
}
