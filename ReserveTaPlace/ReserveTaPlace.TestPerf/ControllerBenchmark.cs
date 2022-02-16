using AutoFixture;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Microsoft.EntityFrameworkCore;
using ReserveTaPlace.API.Controllers;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.TestPerf
{
    [SimpleJob(RuntimeMoniker.CoreRt60)]
    internal class ControllerBenchmark
    {
        public MovieController movieController { get; set; }
        public IMovie Movie;
        public IMapper Mapper;
        MapperConfiguration config;
        public IEnumerable<MovieDto> Movies { get; set; }
        public IFixture Fixture { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            Fixture = new Fixture();
            Movies = Fixture.CreateMany<MovieDto>(50);
            config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(MovieController)));
            Mapper = new Mapper(config);
            var dbcontext = new DbContext(new DbContextOptionsBuilder()
                .UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=ReserveTaPlace;Trusted_Connection=True;").Options); 
        }
        
        public void Foreach()
        {
            foreach (var item in Movies)
            {

            }
        }
        public void ParalelForeach()
        {
            foreach (var item in Movies)
            {

            }
        }

    }
}
