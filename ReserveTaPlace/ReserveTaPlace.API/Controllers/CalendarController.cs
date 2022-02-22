using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveTaPlace.Data.Functions;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Entities;

namespace ReserveTaPlace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendar _calendar;
        private IMapper _mapper;

        public CalendarController(IMapper mapper, DbContext context)
        {
            _calendar = new CalendarFunctions(context);
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CalendarDto calendar)
        {
            var calendarEntities = _mapper.Map<CalendarEntity>(calendar);
            var result = await _calendar.AddCalendar(calendarEntities);
            return Ok(result);
        }

        [HttpGet("CalendarByDate")]
        public async Task<ActionResult> CalendarByDate([FromQuery] string date)
        {
            var calendar = await _calendar.GetCalendarByDate(date);
            var calendarDto = _mapper.Map<CalendarDto>(calendar);
            return Ok(calendarDto);
        }
    }
}
