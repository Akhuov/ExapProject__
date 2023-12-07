using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.Teachers.Querries
{
    public class GetAllTeachersCommand: IRequest<List<Teacher>>
    {
    }
}
