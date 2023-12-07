using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.Students.Querries
{
    public class GetByIdStudentsCommand : IRequest<Student>
    {
        public int Id { get; set; }
    }
}
