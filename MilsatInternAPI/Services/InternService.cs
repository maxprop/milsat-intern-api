using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilsatInternAPI.Data;
using MilsatInternAPI.Interfaces;
using MilsatInternAPI.Models;
using MilsatInternAPI.ViewModels.Interns;

namespace MilsatInternAPI.Services
{
    public class InternService : IInternService
    {
        private readonly IAsyncRepository<Intern> _repository;

        public InternService(IAsyncRepository<Intern> repository)
        {
            this._repository = repository;
        }

        public async Task<List<CreateInternVm>> AddIntern(List<CreateInternVm> vm)
        {
            try
            {
                var interns = new List<Intern> { };
                var resp = await _repository.AddRangeAsync(interns);

                var getIntern = await _repository.GetAll().Include(x => x.Mentor).Where(y => y.InternId == 4).FirstOrDefaultAsync();

                return vm;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> SendNotificationToMentor(UpdateInternVm vm)
        {
            throw new NotImplementedException();
        }
    }

}
