namespace Movie.Tests.Unit.API
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Movie.Operation.Engine.EngineInterface;
    using Movie.Tests.Helpers;
    using Movie.Web.Api.Controllers;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;
    using Movie.Models.Contract;
    using Movie.Operation.Engine.Validator.Interface;

    [TestClass, TestCategory("Unit")]
    public class DataProcessControllerTests
    {
        private Mock<IDataProcessEngine> _dataProcessEngine;
        private Mock<IMovieValidation> _movieValidation; 
        private DataProcessController _dataProcessController;

        [TestInitialize]
        public void init()
        {
            _dataProcessEngine = new Mock<IDataProcessEngine>();
            _movieValidation = new Mock<IMovieValidation>();
            _dataProcessController = new DataProcessController(_dataProcessEngine.Object, _movieValidation.Object);
        }

        [TestMethod]
        public async Task AddMovie_Success()
        {
            _dataProcessEngine.Setup(_ => _.AddMovie(It.IsAny<MovieDetail>())).ReturnsAsync((true, "Movie added"));
            _movieValidation.Setup(_ => _.ValidateRequest(It.IsAny<MovieDetail>())).Returns(new List<string>() { });

            var result = await _dataProcessController.AddMovie(It.IsAny<MovieDetail>()).ConfigureAwait(false);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task AddMovie_Failure()
        {
            _dataProcessEngine.Setup(_ => _.AddMovie(It.IsAny<MovieDetail>())).ReturnsAsync((false, "Movie not added"));
            _movieValidation.Setup(_ => _.ValidateRequest(It.IsAny<MovieDetail>())).Returns(new List<string>() { });

            var result = await _dataProcessController.AddMovie(It.IsAny<MovieDetail>()).ConfigureAwait(false);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task AddActor_Success()
        {
            _dataProcessEngine.Setup(_ => _.AddActor(It.IsAny<Actor>())).ReturnsAsync((true, "Actor added"));

            var result = await _dataProcessController.AddActor(It.IsAny<Actor>()).ConfigureAwait(false);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task AddActor_Failure()
        {
            _dataProcessEngine.Setup(_ => _.AddActor(It.IsAny<Actor>())).ReturnsAsync((false, "Actor not added"));

            var result = await _dataProcessController.AddActor(It.IsAny<Actor>()).ConfigureAwait(false);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task AddProducer_Success()
        {
            _dataProcessEngine.Setup(_ => _.AddProducer(It.IsAny<Producer>())).ReturnsAsync((true, "Producer added"));

            var result = await _dataProcessController.AddProducer(It.IsAny<Producer>()).ConfigureAwait(false);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task AddProducer_Failure()
        {
            _dataProcessEngine.Setup(_ => _.AddProducer(It.IsAny<Producer>())).ReturnsAsync((false, "Producer not added"));

            var result = await _dataProcessController.AddProducer(It.IsAny<Producer>()).ConfigureAwait(false);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task UpdateMovie_Success()
        {
            _dataProcessEngine.Setup(_ => _.UpdateMovie(It.IsAny<int>(), It.IsAny<MovieDetail>())).ReturnsAsync((true, "Movie updated"));
            _movieValidation.Setup(_ => _.ValidateRequest(It.IsAny<MovieDetail>())).Returns(new List<string>() { });

            var result = await _dataProcessController.UpdateMovie(It.IsAny<int>(), It.IsAny<MovieDetail>()).ConfigureAwait(false);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task UpdateMovie_Failure()
        {
            _dataProcessEngine.Setup(_ => _.UpdateMovie(It.IsAny<int>(), It.IsAny<MovieDetail>())).ReturnsAsync((false, "Movie not updated"));
            _movieValidation.Setup(_ => _.ValidateRequest(It.IsAny<MovieDetail>())).Returns(new List<string>() { });

            var result = await _dataProcessController.UpdateMovie(It.IsAny<int>(), It.IsAny<MovieDetail>()).ConfigureAwait(false);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task UpdateActor_Success()
        {
            _dataProcessEngine.Setup(_ => _.UpdateActor(It.IsAny<int>(), It.IsAny<Actor>())).ReturnsAsync((true, "Actor updated"));
            _movieValidation.Setup(_ => _.ValidateRequest(It.IsAny<MovieDetail>())).Returns(new List<string>() { });

            var result = await _dataProcessController.UpdateActor(It.IsAny<int>(), It.IsAny<Actor>()).ConfigureAwait(false);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task UpdateActor_Failure()
        {
            _dataProcessEngine.Setup(_ => _.UpdateActor(It.IsAny<int>(), It.IsAny<Actor>())).ReturnsAsync((false, "Actor not updated"));

            var result = await _dataProcessController.UpdateActor(It.IsAny<int>(), It.IsAny<Actor>()).ConfigureAwait(false);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task UpdateProducer_Success()
        {
            _dataProcessEngine.Setup(_ => _.UpdateProducer(It.IsAny<int>(), It.IsAny<Producer>())).ReturnsAsync((true, "Producer updated"));

            var result = await _dataProcessController.UpdateProducer(It.IsAny<int>(), It.IsAny<Producer>()).ConfigureAwait(false);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task UpdateProducer_Failure()
        {
            _dataProcessEngine.Setup(_ => _.UpdateProducer(It.IsAny<int>(), It.IsAny<Producer>())).ReturnsAsync((false, "Producer not updated"));
            _movieValidation.Setup(_ => _.ValidateRequest(It.IsAny<MovieDetail>())).Returns(new List<string>() { });

            var result = await _dataProcessController.UpdateProducer(It.IsAny<int>(), It.IsAny<Producer>()).ConfigureAwait(false);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
    }
}