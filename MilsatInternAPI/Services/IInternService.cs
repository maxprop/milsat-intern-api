using Microsoft.AspNetCore.Mvc;
using MilsatInternAPI.Contracts;
using MilsatInternAPI.Data;
using Microsoft.EntityFrameworkCore;
using MilsatInternAPI.Models;

namespace MilsatInternAPI.Services
{
    public class IInternService: IIntern
    {
        protected MilsatInternAPIContext _context;

        public IInternService(MilsatInternAPIContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Intern>> GetAllInternAsync(int pageNumber, int pageSize)
        {
            var pagedData = await _context.Intern
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
            return pagedData;
        }

        public async Task<IEnumerable<Intern>> GetInternsAsync([FromQuery] GetInternVm vm)
        {
            // When ID is received
            if (vm.id != null)
            {
                var intern = await _context.Intern.Where(x => x.Id == vm.id).FirstOrDefaultAsync();
                List<Intern> collectedIntern = new List<Intern> { intern };
                return collectedIntern;
            }

            // Received only name without department
            else if (vm.name != null && vm.department == null)
            {
                var interns = await _context.Intern.Where(x => x.Name.Contains(vm.name)).ToListAsync();
                return interns;
            }

            //Received only Department without name
            //else if (model.name == null && model.department != null)
            {
                var interns = await _context.Intern.Where(x => x.Department.Contains(vm.department)).ToListAsync();
                return interns;
            }

        }

        public async Task<IEnumerable<Intern>> AddInternsAsync(IEnumerable<CreateInternVm> vm_list)
        {
            List<Intern> new_interns= new List<Intern>();
            foreach (CreateInternVm eachIntern in vm_list)
            {
                Intern singleIntern = new Intern { Name = eachIntern.Name, Department = eachIntern.Department };
                await _context.Intern.AddAsync(singleIntern);
                new_interns.Add(singleIntern);
            }

            await _context.SaveChangesAsync();
            return new_interns;
        }

        public async Task<Intern> EditInternAsync(UpdateInternVm vm)
        {
            return null;
        }

        public async Task<Intern> DeleteInternAsync(int id)
        {
            return null;
        }


    }
}   
