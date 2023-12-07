using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.Subjects.Querries
{
    public class GetAllSubjectCommand : IRequest<List<Subject>>
    {
    }
}
