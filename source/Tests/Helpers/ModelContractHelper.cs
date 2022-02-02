
namespace Movie.Tests.Helpers
{
    using Movie.Common.Enum;
    using Movie.Models.Contract;
    using System;
    using System.Collections.Generic;

    public class ModelContractHelper
    {
        public static List<MovieDetail> GetMovieDetail()
        {
            return new List<MovieDetail>()
            {
                new MovieDetail()
                {
                    Name = "Test",
                    ReleasedDate = DateTime.Now,
                    ActorIds = new List<int>() { 1,2,3},
                    ProducerIds = new List<int>() { 1,2,3},
                    Plot = "TestPlot"
                }
            };
        }


        public static Actor GetActor()
        {
            return new Actor()
            {
                Name = "TestActor",
                DOB = DateTime.Now,
                Bio = "test",
                Gender = Gender.Male
            };
        }

        public static Producer GetProducer()
        {
            return new Producer()
            {
                Name = "TestActor",
                DOB = DateTime.Now,
                Bio = "test",
                Gender = Gender.Male,
                Company = "TEST"
            };
        }
    }
}
