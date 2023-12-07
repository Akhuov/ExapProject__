using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.Teachers.Querries
{
    public class GetByIdTeachersCommand : IRequest<Teacher>
    {
        public int Id { get; set; }
    }
}
