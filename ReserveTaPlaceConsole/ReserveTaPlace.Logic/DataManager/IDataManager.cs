﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Logic.DataManager
{
    public interface IDataManager<TModel, TDto> where TModel : class
                                                where TDto : class
    {
        Task<IEnumerable<TModel>> GetAll();

        Task<bool> Add(TModel model);
        Task<TModel> GetMovie(string title, string year);
    }
}