using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.Classes.Querries
{
    public class GetAllClassCommand : IRequest<List<Class>>
    {
    }
}
