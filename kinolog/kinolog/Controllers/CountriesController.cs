using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace kinolog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryModel>>> GetAll()
        {
            return (await _countryService.GetAllAsync()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryModel>> GetById(Guid id)
        {
            return await _countryService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CountryModel model)
        {
            await _countryService.AddAsync(model);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, CountryModel model)
        {
            model.Id = id;
            await _countryService.UpdateAsync(model);
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _countryService.DeleteAsync(id);
            return Ok();
        }
    }
}