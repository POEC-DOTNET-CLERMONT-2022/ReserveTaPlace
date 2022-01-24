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
using System.Threading.Tasks;

namespace ReserveTaPlace.API.Tests
{
    [TestClass]
    public class UserControllerTest
    {
        private Mock<IGenericRepo<UserEntity>> _mockGenericRepo;
        private UserController _userController;
        private IGenericRepo<UserEntity> _userGenericRepo;
        public  IEnumerable<UserEntity> Users;
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
            //var options = new DbContextOptionsBuilder().UseSqlite("Datasource=:InMemory").Options;
            //dbContext = new InMemoryDbContext(options);
        }
        [TestInitialize]
        public void Init()
        {

            //dbContext.Database.EnsureCreated();
            Fixture = new Fixture();
            Fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            Users = Fixture.CreateMany<UserEntity>(50);
            //dbContext.AddRange(Users);
            //dbContext.SaveChanges();
            //_userGenericRepo = new GenericFunctions<UserEntity>(dbContext);

            _userController = new UserController(Mapper, _mockGenericRepo.Object, _logger);

        }

        //Test de Composant
        [TestMethod]
        //[ExpectedException(typeof(NullReferenceException))]
        public async Task testGetAllUsers()
        {
            //Arrange
            #region Arrange
            _mockGenericRepo.Setup(repo => repo.GetAll()).Returns(Task.FromResult(Users));
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
            _mockGenericRepo.Verify(repo => repo.GetAll(), Times.Exactly(1));

        }


    }
}