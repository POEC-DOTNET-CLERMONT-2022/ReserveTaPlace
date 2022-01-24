using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReserveTaPlace.API.Controllers;
using ReserveTaPlace.Data.Functions;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReserveTaPlace.API.Tests
{
    [TestClass]
    public class UserControllerTest
    {
        private Mock<IGenericRepo<UserEntity>> _mockGenericRepo;
        private UserController _userController;
        private IGenericRepo<UserEntity> _userGenericRepo;
        public IEnumerable<UserEntity> CleanUsersDb;
        private ILogger<UserController> _logger { get; set; } = new NullLogger<UserController>();
        public IMapper Mapper;
        public Fixture Fixture { get; set; }
        MapperConfiguration config;
        InMemoryDbContext dbContext;
        public UserControllerTest()
        {
            _mockGenericRepo = new Mock<IGenericRepo<UserEntity>>();
            config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(UserController)));
            Mapper = new Mapper(config);
            Fixture = new Fixture();
        }
        [ClassInitialize]
        public void Init()
        {
            var options = new DbContextOptionsBuilder().UseSqlite("Datasource=:InMemory").Options;
            dbContext = new InMemoryDbContext(options);
            dbContext.Database.Migrate();
            CleanUsersDb = Fixture.CreateMany<UserEntity>(50);
            dbContext.AddRange(CleanUsersDb);
            dbContext.SaveChanges();
            _userGenericRepo = new GenericFunctions<UserEntity>(dbContext);
            _userController = new UserController(Mapper, _userGenericRepo, _logger);

        }

        //Test de Composant
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public async void testGetAllUsers()
        {
            //Arrange
            #region Arrange
            var result = await _userController.GetAll();


            #endregion
            //Act
            #region Act
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            var entities = okResult?.Value as IEnumerable<UserDto>;

            #endregion
            //Assert
            #region Assert
            entities.Should().NotBeNull();
            entities.Count().Should().Be(50);
            #endregion

        }


    }
}