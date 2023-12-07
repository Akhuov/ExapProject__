using MediatR;

namespace Marry.Application.UseCases.Person.Queries
{
    public class GetPersonalInformationsCommand : IRequest<List<Domain.Entities.PersonalInformation>>
    {
    }

}
