using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveTaPlace.Data.Functions;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.DTOS;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReserveTaPlace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private ISeat _seat;
        private IMapper _mapper;

        public SeatController(IMapper mapper, DbContext context)
        {
            _seat = new SeatFunctions(context);
            _mapper = mapper;
        }
        // GET: api/<SeatController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var seats = await _seat.GetAll();
            var seatDto = _mapper.Map<IEnumerable<SeatDto>>(seats);
            return Ok(seatDto);
        }
    }
}
