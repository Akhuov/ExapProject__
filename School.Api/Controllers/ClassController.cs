using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Api.Dtos;
using School.Application.UseCases.Classes.Commands;
using School.Application.UseCases.Classes.Querries;

namespace School.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClassController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateClassRoomAsync(ClassDto dto)
        {
            try
            {
                var command = new CreateClassCommand
                {
                    SubjectId = dto.SubjectId,
                    ClassRoomId = dto.ClassRoomId,
                    Period = dto.Period,
                    TeacherId = dto.TeacherId,
                    Time = dto.Time,
                };

                var res = await _mediator.Send(command);
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllClassAsync()
        {
            try
            {
                var res = await _mediator.Send(new GetAllClassCommand());
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdClassAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new GetByIdClassCommand { Id = id });
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateClassRoomAsync(int id, ClassDto dto)
        {
            try
            {
                var command = new UpdateClassCommand
                {
                    Id = id,

                    SubjectId = dto.SubjectId,
                    ClassRoomId = dto.ClassRoomId,
                    Period = dto.Period,
                    TeacherId = dto.TeacherId,
                    Time = dto.Time,

                };

                var res = await _mediator.Send(command);
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }


        [HttpDelete]
        public async ValueTask<IActionResult> DeleteClassAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteClassCommand { Id = id });
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
