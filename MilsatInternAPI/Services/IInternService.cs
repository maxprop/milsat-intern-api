using MilsatInternAPI.ViewModels.Interns;

namespace MilsatInternAPI.Services
{
    public interface IInternService
    {
        Task<List<CreateInternVm>> AddIntern(List<CreateInternVm> vm);
        Task<bool> SendNotificationToMentor(UpdateInternVm vm);

    }
}
