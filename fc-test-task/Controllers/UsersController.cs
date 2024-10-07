using FcTestTask.Data.Enums;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using FcTestTask.Domain.Users.Entities;
using FcTestTask.Application.Interfaces.Helpers;
using FcTestTask.Application.Interfaces.Repositories;
using FcTestTask.Application.DTO.User.Requests;
using FcTestTask.Application.FilterAttributes;
using FcTestTask.Application.DTO.User;

namespace FcTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersRepository _usersRepository;
        private readonly IUserHelper _userHelper;

        public UsersController(
            IUsersRepository usersRepository,
            IUserHelper userHelper)
        {
            _usersRepository = usersRepository;
            _userHelper = userHelper;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync([Required] int id)
        {
            var res = await _usersRepository.GetByIdAsync(id);

            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> AllAsync([FromQuery] UserFindRequest query)
        {
            var res = await _usersRepository.GetAllAsync(query);

            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost]
        [HasDeviceHeader]
        public async Task<IActionResult> CreateAsync([FromBody] UserDTO userDTO)
        {
            string device = HttpContext.Request.Headers["x-Device"]!;
            var newUserDTO = _userHelper.MapToUserDeviceDTO(userDTO, device);
            if (!newUserDTO.IsValid())
            {
                return BadRequest();
            }
            if (await _usersRepository.Exists(userDTO.ToUser()))
            {
                return BadRequest("User already exists");
            }
            var res = await _usersRepository.AddAsync(newUserDTO.ToUser());
            if (res == null || res.Id == default)
            {
                return StatusCode(500);
            }

            return Ok(res);
        }
    }
}
