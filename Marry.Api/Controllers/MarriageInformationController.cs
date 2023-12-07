using Marry.Api.ViewModels;
using Marry.Application.Interfaces;
using Marry.Application.UseCases.Marriage.Commands;
using Marry.Application.UseCases.Marriage.Queries;
using Marry.Domain.Entities;
using Marry.Domain.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Marry.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MarriageInformationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMarriageInformationService _marriageInformationService;
        private readonly IMemoryCache _memoryCache;

        public MarriageInformationController(IMediator mediator, IMarriageInformationService marriageInformationService, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _marriageInformationService = marriageInformationService;
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateMarriageRegistrationAsync(AddRegistrationDto model)
        {
            var command = new CreateMarriageInformationCommand
            {
                GroomId = model.GroomId,
                BrideId = model.BrideId,
            };

            try
            {
                await _mediator.Send(command);
                return Ok("Completed");
            }
            catch (Exception ex) { return Ok("Error!"); }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllMarriageRegistrationsAsync()
        {
            //var res = await _mediator.Send(new GetMarriageInformationCommand());
            //return Ok(res);
            try
            {
                var value = _memoryCache.Get("Marriages_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Marriages_key",
                        value: await _mediator.Send(new GetMarriageInformationCommand()));
                }
                return Ok(_memoryCache.Get("Marriages_key") as List<Marriage>);
            }
            catch (Exception ex) { return BadRequest(ex); }

        }

        [HttpGet]
        public async ValueTask<IActionResult> GetMarriageRegistrationByIdAsync(int id)
        {
            try
            {
                //var res = await _mediator.Send(new GetByIdMarriageInformationCommand { Id = id });
                //return Ok(res);

                var value = _memoryCache.Get("Marriage_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Marriage_key",
                        value: await _mediator.Send(new GetByIdMarriageInformationCommand()));
                }
                return Ok(_memoryCache.Get("Marriage_key") as Marriage);

            }
            catch (Exception ex) { return Ok(ex.Message); }
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteMarriageRegistrationByIdAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteMarriageInformationCommand { Id = id });
                return Ok(res);
            }
            catch (Exception ex) { return Ok(ex.Message); }
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateMarriageRegistrationByIdAsync(int id, AddRegistrationDto dto)
        {
            try
            {
                var command = new UpdateMarriageInformationCommand
                {
                    BrideId = dto.BrideId,
                    GroomId = dto.GroomId,
                };
                await _mediator.Send(command);
                return Ok(command);
            }
            catch (Exception ex) { return Ok(ex.Message); }
        }


        [HttpGet]
        public async ValueTask<IActionResult> GetAllMarriageInformationsAsync()
        {
            try
            {
                //var res = await _marriageInformationService.GetAllMerriageInformationAsync();
                //return Ok(res);

                var value = _memoryCache.Get("Allinfo_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "Allinfo_key",
                        value: await _marriageInformationService.GetAllMerriageInformationAsync());
                }
                return Ok(_memoryCache.Get("Allinfo_key") as List<FullMarriageInformationViewModel>);
            }
            catch (Exception ex) { return null; }
        }


    }
}