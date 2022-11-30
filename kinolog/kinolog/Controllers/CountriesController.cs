using BLL.Commands;
using BLL.Models;
using BLL.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace kinolog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CountriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryModel>>> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllCountriesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryModel>> GetById(Guid id)
        {
            return Ok(await _mediator.Send(new GetByIdCountryQuery(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CountryModel model)
        {
            try
            {
                return Ok(await _mediator.Send(new AddCountryCommand(model)));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, CountryModel model)
        {
            model.Id = id;
            return Ok(await _mediator.Send(new UpdateCountryCommand(model)));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteCountryCommand(id));
            return Ok();
        }
    }
}