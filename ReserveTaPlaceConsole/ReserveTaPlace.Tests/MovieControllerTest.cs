using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReserveTaPlace.API.Controllers;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.API.Test
{
    [TestClass]
    public class MovieControllerTest
    {
        private Mock<IGenericRepo<MovieEntity>> _mockGenericRepo;
        private MovieController _movieController;
        public IEnumerable<MovieEntity> movies;
        public MovieDto movieDto;
        public IMapper Mapper;
        private IHttpClientFactory _httpClientFactory;
        private ILogger<MovieController> _logger { get; set; } = new NullLogger<MovieController>();

        public Fixture Fixture { get; set; }
        MapperConfiguration config;



        public MovieControllerTest(IHttpClientFactory HttpClientFactory)
        {
            _mockGenericRepo = new Mock<IGenericRepo<MovieEntity>>();
            config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(MovieController)));
            Mapper = new Mapper(config);
            _httpClientFactory = HttpClientFactory;
        }
        [TestInitialize]
        public void Init()
        {
            Fixture = new Fixture();
            Fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            movies = Fixture.CreateMany<MovieEntity>(50);
            movieDto = Fixture.Create<MovieDto>();
            _movieController = new MovieController(Mapper, _mockGenericRepo.Object, _httpClientFactory);

        }
        //Test de Composant
        [TestMethod]
        public async Task testGetAllMovies()
        {
            //Arrange
            #region Arrange
            _mockGenericRepo.Setup(repo => repo.GetAll()).Returns(Task.FromResult(movies));
            var result = await _movieController.GetAll();


            #endregion
            //Act
            #region Act
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            var entities = okResult?.Value as IEnumerable<MovieDto>;

            #endregion
            //Assert
            #region Assert
            entities.Should().NotBeNull();
            entities.Count().Should().Be(50);
            #endregion
            _mockGenericRepo.Verify(repo => repo.GetAll(), Times.Exactly(1));

        }
    }
}
