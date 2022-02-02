namespace Movie.Tests.Helpers
{
    using Movie.Common.Enum;
    using Movie.Models.UI;
    using System;
    using System.Collections.Generic;

    public class ModelUIHelper
    {
        public static List<MovieDetail> GetMovieDetail()
        {
            return new List<MovieDetail>()
            {
                new MovieDetail()
                {
                    Id = 1,
                    Name = "Test",
                    ReleasedDate = DateTime.Now,
                    Actors = "Test1;Test2",
                    Producers = "Test1;Test2",
                    Plot = "TestPlot"
                }
            };
        }


        public static Actor GetActor()
        {
            return new Actor()
            {
                Id = 1,
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
                Id = 1,
                Name = "TestActor",
                DOB = DateTime.Now,
                Bio = "test",
                Gender = Gender.Male,
                Company = "TEST"
            };
        }
    }
}
