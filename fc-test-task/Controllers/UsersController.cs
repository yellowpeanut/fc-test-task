using fc_test_task.Data.Enums;
using fc_test_task.Interfaces.Helpers;
using fc_test_task.Interfaces.Reposiroties;
using fc_test_task.Queries.User;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace fc_test_task.Controllers
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
        public async Task<IActionResult> AllAsync([FromQuery] UserFindQuery query)
        {
            var res = await _usersRepository.GetAllAsync(query);

            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] User user)
        {
            string? device = Request.Headers["x-Device"];
            if(!Devices.ListAll.Contains(device))
            {
                return BadRequest("Specified x-Device is not valid");
            }
            var validationRes = _userHelper.ValidateDataFromDevice(user, device);
            if (!validationRes.GetType().IsEquivalentTo(typeof(OkResult)))
            {
                return BadRequest(validationRes);
            }
            var res = await _usersRepository.AddAsync(user);
            if(res == null || res.Id == default)
            {
                return StatusCode(500);
            }

            return Ok(res);
        }
    }
}
