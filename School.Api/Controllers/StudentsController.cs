using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using School.Api.Dtos;
using School.Application.UseCases.Students.Commands;
using School.Application.UseCases.Students.Querries;
using School.Domain.Entities;

namespace School.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateStudentAsync(StudentDto dto)
        {
            try
            {
                var command = new CreateStudentCommand
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    StudentImage = dto.StudentImage,
                    DateOfBirth = dto.DateOfBirth,
                    YearGroup = dto.YearGroup,
                };

                var res = await _mediator.Send(command);
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllStudentAsync()
        {
            try
            {
                //var res = await _mediator.Send(new GetAllStudentsCommand());
                //return Ok(res);

                var value = _memoryCache.Get("key");
                if (value == null)
                {
                    _memoryCache.Set(
                    key: "key",
                        value: await _mediator.Send(new GetAllStudentsCommand()));
                }
                return Ok(_memoryCache.Get("key") as List<Student>);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdStudentAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new GetByIdStudentsCommand { Id = id });
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateStudentAsync(int id, StudentDto dto)
        {
            try
            {
                var command = new UpdateStudentCommand
                {
                    Id = id,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    StudentImage = dto.StudentImage,
                    DateOfBirth = dto.DateOfBirth,
                    YearGroup = dto.YearGroup,
                };

                var res = await _mediator.Send(command);
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }


        [HttpDelete]
        public async ValueTask<IActionResult> DeleteStudentAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteStudentCommand {Id = id });
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
