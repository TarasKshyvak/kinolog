﻿using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kinolog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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
            return (await _userService.GetAllAsync()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetById(Guid id)
        {
            return await _userService.GetByIdAsync(id);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<UserModel>> GetByUsername(string username)
        {
            return await _userService.GetByUsernameAsync(username);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] UserModel model)
        {
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