namespace Movie.Data.Engine.Model
{
    using Movie.Models.SQL;
    using Movie.Data.Engine.Interface;
    using Dapper;
    using Movie.Common.Enum;

    public class DataProcessRepository : IDataProcessRepository
    {
        readonly ISqlConnect _sqlConnect;
        public DataProcessRepository(ISqlConnect sqlConnect)
        {
            _sqlConnect = sqlConnect;
        }
        public async Task<bool> AddActor(Actor actor)
        {
            using (var connection = _sqlConnect.GetDbConnection())
            {
                var param = new DynamicParameters();
                param.Add("@Type", actor.Type);
                param.Add("@Name", actor.Name);
                param.Add("@Bio", actor.Bio);
                param.Add("@DOB", actor.DOB);
                param.Add("@Gender", actor.Gender);
                var query = $@"insert into [dbo].[CrewDetail] (Type, Name, DOB, Bio, Gender) values(@Type, @Name, @DOB, @Bio, @Gender)";
                var result = await connection.ExecuteAsync(query, actor).ConfigureAwait(false);
                return result > 0;
            };
        }

        public async Task<bool> AddMovie(MovieDetail movie)
        {
            using (var connection = _sqlConnect.GetDbConnection())
            {
                var param = new DynamicParameters();
                param.Add("@Name", movie.Name);
                param.Add("@ReleasedDate", movie.ReleasedDate);
                param.Add("@Plot", movie.Plot);
                param.Add("@Actors", movie.Actors);
                param.Add("@Producers", movie.Producers);
                param.Add("@Poster", movie.Poster);

                var query = $@"insert into [dbo].[MovieDetail] values(@Name, @ReleasedDate, @Plot, @Actors, @Producers, @Poster)";
                var result = await connection.ExecuteAsync(query, movie).ConfigureAwait(false);
                return result > 0;
            };
        }

        public async Task<bool> AddProducer(Producer producer)
        {
            using (var connection = _sqlConnect.GetDbConnection())
            {
                var param = new DynamicParameters();
                param.Add("@Type", producer.Type);
                param.Add("@Name", producer.Name);
                param.Add("@Bio", producer.Bio);
                param.Add("@DOB", producer.DOB);
                param.Add("@Gender", producer.Gender);
                param.Add("@Company", producer.Company);
                var query = $@"insert into [dbo].[CrewDetail] values(@Type, @Name,@DOB, @Bio, @Gender, @Company)";
                var result = await connection.ExecuteAsync(query, producer).ConfigureAwait(false);
                return result > 0;
            };
        }

        public async Task<bool> UpdateActor(int actorId, Actor actor)
        {
            using (var connection = _sqlConnect.GetDbConnection())
            {
                var param = new DynamicParameters();
                param.Add("@ActorId", actorId);
                param.Add("@Type", actor.Type);
                param.Add("@Name", actor.Name);
                param.Add("@Bio", actor.Bio);
                param.Add("@DOB", actor.DOB);
                param.Add("@Gender", actor.Gender);
                var query = $@"UPDATE [dbo].[CrewDetail]  
                               SET Type = @Type,
                                   Name = @Name, 
                                   DOB = @DOB,
                                   Bio = @Bio,
                                   Gender = @Gender
                               WHERE Id = {actorId}";
                var result = await connection.ExecuteAsync(query, actor).ConfigureAwait(false);
                return result > 0;
            };
        }

        public async Task<bool> UpdateMovie(int movieId, MovieDetail movie)
        {
            using (var connection = _sqlConnect.GetDbConnection())
            {
                var param = new DynamicParameters();
                param.Add("@Name", movie.Name);
                param.Add("@ReleasedDate", movie.ReleasedDate);
                param.Add("@Plot", movie.Plot);
                param.Add("@Actors", movie.Actors);
                param.Add("@Producers", movie.Producers);
                param.Add("@Poster", movie.Poster);

                var query = $@"UPDATE [dbo].[MovieDetail]  
                               SET Name = @Name, 
                                   ReleasedDate = @ReleasedDate,
                                   Plot = @Plot,
                                   Actors = @Actors,
                                   Producers = @Producers,
                                   Poster = @Poster
                               WHERE Id = {movieId}";
                var result = await connection.ExecuteAsync(query, movie).ConfigureAwait(false);
                return result > 0;
            };
        }

        public async Task<bool> UpdateProducer(int producerId, Producer producer)
        {
            using (var connection = _sqlConnect.GetDbConnection())
            {
                var param = new DynamicParameters();
                param.Add("@Type", producer.Type);
                param.Add("@Name", producer.Name);
                param.Add("@Bio", producer.Bio);
                param.Add("@DOB", producer.DOB);
                param.Add("@Gender", producer.Gender);
                param.Add("@Company", producer.Company);
                var query = $@"UPDATE [dbo].[CrewDetail] 
                               SET Type = @Type,
                                   Name = @Name, 
                                   DOB = @DOB,
                                   Bio = @Bio,
                                   Gender = @Gender,
                                   Company = @Company
                               WHERE Id = {producerId}";
                var result = await connection.ExecuteAsync(query, producer).ConfigureAwait(false);
                return result > 0;
            };
        }
    }
}
