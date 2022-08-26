using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilsatInternAPI.Data;
using MilsatInternAPI.Enums;
using MilsatInternAPI.Interfaces;
using MilsatInternAPI.Models;
using MilsatInternAPI.ViewModels;
using MilsatInternAPI.ViewModels.Interns;
using Newtonsoft.Json;

namespace MilsatInternAPI.Services
{
    public class InternService : IInternService
    {
        private readonly IAsyncRepository<Intern> _Intern;
        private readonly IAsyncRepository<Mentor> _Mentor;
        private readonly ILogger<InternService> _logger;
        public InternService(IAsyncRepository<Intern> internRepo, IAsyncRepository<Mentor> mentorRepo, ILogger<InternService> logger)
        {
            _Intern = internRepo;
            _Mentor = mentorRepo;
            _logger = logger;
        }

        public async Task<GenericResponse<List<InternDTO>>> AddIntern(List<CreateInternVm> vm)
        {
            _logger.LogInformation($"Received a request to create new Intern(s): Request:{JsonConvert.SerializeObject(vm)}");
            try
            {
                var interns = new List<Intern>();
                foreach (CreateInternVm intern in vm)
                {
                    var singleIntern = new Intern { Name = intern.Name, Department = intern.Department };
                    Mentor selectedMentor = SelectMentor(intern.Department).Result;
                    singleIntern.Mentor = selectedMentor;
                    interns.Add(singleIntern);
                }
                await _Intern.AddRangeAsync(interns);

                //Crete response body
                var newInterns = InternResponseData(interns);
                return new GenericResponse<List<InternDTO>>
                {
                    IsSuccessful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = newInterns
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while Creating Intern. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<List<InternDTO>>
                { 
                    IsSuccessful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }


        public async Task<Mentor> SelectMentor(DepartmentType department)
        {
            var availableMentors = await _Mentor.GetAll().Where(x => x.Department == department).ToListAsync();
            int totalAvailableMentors = availableMentors.Count();
            Random random = new Random();
            var mentor_idx = random.Next(totalAvailableMentors);
            var mentor = availableMentors[mentor_idx];
            return mentor;
        }

        public async Task<GenericResponse<List<InternDTO>>> GetAllInterns(int pageNumber, int pageSize)
        {
            _logger.LogInformation($"Received a request to fetch paginated Intern(s): Request: pageNumber:{pageNumber}, pageSize:{pageSize}");
            try
            {
                var pagedData = await _Intern.GetAll().Include(x => x.Mentor)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var interns = InternResponseData(pagedData);
                return new GenericResponse<List<InternDTO>>
                {
                    IsSuccessful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = interns
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured while Fecthing Data Request. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<List<InternDTO>>
                {
                    IsSuccessful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public async Task<GenericResponse<List<InternDTO>>> GetInterns(GetInternVm vm)
        {
            _logger.LogInformation($"Received a request to Fetch Intern(s): Request:{JsonConvert.SerializeObject(vm)}");
            if (vm.id == null && vm.name == null && vm.department == null)
            {
                return new GenericResponse<List<InternDTO>>
                {
                    IsSuccessful = false,
                    ResponseCode = ResponseCode.NotFound
                };
            }
            try
            {
                if (vm.id != null)
                {
                    var intern = await _Intern.GetAll().Include(x => x.Mentor)
                                                       .Where(x => x.InternId == vm.id).FirstOrDefaultAsync();
                    if (intern == null)
                    {
                        _logger.LogInformation($"Invalid ID Received: Request:{JsonConvert.SerializeObject(vm)}");
                        return new GenericResponse<List<InternDTO>>
                        {
                            IsSuccessful = false,
                            ResponseCode = ResponseCode.NotFound
                        };
                    }

                    var entity = new InternDTO {
                        InternId = intern.InternId, Name = intern.Name,
                        Department = intern.Department, MentorName = intern.Mentor.Name };
                    List<InternDTO> collectedIntern = new List<InternDTO> { entity };
                    return new GenericResponse<List<InternDTO>>
                    {
                        IsSuccessful = true,
                        ResponseCode = ResponseCode.Successful,
                        Data = collectedIntern
                    };
                }

                // Received only name without department
                else if (vm.name != null && vm.department == null)
                {
                    var interns = await _Intern.GetAll().Include(x => x.Mentor)
                                                       .Where(x => x.Name.Contains(vm.name)).ToListAsync();
                    var collectedInterns = InternResponseData(interns);
                    return new GenericResponse<List<InternDTO>>
                    {
                        IsSuccessful = true,
                        ResponseCode = ResponseCode.Successful,
                        Data = collectedInterns
                    };
                }

                //Received only Department without name
                //else if (model.name == null && model.department != null)
                else
                {
                    var interns = await _Intern.GetAll().Include(x => x.Mentor)
                                                        .Where(x => x.Department == vm.department).ToListAsync();
                    var collectedInterns = InternResponseData(interns);
                    return new GenericResponse<List<InternDTO>>
                    {
                        IsSuccessful = true,
                        ResponseCode = ResponseCode.Successful,
                        Data = collectedInterns
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured while Fecthing Data Request. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<List<InternDTO>>
                {
                    IsSuccessful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }


        public async Task<GenericResponse<InternDTO>> UpdateIntern(UpdateInternVm vm)
        {
            _logger.LogInformation($"Received a request to update Intern: Request:{JsonConvert.SerializeObject(vm)}");
            try
            {
                var intern = await _Intern.GetAll().Where(x => x.InternId == vm.Id).FirstOrDefaultAsync();

                if (intern == null)
                {
                    return new GenericResponse<InternDTO>
                    {
                        IsSuccessful = false,
                        ResponseCode = ResponseCode.NotFound
                    };
                }

                if (vm.Department != intern.Department)
                {
                    intern.Department = vm.Department;
                    intern.Mentor = await SelectMentor(vm.Department);

                    await _Intern.UpdateAsync(intern);
                }
                var updatedIntern = new InternDTO
                {
                    InternId = intern.InternId, Name = intern.Name,
                    Department = intern.Department, MentorName = intern.Mentor.Name
                };
                return new GenericResponse<InternDTO>
                {
                    IsSuccessful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = updatedIntern
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while updating intern. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<InternDTO>
                {
                    IsSuccessful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public async Task<GenericResponse<InternDTO>> RemoveIntern(int id)
        {
            _logger.LogInformation($"Received a request to delete an Intern: Request(intern id):{id}");
            try
            {
                var intern = await _Intern.GetByIdAsync(id);
                if (intern == null)
                {
                    return new GenericResponse<InternDTO>
                    {
                        IsSuccessful = false,
                        ResponseCode = ResponseCode.NotFound
                    };
                }

                await _Intern.DeleteAsync(intern);
                return new GenericResponse<InternDTO>
                {
                    IsSuccessful = true,
                    ResponseCode = ResponseCode.Successful
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while Deleting Intern. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<InternDTO>
                {
                    IsSuccessful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public List<InternDTO> InternResponseData(List<Intern> source)
        {
            List<InternDTO> interns = new();
            foreach (var intern in source)
            {
                interns.Add(new InternDTO
                {
                    InternId = intern.InternId,
                    Name = intern.Name,
                    Department = intern.Department,
                    MentorName = intern.Mentor.Name
                });
            };
            return interns;
        }
    }

}
