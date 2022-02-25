﻿using ReserveTaPlace.Models;
using ReserveTaPlace.Models.WPFModels;
using System;
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
        Task<TModel> GetMovieByNameAndYear(string title,string year);
        Task<PaginatedList<TModel>> GetAllPaginated(int page, int pageSize);
        Task<bool> DeleteTheaterById(Guid id);
        Task<TModel> UpdateTheater(TModel model);
        Task<TModel> GetCalendarByDate(string date);
        Task<bool> AddCalendar(TModel Calendar);
        Task<bool> AddSessions(List<TModel> sessions);
        Task<bool> AddRoomSession(TModel session);
        Task<string> GetUserHash(string email);
        Task<TModel> GetUserByEmail(string text);
        Task<bool> VerifyUser(UserToVerify userToVerify);
    }
}