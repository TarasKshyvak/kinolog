using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace kinolog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CreatorsController : ControllerBase
    {
        private readonly ICreatorService _creatorService;

        public CreatorsController(ICreatorService creatorService)
        {
            _creatorService = creatorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreatorModel>>> GetAll()
        {
            return (await _creatorService.GetAllAsync()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CreatorModel>> GetById(Guid id)
        {
            return await _creatorService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CreatorModel model)
        {
            await _creatorService.AddAsync(model);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] CreatorModel model)
        {
            model.Id = id;
            await _creatorService.UpdateAsync(model);
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _creatorService.DeleteAsync(id);
            return Ok();
        }
    }
}
