using MediatR;

namespace Marry.Application.UseCases.PersonalInformation.Queries
{
    public class GetByIdPersonalInformationsCommand : IRequest<Domain.Entities.PersonalInformation>
    {
        public int Id { get; set; }
    }
}
