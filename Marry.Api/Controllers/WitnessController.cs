using Marry.Api.ViewModels;
using Marry.Application.UseCases.Marriage.Queries;
using Marry.Application.UseCases.Witness.Commands;
using Marry.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Marry.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WitnessController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;

        public WitnessController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateWitnessAsync(WitnessDto model)
        {
            try
            {
                var command = new CreateWitnessCommand
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };

                await _mediator.Send(command);

                return Ok("Created");
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllWitnessesAsync()
        {
            //var persons = await _mediator.Send(new GetWitnessCommand());
            //return Ok(persons);
            try
            {
                var value = _memoryCache.Get("Witnesses_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Witnesses_key",
                        value: await _mediator.Send(new GetMarriageInformationCommand()));
                }
                return Ok(_memoryCache.Get("Witnesses_key") as List<Witness>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpDelete]
        public async ValueTask<ActionResult<bool>> DeleteWitnessAsync(int id)
        {
            try
            {
                var command = new DeleteWitnessCommand()
                {
                    Id = id
                };

                bool result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpPut]

        public async ValueTask<IActionResult> UpdateWitnessAsync(int id, WitnessDto model)
        {
            try
            {
                var command = new UpdateWitnessCommand()
                {
                    Id = id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };
                await _mediator.Send(command);
                return Ok("Witness Updated!");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
