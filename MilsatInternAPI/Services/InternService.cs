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
        private readonly IAuthentication _authService;
        private readonly ILogger<InternService> _logger;
        public InternService(IAsyncRepository<Intern> internRepo, IAsyncRepository<Mentor> mentorRepo,
            ILogger<InternService> logger, IAuthentication authService)
        {
            _Intern = internRepo;
            _Mentor = mentorRepo;
            _logger = logger;
            _authService = authService;
        }

        public async Task<GenericResponse<List<InternResponseDTO>>> AddIntern(List<CreateInternDTO> request)
        {
            _logger.LogInformation($"Received a request to add new Intern(s): Request:{JsonConvert.SerializeObject(request)}");
            try
            {
                var interns = new List<Intern>();
                foreach (CreateInternDTO intern in request)
                {
                    var newUser = new User { Email = intern.Email, Role = "Intern" };
                    newUser = _authService.RegisterPassword(newUser, intern.PhoneNumber);
                    var newIntern = new Intern { 
                        FirstName = intern.FirstName, LastName = intern.LastName,
                        PhoneNumber = intern.PhoneNumber, CreatedDate = DateTime.Now, Department = intern.Department
                    };
                    Mentor selectedMentor = SelectMentor(intern.Department).Result;
                    newIntern.Mentor = selectedMentor;
                    newIntern.User = newUser;
                    
                    interns.Add(newIntern);
                }
                await _Intern.AddRangeAsync(interns);

                //Crete response body
                var newInterns = InternResponseData(interns);
                return new GenericResponse<List<InternResponseDTO>>
                {
                    IsSuccessful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = newInterns
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while Creating Intern. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<List<InternResponseDTO>>
                { 
                    IsSuccessful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public async Task<GenericResponse<List<InternResponseDTO>>> GetAllInterns(int pageNumber, int pageSize)
        {
            _logger.LogInformation($"Received a request to fetch paginated Intern(s): Request: pageNumber:{pageNumber}, pageSize:{pageSize}");
            try
            {
                var pagedData = await _Intern.GetAll().Include(x => x.Mentor)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var interns = InternResponseData(pagedData);
                return new GenericResponse<List<InternResponseDTO>>
                {
                    IsSuccessful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = interns
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured while Fecthing Data Request. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<List<InternResponseDTO>>
                {
                    IsSuccessful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public async Task<GenericResponse<List<InternResponseDTO>>> GetInterns(GetInternVm vm)
        {
            _logger.LogInformation($"Received a request to Fetch Intern(s): Request:{JsonConvert.SerializeObject(vm)}");
            if (vm.id == null && vm.name == null && vm.department == null)
            {
                return new GenericResponse<List<InternResponseDTO>>
                {
                    IsSuccessful = false,
                    ResponseCode = ResponseCode.NotFound
                };
            }
            try
            {
                if (vm.id != null)
                {
                    var intern = await _Intern.GetAll().Include(x => x.Mentor).Where(x => x.InternId == vm.id).FirstOrDefaultAsync();
                    if (intern == null)
                    {
                        _logger.LogInformation($"Invalid ID Received: Request:{JsonConvert.SerializeObject(vm)}");
                        return new GenericResponse<List<InternResponseDTO>>
                        {
                            IsSuccessful = false,
                            ResponseCode = ResponseCode.NotFound
                        };
                    }

                    var entity = new InternResponseDTO {
                        InternId = intern.InternId, FirstName = intern.FirstName,
                        LastName = intern.LastName, Department = intern.Department,
                        MentorName = intern.Mentor == null ? null : $"{intern.Mentor.FirstName} {intern.Mentor.LastName}",
                    };
                    List<InternResponseDTO> collectedIntern = new List<InternResponseDTO> { entity };
                    return new GenericResponse<List<InternResponseDTO>>
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
                                                       .Where(x => x.FirstName.Contains(vm.name) || x.LastName.Contains(vm.name)).ToListAsync();
                    var collectedInterns = InternResponseData(interns);
                    return new GenericResponse<List<InternResponseDTO>>
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
                    return new GenericResponse<List<InternResponseDTO>>
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
                return new GenericResponse<List<InternResponseDTO>>
                {
                    IsSuccessful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }


        public async Task<GenericResponse<InternResponseDTO>> UpdateIntern(UpdateInternVm vm)
        {
            _logger.LogInformation($"Received a request to update Intern: Request:{JsonConvert.SerializeObject(vm)}");
            try
            {
                var intern = await _Intern.GetByIdAsync(new Guid(vm.Id));

                if (intern == null)
                {
                    return new GenericResponse<InternResponseDTO>
                    {
                        IsSuccessful = false,
                        ResponseCode = ResponseCode.NotFound
                    };
                }

                intern.Department = vm.Department;
                intern.Mentor = await SelectMentor(vm.Department);

                await _Intern.UpdateAsync(intern);
                var updatedIntern = new InternResponseDTO
                {
                    InternId = intern.InternId, FirstName = intern.FirstName,
                    LastName = intern.LastName, Department = intern.Department,
                    MentorName = $"{intern.Mentor.FirstName} {intern.Mentor.LastName}"
                };
                return new GenericResponse<InternResponseDTO>
                {
                    IsSuccessful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = updatedIntern
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while updating intern. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<InternResponseDTO>
                {
                    IsSuccessful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public async Task<GenericResponse<InternResponseDTO>> RemoveIntern(Guid id)
        {
            _logger.LogInformation($"Received a request to delete an Intern: Request(intern id):{id}");
            try
            {
                var intern = await _Intern.GetByIdAsync(id);
                if (intern == null)
                {
                    return new GenericResponse<InternResponseDTO>
                    {
                        IsSuccessful = false,
                        ResponseCode = ResponseCode.NotFound
                    };
                }

                await _Intern.DeleteAsync(intern);
                return new GenericResponse<InternResponseDTO>
                {
                    IsSuccessful = true,
                    ResponseCode = ResponseCode.Successful
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while Deleting Intern. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<InternResponseDTO>
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
            if (totalAvailableMentors < 1)
            {
                return null;
            }
            Random random = new Random();
            var mentor_idx = random.Next(totalAvailableMentors);
            var mentor = availableMentors[mentor_idx];
            return mentor;
        }

        public List<InternResponseDTO> InternResponseData(List<Intern> source)
        {
            List<InternResponseDTO> interns = new();
            foreach (var intern in source)
            {
                interns.Add(new InternResponseDTO
                {
                    InternId = intern.InternId,
                    FirstName = intern.FirstName,
                    LastName = intern.LastName,
                    Department = intern.Department,
                    MentorName = intern.Mentor == null ? null : $"{intern.Mentor.FirstName} {intern.Mentor.LastName}",
                });
            };
            return interns;
        }
    }

}
