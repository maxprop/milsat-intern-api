using MilsatInternAPI.ViewModels;
using MilsatInternAPI.ViewModels.Mentors;

namespace MilsatInternAPI.Interfaces
{
    public interface IMentorService
    {
        Task<GenericResponse<List<MentorDTO>>> GetAllMentors(int pageNumber, int pageSize);
        Task<GenericResponse<List<MentorDTO>>> GetMentors(GetMentorVm vm);
        Task<GenericResponse<List<MentorDTO>>> AddMentor(List<CreateMentorVm> vm);
        Task<GenericResponse<MentorDTO>> UpdateMentor(UpdateMentorVm vm);
        Task<GenericResponse<MentorDTO>> RemoveMentor(int id);
    }
}
