using Microsoft.AspNetCore.Mvc;
using MilsatInternAPI.Models;

namespace MilsatInternAPI.Contracts
{
    public interface IIntern
    {
        Task<IEnumerable<Intern>> GetAllInternAsync(int pageNumber, int pageSize);
        Task<IEnumerable<Intern>> GetInternsAsync(GetInternVm vm);
        Task<IEnumerable<Intern>> AddInternsAsync(IEnumerable<CreateInternVm> vm);
        Task<Intern> EditInternAsync(UpdateInternVm vm);
        Task<Intern> DeleteInternAsync(int id);
    }
}
