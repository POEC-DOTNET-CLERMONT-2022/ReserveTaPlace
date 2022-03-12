using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveTaPlace.Data.Functions;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.DTOS;
using ReserveTaPlace.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReserveTaPlace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private IGenericRepo<SeatEntity> _seat;
        private ISeat _seatRepo;
        private IMapper _mapper;

        public SeatController(IMapper mapper, DbContext context)
        {
            _seat = new GenericFunctions<SeatEntity>(context);
            _mapper = mapper;
            _seatRepo = new SeatFunctions(context);
        }

        [HttpGet("SeatsByRowAndNumber")]
        public async Task<ActionResult> SeatsByRowAndNumber([FromQuery] string row, string seats)
        {
            var seatsList = await _seatRepo.GetSeatsByRowAndNumber(row, seats);
            var seatsDto = _mapper.Map<IEnumerable<SeatDto>>(seatsList);
            return Ok(seatsDto);
        }
        // GET: api/<SeatController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var seats = await _seat.GetAll();
            var seatDto = _mapper.Map<IEnumerable<SeatDto>>(seats);
            return Ok(seatDto);
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody]SeatDto seatDto)
        {
            var seatEntity = _mapper.Map<SeatEntity>(seatDto);
            var result = _seat.Add(seatEntity);
            return Ok(result);
        }
    }
}
