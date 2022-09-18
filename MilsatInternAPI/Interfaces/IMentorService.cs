using MilsatInternAPI.ViewModels;
using MilsatInternAPI.ViewModels.Mentors;

namespace MilsatInternAPI.Interfaces
{
    public interface IMentorService
    {
        Task<GenericResponse<List<MentorResponseDTO>>> GetAllMentors(int pageNumber, int pageSize);
        Task<GenericResponse<List<MentorResponseDTO>>> GetMentors(GetMentorVm vm);
        Task<GenericResponse<List<MentorResponseDTO>>> AddMentor(List<CreateMentorVm> vm);
        Task<GenericResponse<MentorResponseDTO>> UpdateMentor(UpdateMentorVm vm);
    }
}
