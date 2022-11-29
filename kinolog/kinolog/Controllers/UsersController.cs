using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kinolog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAll()
        {
            _logger.LogInformation("Getting all users");
            return (await _userService.GetAllAsync()).ToList();
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<UserModel>> GetById(Guid id)
        {
            _logger.LogInformation($"Getting user by id:{id}");
            return await _userService.GetByIdAsync(id);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<UserModel>> GetByUsername(string username)
        {
            _logger.LogInformation($"Getting user by username:{username}");
            return await _userService.GetByUsernameAsync(username);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] UserModel model)
        {
            _logger.LogInformation("Adding a new user");
            await _userService.AddAsync(model);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UserModel model)
        {
            model.Id = id;
            await _userService.UpdateAsync(model);
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}