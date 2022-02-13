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
    public class FormatController : ControllerBase
    {
        private IFormat _format;
        private IMapper _mapper;

        public FormatController(IMapper mapper, DbContext context)
        {
            _format = new FormatFunctions(context);
            _mapper = mapper;
        }

        // GET: api/<FormatController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var formats = await _format.GetAll();
            var formatDto = _mapper.Map<IEnumerable<FormatDto>>(formats);
            return Ok(formatDto);
        }

        // GET api/<FormatController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FormatController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FormatController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FormatController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
