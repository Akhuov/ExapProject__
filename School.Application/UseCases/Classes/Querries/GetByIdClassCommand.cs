using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.Classes.Querries
{
    public class GetByIdClassCommand : IRequest<Class>
    {
        public int Id { get; set; }
    }
}
