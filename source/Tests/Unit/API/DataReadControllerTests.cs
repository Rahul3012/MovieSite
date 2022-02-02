namespace Movie.Tests.Unit.API
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Movie.Tests.Helpers;
    using Movie.Web.Api.Controllers;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;
    using Movie.Models.UI;
    using Movie.Data.Engine.Interface;

    [TestClass, TestCategory("Unit")]
    public class DataReadControllerTests
    {
        private Mock<IDataReadRepository> _dataReadRepository;
        private DataReadController _dataReadController;

        [TestInitialize]
        public void init()
        {
            _dataReadRepository = new Mock<IDataReadRepository>();
            _dataReadController = new DataReadController(_dataReadRepository.Object);
        }

        [TestMethod]
        public async Task DataReadController_GetMovieDetails_Success()
        {
            var movieDetail = ModelUIHelper.GetMovieDetail();

            _dataReadRepository.Setup(_ => _.GetMovieDetails()).ReturnsAsync(movieDetail);

            var result = await _dataReadController.GetMovies().ConfigureAwait(false);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var output = result as OkObjectResult;
            var movie = output.Value as List<MovieDetail>;

            Assert.AreEqual(movie.Count, movieDetail.Count);
            Assert.AreEqual(movie.FirstOrDefault().Id, movieDetail.FirstOrDefault().Id);
        }

        [TestMethod]
        public async Task DataReadController_GetMovieDetails_EmptyResult()
        {
            var movieDetail = new List<MovieDetail>() { };

            _dataReadRepository.Setup(_ => _.GetMovieDetails()).ReturnsAsync(movieDetail);

            var result = await _dataReadController.GetMovies().ConfigureAwait(false);

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DataReadController_GetMovieDetail_Success()
        {
            var movieDetail = ModelUIHelper.GetMovieDetail().FirstOrDefault();

            _dataReadRepository.Setup(_ => _.GetMovieDetail(It.IsAny<int>())).ReturnsAsync(movieDetail);

            var result = await _dataReadController.GetMovie(It.IsAny<int>()).ConfigureAwait(false);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var output = result as OkObjectResult;
            var movie = output.Value as MovieDetail;

            Assert.AreEqual(movie.Id, movieDetail.Id);
        }

        [TestMethod]
        public async Task DataReadController_GetMovieDetail_EmptyResult()
        {
            MovieDetail movieDetail = null;

            _dataReadRepository.Setup(_ => _.GetMovieDetail(It.IsAny<int>())).ReturnsAsync(movieDetail);

            var result = await _dataReadController.GetMovie(It.IsAny<int>()).ConfigureAwait(false);

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DataReadController_GetActor_Success()
        {
            var actorDetail = ModelUIHelper.GetActor();

            _dataReadRepository.Setup(_ => _.GetActor(It.IsAny<int>())).ReturnsAsync(actorDetail);

            var result = await _dataReadController.GetActor(It.IsAny<int>()).ConfigureAwait(false);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var output = result as OkObjectResult;
            var actor = output.Value as Actor;

            Assert.AreEqual(actor.Id, actorDetail.Id);
        }

        [TestMethod]
        public async Task DataReadController_GetActor_EmptyResult()
        {
            Actor actor = null;

            _dataReadRepository.Setup(_ => _.GetActor(It.IsAny<int>())).ReturnsAsync(actor);

            var result = await _dataReadController.GetActor(It.IsAny<int>()).ConfigureAwait(false);

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DataReadController_GetProducer_Success()
        {
            var producerDetail = ModelUIHelper.GetProducer();

            _dataReadRepository.Setup(_ => _.GetProducer(It.IsAny<int>())).ReturnsAsync(producerDetail);

            var result = await _dataReadController.GetProducer(It.IsAny<int>()).ConfigureAwait(false);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var output = result as OkObjectResult;
            var producer = output.Value as Producer;

            Assert.AreEqual(producer.Id, producerDetail.Id);
        }

        [TestMethod]
        public async Task DataReadController_GetProducer_EmptyResult()
        {
            Producer producer = null;

            _dataReadRepository.Setup(_ => _.GetProducer(It.IsAny<int>())).ReturnsAsync(producer);

            var result = await _dataReadController.GetProducer(It.IsAny<int>()).ConfigureAwait(false);

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }
    }
}
