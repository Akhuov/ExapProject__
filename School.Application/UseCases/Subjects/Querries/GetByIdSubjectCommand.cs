using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.Subjects.Querries
{
    public class GetByIdSubjectCommand : IRequest<Subject>
    {
        public int Id { get; set; }
    }
}
