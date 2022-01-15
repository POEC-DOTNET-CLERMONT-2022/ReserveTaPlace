using Bogus;
using Microsoft.EntityFrameworkCore;
using ReserveTaPlace.Data.ApplicationContext;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Data.Functions
{
    public class MovieFunctions : IMovie
    {
        public Task<Movie> Add(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> Delete(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {

            using (var context = new ReserveTaPlaceContext())
            {

            }
            return movies;
        }

        public Task<Movie> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> Update(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
