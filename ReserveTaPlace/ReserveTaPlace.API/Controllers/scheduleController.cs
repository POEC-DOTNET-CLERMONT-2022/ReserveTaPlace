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
    public class scheduleController : ControllerBase
    {
        private IGenericRepo<ScheduleEntity> _genericRepo;
        private IMapper _mapper;

        public scheduleController(DbContext dbContext, IMapper mapper)
        {
            _genericRepo = new GenericFunctions<ScheduleEntity>(dbContext);
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ScheduleDto scheduleDto)
        {
            var scheduleEntity = _mapper.Map<ScheduleEntity>(scheduleDto);
            var result = await _genericRepo.Add(scheduleEntity);
            return Ok(result);
        }
    }

}
