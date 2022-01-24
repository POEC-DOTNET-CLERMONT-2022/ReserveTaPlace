using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReserveTaPlace.API.Controllers;
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
        private UserController _userController;
        private IGenericRepo<UserEntity> _userGenericRepo;
        private ILogger<UserController> _logger { get; set; } = new NullLogger<UserController>();
        public IMapper Mapper;
        MapperConfiguration config;


        [ClassInitialize]
        public void Init()
        {
            config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(UserController)));
            Mapper = new Mapper(config);
        }

        //Test de Composant
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public async void testGetAllUsers()
        {
            //Arrange
            #region Arrange
            _userController = new UserController(Mapper, _userGenericRepo,_logger);
            var result = await _userGenericRepo.GetAll();


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
            entities.Count().Should().Be(0);
            #endregion

        }


    }
}