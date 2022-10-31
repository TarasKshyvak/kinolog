using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace kinolog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieModel>>> GetAll()
        {
            return (await _movieService.GetAllAsync()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieModel>> GetById(Guid id)
        {
            return await _movieService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] MovieModel model)
        {
            await _movieService.AddAsync(model);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, MovieModel model)
        {
            model.Id = id;
            await _movieService.UpdateAsync(model);
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _movieService.DeleteAsync(id);
            return Ok();
        }
    }
}
