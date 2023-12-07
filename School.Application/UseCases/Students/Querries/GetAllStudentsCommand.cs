using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.Students.Querries
{
    public class GetAllStudentsCommand : IRequest<List<Student>>
    {
    }
}
