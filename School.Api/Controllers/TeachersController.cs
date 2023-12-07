using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Api.Dtos;
using School.Application.UseCases.Students.Commands;
using School.Application.UseCases.Students.Querries;
using School.Application.UseCases.Teachers.Commands;
using School.Application.UseCases.Teachers.Querries;

namespace School.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TeachersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateTeachertAsync(TeacherDto dto)
        {
            try
            {
                var command = new CreateTeacherCommand
                {
                    Title = dto.Title,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Level = dto.Level,
                    SubjectsTaught = dto.SubjectsTaught,
                };

                var res = await _mediator.Send(command);
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllTeachersAsync()
        {
            try
            {
                var res = await _mediator.Send(new GetAllTeachersCommand());
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdTeacherAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new GetByIdTeachersCommand { Id = id });
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateTeacherAsync(int id, TeacherDto dto)
        {
            try
            {
                var command = new UpdateTeacherCommand
                {
                    Id = id,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Title = dto.Title,
                    Level = dto.Level,
                    SubjectsTaught = dto.SubjectsTaught,
                };

                var res = await _mediator.Send(command);
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }


        [HttpDelete]
        public async ValueTask<IActionResult> DeleteTeacherAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteTeacherCommand {Id = id });
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
