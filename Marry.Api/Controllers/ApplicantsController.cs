using Marry.Api.Dtos;
using Marry.Application.UseCases.Applicant.Commands;
using Marry.Application.UseCases.Applicant.Querries;
using Marry.Application.UseCases.Couples.Commands;
using Marry.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Marry.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApplicantsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;

        public ApplicantsController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateGroomAsync(ApplicantsDto dto)
        {
            try
            {
                var command = new CreateGroomCommand
                {
                    PersonalInformationId = dto.PersonalInformationId,
                    WitnessId = dto.WitnessId,
                };
                await _mediator.Send(command);
                return Ok(dto);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateBrideAsync(ApplicantsDto dto)
        {
            try
            {
                var command = new CreateBrideCommand
                {
                    PersonalInformationId = dto.PersonalInformationId,
                    WitnessId = dto.WitnessId,
                };
                await _mediator.Send(command);
                return Ok(dto);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpDelete]

        public async ValueTask<IActionResult> DeleteGroomAsync(int id)
        {
            try
            {
                var res = _mediator.Send(new DeleteGroomCommand { Id = id });
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }


        [HttpDelete]

        public async ValueTask<IActionResult> DeleteBradeAsync(int id)
        {
            try
            {
                var res = _mediator.Send(new DeleteGroomCommand { Id = id });
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllBradeAsync()
        {
            try
            {
                //var res = _mediator.Send(new GetAllBridesCommand());
                //return Ok(res);

                var value = _memoryCache.Get("Brides_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Brides_key",
                        value: await _mediator.Send(new GetAllBridesCommand()));
                }
                return Ok(_memoryCache.Get("Brides_key") as List<Bride>);
            }
            catch (Exception ex) { return BadRequest(ex); }

        }


        [HttpGet]
        public async ValueTask<IActionResult> GetAllGroomsAsync()
        {
            try
            {
                //var res = _mediator.Send(new GetAllGroomsCommand());
                //return Ok(res);

                var value = _memoryCache.Get("Grooms_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Grooms_key",
                        value: await _mediator.Send(new GetAllBridesCommand()));
                }
                return Ok(_memoryCache.Get("Grooms_key") as List<Groom>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
