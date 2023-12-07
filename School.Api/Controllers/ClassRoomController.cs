using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Api.Dtos;
using School.Application.UseCases.ClassRooms.Commands;
using School.Application.UseCases.ClassRooms.Querries;

namespace School.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClassRoomController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClassRoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateClassRoomAsync(ClassRoomDto dto)
        {
            try
            {
                var command = new CreateClassRoomCommand
                {
                    Capacity = dto.Capacity,
                    Facilities = dto.Facilities,
                    RoomType = dto.RoomType,
                };

                var res = await _mediator.Send(command);
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllClassRoomAsync()
        {
            try
            {
                var res = await _mediator.Send(new GetAllClassRoomsCommand());
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdClassRoomAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new GetByIdClassRoomsCommand { Id = id });
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateClassRoomAsync(int id, ClassRoomDto dto)
        {
            try
            {
                var command = new UpdateClassRoomCommand
                {
                    Id = id,

                    Capacity = dto.Capacity,
                    Facilities = dto.Facilities,
                    RoomType = dto.RoomType

                };

                var res = await _mediator.Send(command);
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }


        [HttpDelete]
        public async ValueTask<IActionResult> DeleteClassRoomAsync(int id)
        {
            try
            {
                var res = await _mediator.Send(new DeleteClassRoomCommand { Id = id });
                return Ok(res);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
