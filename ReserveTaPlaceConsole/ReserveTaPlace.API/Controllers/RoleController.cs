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
    public class RoleController : ControllerBase
    {
        private IRole _roles;
        private IMapper _mapper;

        public RoleController(IMapper mapper, DbContext db)
        {
            _roles = new RoleFunctions(db);
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var roles = await _roles.GetAll();
            var rolesDto = _mapper.Map<IEnumerable<RoleDto>>(roles);
            return Ok(rolesDto);
        }
    }
}
