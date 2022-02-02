namespace Movie.Tests.Unit.Engine
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Movie.Tests.Helpers;
    using Movie.Web.Api.Controllers;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;
    using Movie.Models.Contract;
    using SQL = Movie.Models.SQL;
    using Movie.Data.Engine.Interface;
    using Movie.Operation.Engine.EngineModel;
    using Movie.Common.Enum;

    [TestClass, TestCategory("Unit")]
    public class DataProcessEngineTests
    {
        private Mock<IDataProcessRepository> _dataProcessRepository;
        private Mock<IDataReadRepository> _dataReadRepository;

        private DataProcessEngine _dataProcessEngine;

        [TestInitialize]
        public void init()
        {
            _dataProcessRepository = new Mock<IDataProcessRepository>();
            _dataReadRepository = new Mock<IDataReadRepository>();

            _dataProcessEngine = new DataProcessEngine(_dataProcessRepository.Object, _dataReadRepository.Object);
        }

        [TestMethod]
        public async Task AddMovie_Success()
        {
            var movie = ModelContractHelper.GetMovieDetail().FirstOrDefault();
            _dataReadRepository.Setup(_ => _.GetCrewNamesByIds(It.IsAny<IList<int>>(), It.IsAny<PersonType>())).ReturnsAsync("a;b;c");
            _dataProcessRepository.Setup(_ => _.AddMovie(It.IsAny<SQL.MovieDetail>())).ReturnsAsync(true);

            var result = await _dataProcessEngine.AddMovie(movie).ConfigureAwait(false);

            Assert.IsTrue(result.Item1);
        }

        [TestMethod]
        public async Task AddMovie_Failure()
        {
            var movie = ModelContractHelper.GetMovieDetail().FirstOrDefault();
            _dataReadRepository.Setup(_ => _.GetCrewNamesByIds(It.IsAny<IList<int>>(), It.IsAny<PersonType>())).ReturnsAsync("a;b;c");
            _dataProcessRepository.Setup(_ => _.AddMovie(It.IsAny<SQL.MovieDetail>())).ReturnsAsync(false);

            var result = await _dataProcessEngine.AddMovie(movie).ConfigureAwait(false);

            Assert.IsFalse(result.Item1);
        }


        [TestMethod]
        public async Task AddActor_Success()
        {
            var actor = ModelContractHelper.GetActor();
            _dataProcessRepository.Setup(_ => _.AddActor(It.IsAny<SQL.Actor>())).ReturnsAsync(true);

            var result = await _dataProcessEngine.AddActor(actor).ConfigureAwait(false);

            Assert.IsTrue(result.Item1);
        }

        [TestMethod]
        public async Task AddActor_Failure()
        {
            var actor = ModelContractHelper.GetActor();
            _dataProcessRepository.Setup(_ => _.AddActor(It.IsAny<SQL.Actor>())).ReturnsAsync(false);

            var result = await _dataProcessEngine.AddActor(actor).ConfigureAwait(false);

            Assert.IsFalse(result.Item1);
        }


        [TestMethod]
        public async Task AddProducer_Success()
        {
            var producer = ModelContractHelper.GetProducer();
            _dataProcessRepository.Setup(_ => _.AddProducer(It.IsAny<SQL.Producer>())).ReturnsAsync(true);

            var result = await _dataProcessEngine.AddProducer(producer).ConfigureAwait(false);

            Assert.IsTrue(result.Item1);
        }


        [TestMethod]
        public async Task AddProducer_Failure()
        {
            var producer = ModelContractHelper.GetProducer();
            _dataProcessRepository.Setup(_ => _.AddProducer(It.IsAny<SQL.Producer>())).ReturnsAsync(false);

            var result = await _dataProcessEngine.AddProducer(producer).ConfigureAwait(false);

            Assert.IsFalse(result.Item1);
        }


        [TestMethod]
        public async Task UpdateMovie_Success()
        {
            var movie = ModelContractHelper.GetMovieDetail().FirstOrDefault();
            _dataReadRepository.Setup(_ => _.GetCrewNamesByIds(It.IsAny<IList<int>>(), It.IsAny<PersonType>())).ReturnsAsync("a;b;c");
            _dataProcessRepository.Setup(_ => _.UpdateMovie(It.IsAny<int>(), It.IsAny<SQL.MovieDetail>())).ReturnsAsync(true);

            var result = await _dataProcessEngine.UpdateMovie(It.IsAny<int>(), movie).ConfigureAwait(false);

            Assert.IsTrue(result.Item1);
        }

        [TestMethod]
        public async Task UpdateMovie_Failure()
        {
            var movie = ModelContractHelper.GetMovieDetail().FirstOrDefault();
            _dataReadRepository.Setup(_ => _.GetCrewNamesByIds(It.IsAny<IList<int>>(), It.IsAny<PersonType>())).ReturnsAsync("a;b;c");
            _dataProcessRepository.Setup(_ => _.UpdateMovie(It.IsAny<int>(), It.IsAny<SQL.MovieDetail>())).ReturnsAsync(false);

            var result = await _dataProcessEngine.UpdateMovie(It.IsAny<int>(), movie).ConfigureAwait(false);

            Assert.IsFalse(result.Item1);
        }


        [TestMethod]
        public async Task UpdateActor_Success()
        {
            var actor = ModelContractHelper.GetActor();
            _dataProcessRepository.Setup(_ => _.UpdateActor(It.IsAny<int>(), It.IsAny<SQL.Actor>())).ReturnsAsync(true);

            var result = await _dataProcessEngine.UpdateActor(It.IsAny<int>(), actor).ConfigureAwait(false);

            Assert.IsTrue(result.Item1);
        }

        [TestMethod]
        public async Task UpdateActor_Failure()
        {
            var actor = ModelContractHelper.GetActor();
            _dataProcessRepository.Setup(_ => _.UpdateActor(It.IsAny<int>(), It.IsAny<SQL.Actor>())).ReturnsAsync(false);

            var result = await _dataProcessEngine.UpdateActor(It.IsAny<int>(), actor).ConfigureAwait(false);

            Assert.IsFalse(result.Item1);
        }


        [TestMethod]
        public async Task UpdateProducer_Success()
        {
            var producer = ModelContractHelper.GetProducer();
            _dataProcessRepository.Setup(_ => _.UpdateProducer(It.IsAny<int>(), It.IsAny<SQL.Producer>())).ReturnsAsync(true);

            var result = await _dataProcessEngine.UpdateProducer(It.IsAny<int>(), producer).ConfigureAwait(false);

            Assert.IsTrue(result.Item1);
        }


        [TestMethod]
        public async Task UpdateProducer_Failure()
        {
            var producer = ModelContractHelper.GetProducer();
            _dataProcessRepository.Setup(_ => _.UpdateProducer(It.IsAny<int>(), It.IsAny<SQL.Producer>())).ReturnsAsync(false);

            var result = await _dataProcessEngine.UpdateProducer(It.IsAny<int>(), producer).ConfigureAwait(false);

            Assert.IsFalse(result.Item1);
        }
    }
}
