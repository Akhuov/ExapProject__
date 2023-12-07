using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Api.Dtos;
using School.Application.UseCases.Students.Commands;
using School.Application.UseCases.Students.Querries;
using School.Application.UseCases.Subjects.Commands;
using School.Application.UseCases.Subjects.Querries;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SubjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateSubjectAsync(SubjectDto dto)
        {
            try
            {
                var command = new CreateSubjectCommand
                {
                    Requirements = dto.Requirements,
                    MaxCampacity = dto.MaxCampacity,
                };

                var res = await _mediator.Send(command);
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllSubjectAsync()
        {
            try
            {
                var res = await _mediator.Send(new GetAllSubjectCommand());
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdSubjectAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new GetByIdSubjectCommand { Id = id });
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateSubjectAsync(int id, SubjectDto dto)
        {
            try
            {
                var command = new UpdateSubjectCommand
                {
                    Id = id,
                    
                    MaxCampacity = dto.MaxCampacity,
                    Requirements = dto.Requirements,
                };

                var res = await _mediator.Send(command);
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }


        [HttpDelete]
        public async ValueTask<IActionResult> DeleteSubjectAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteSubjectCommand { Id = id });
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
