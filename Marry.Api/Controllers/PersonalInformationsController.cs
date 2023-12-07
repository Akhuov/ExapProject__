using Marry.Api.ViewModels;
using Marry.Application.UseCases.Person.Commands;
using Marry.Application.UseCases.Person.Queries;
using Marry.Application.UseCases.PersonalInformation.Queries;
using Marry.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Marry.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonalInformationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;

        public PersonalInformationsController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreatePersonalInformationAsync(PersonalInformationDto model)
        {
            try
            {
                var command = new CreatePersonalInformationCommand
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MiddleName = model.MiddleName,
                    BirthDate = model.BirthDate,
                    MedicalCertificate = model.MedicalCertificate,
                    Gender = model.Gender,
                    PassportNumber = model.PassportNumber,
                    MarriageStatus = model.MarriageStatus
                };

                await _mediator.Send(command);

                return Ok("Created");
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllPersonalInformationsAsync()
        {
            //var persons = await _mediator.Send(new GetPersonalInformationsCommand());
            //return Ok(persons);
            try
            {
                var value = _memoryCache.Get("PersonalInformations_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "PersonalInformations_key",
                        value: await _mediator.Send(new GetPersonalInformationsCommand()));
                }
                return Ok(_memoryCache.Get("PersonalInformations_key") as List<PersonalInformation>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetPersonalInformationByIdAsync([FromForm] int id)
        {
            //var persons = await _mediator.Send(new GetPersonalInformationsCommand());
            //return Ok(persons);
            try
            {
                var value = _memoryCache.Get("PersonalInformation_key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "PersonalInformation_key",
                        value: await _mediator.Send(new GetByIdPersonalInformationsCommand()));
                }
                return Ok(_memoryCache.Get("PersonalInformation_key") as PersonalInformation);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpDelete]
        public async ValueTask<ActionResult<bool>> DeletePersonalInformationAsync(int id)
        {
            try
            {

                var command = new DeletePersonalInformationCommand()
                {
                    Id = id
                };

                bool result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut]

        public async ValueTask<IActionResult> UpdatePersonalInformationAsync(int id, PersonalInformationDto model)
        {
            try
            {
                var command = new UpdatePersonalInformationCommand()
                {
                    Id = id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MiddleName = model.MiddleName,
                    BirthDate = model.BirthDate,
                    MedicalCertificate = model.MedicalCertificate,
                    Gender = model.Gender,
                    PassportNumber = model.PassportNumber,
                    MarriageStatus = model.MarriageStatus
                };
                await _mediator.Send(command);
                return Ok("Personal Information Updated!");
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
