using Marry.Domain.ViewModels;

namespace Marry.Application.Interfaces
{
    public interface IMarriageInformationService
    {
        public ValueTask<List<FullMarriageInformationViewModel>> GetAllMerriageInformationAsync();
    }
}
