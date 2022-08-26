using Microsoft.AspNetCore.Mvc;
using MilsatInternAPI.ViewModels;
using MilsatInternAPI.ViewModels.Interns;

namespace MilsatInternAPI.Interfaces
{
    public interface IInternService
    {
        Task<GenericResponse<List<InternDTO>>> GetAllInterns(int pageNumber, int pageSize);
        Task<GenericResponse<List<InternDTO>>> GetInterns(GetInternVm vm);
        Task<GenericResponse<List<InternDTO>>> AddIntern(List<CreateInternVm> vm);
        Task<GenericResponse<InternDTO>> UpdateIntern(UpdateInternVm vm);
        Task<GenericResponse<InternDTO>> RemoveIntern(int id);
        
    }
}
