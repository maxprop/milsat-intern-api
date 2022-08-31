using Microsoft.AspNetCore.Mvc;
using MilsatInternAPI.ViewModels;
using MilsatInternAPI.ViewModels.Interns;

namespace MilsatInternAPI.Interfaces
{
    public interface IInternService
    {
        Task<GenericResponse<List<InternResponseDTO>>> GetAllInterns(int pageNumber, int pageSize);
        Task<GenericResponse<List<InternResponseDTO>>> GetInterns(GetInternVm vm);
        Task<GenericResponse<List<InternResponseDTO>>> AddIntern(List<CreateInternDTO> vm);
        Task<GenericResponse<InternResponseDTO>> UpdateIntern(UpdateInternVm vm);
        Task<GenericResponse<InternResponseDTO>> RemoveIntern(Guid id);
        
    }
}
