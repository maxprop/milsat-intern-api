using Microsoft.EntityFrameworkCore;
using MilsatInternAPI.Enums;
using MilsatInternAPI.Interfaces;
using MilsatInternAPI.Models;
using MilsatInternAPI.ViewModels;
using MilsatInternAPI.ViewModels.Mentors;
using Newtonsoft.Json;

namespace MilsatInternAPI.Services
{
    public class MentorService : IMentorService
    {
        private readonly ILogger<MentorService> _logger;
        private readonly IAsyncRepository<Mentor> _Mentor;
        public MentorService(IAsyncRepository<Mentor> mentorRepo, ILogger<MentorService> logger)
        {
            _Mentor = mentorRepo;
            _logger = logger;
        }

        public async Task<GenericResponse<List<MentorDTO>>> AddMentor(List<CreateMentorVm> vm)
        {
            _logger.LogInformation($"Received a request to add new Mentor(s): Request:{JsonConvert.SerializeObject(vm)}");
            try
            {
                var mentors = new List<Mentor>();
                foreach (CreateMentorVm intern in vm)
                {
                    var singleMentor = new Mentor { Name = intern.Name, Department = intern.Department };
                    mentors.Add(singleMentor);
                }
                await _Mentor.AddRangeAsync(mentors);

                //Crete response body
                var newMentors = MentorResponseData(mentors);
                return new GenericResponse<List<MentorDTO>>
                {
                    IsSuccessful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = newMentors
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while Creating Intern. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<List<MentorDTO>>
                {
                    IsSuccessful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public async Task<GenericResponse<List<MentorDTO>>> GetAllMentors(int pageNumber, int pageSize)
        {
            try
            {
                var pagedData = await _Mentor.GetAll().Include(x => x.Interns).Skip((pageNumber - 1) * pageSize)
                                                      .Take(pageSize).ToListAsync();
                var collectedMentors = MentorResponseData(pagedData);
                return new GenericResponse<List<MentorDTO>>
                {
                    IsSuccessful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = collectedMentors
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured while Fecthing Data Request. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<List<MentorDTO>>
                {
                    IsSuccessful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public async Task<GenericResponse<List<MentorDTO>>> GetMentors(GetMentorVm vm)
        {
            _logger.LogInformation($"Received a request to Fetch Intern(s): Request:{JsonConvert.SerializeObject(vm)}");
            if (vm.id == null && vm.name == null && vm.department == null)
            {
                return new GenericResponse<List<MentorDTO>>
                {
                    IsSuccessful = false,
                    ResponseCode = ResponseCode.NotFound
                };
            }

            try
            {
                if (vm.id != null) {
                    var mentor = await _Mentor.GetAll().Include(mentor => mentor.Interns)
                                                       .Where(X => X.MentorId == vm.id).FirstOrDefaultAsync();

                    if (mentor == null)
                    {
                        _logger.LogInformation($"Invalid ID Received: Request:{JsonConvert.SerializeObject(vm)}");
                        return new GenericResponse<List<MentorDTO>>
                        {
                            IsSuccessful = false,
                            ResponseCode = ResponseCode.NotFound
                        };
                    }

                    var collectedMentor = MentorResponseData(new List<Mentor> { mentor });
                    return new GenericResponse<List<MentorDTO>>
                    {
                        IsSuccessful = true,
                        ResponseCode = ResponseCode.Successful,
                        Data = collectedMentor
                    };
                }
                else if (vm.name != null && vm.department == null)
                {
                    var interns = await _Mentor.GetAll().Include(x => x.Interns).Where(x => x.Name.Contains(vm.name)).ToListAsync();
                    var collectedInterns = MentorResponseData(interns);
                    return new GenericResponse<List<MentorDTO>>
                    {
                        IsSuccessful = true,
                        ResponseCode = ResponseCode.Successful,
                        Data = collectedInterns
                    };
                }
                else
                {
                    var interns = await _Mentor.GetAll().Include(x => x.Interns).Where(x => x.Department == vm.department).ToListAsync();

                    var collectedInterns = MentorResponseData(interns);
                    return new GenericResponse<List<MentorDTO>>
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
                return new GenericResponse<List<MentorDTO>>
                {
                    IsSuccessful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public async Task<GenericResponse<MentorDTO>> UpdateMentor(UpdateMentorVm vm)
        {
            _logger.LogInformation($"Received a request to update Mentor: Request:{JsonConvert.SerializeObject(vm)}");
            try
            {
                var mentor = await _Mentor.GetAll().Include(x => x.Interns).Where(x => x.MentorId == vm.MentorId).FirstOrDefaultAsync();

                if (mentor == null)
                {
                    return new GenericResponse<MentorDTO>
                    {
                        IsSuccessful = false,
                        ResponseCode = ResponseCode.NotFound
                    };
                }
                if (vm.Department != mentor.Department)
                {
                    mentor.Department = vm.Department;
                    foreach (var intern in mentor.Interns)
                    {
                        intern.Mentor = null;
                    }
                    //mentor.Interns = new List<Intern> { };

                    await _Mentor.UpdateAsync(mentor);
                }

                var updatedIntern = new MentorDTO
                {
                    MentorId = mentor.MentorId,
                    Name = mentor.Name,
                    Department = mentor.Department,
                    Interns = new List<MentorInternDTO>()
                };
                return new GenericResponse<MentorDTO>
                {
                    IsSuccessful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = updatedIntern
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while updating intern. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<MentorDTO>
                {
                    IsSuccessful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public async Task<GenericResponse<MentorDTO>> RemoveMentor(int id)
        {
            _logger.LogInformation($"Received a request to delete an Mentor: Request(mentor id):{id}");
            try
            {
                var intern = await _Mentor.GetByIdAsync(id);
                if (intern == null)
                {
                    return new GenericResponse<MentorDTO>
                    {
                        IsSuccessful = false,
                        ResponseCode = ResponseCode.NotFound
                    };
                }

                await _Mentor.DeleteAsync(intern);
                return new GenericResponse<MentorDTO>
                {
                    IsSuccessful = true,
                    ResponseCode = ResponseCode.Successful
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while Deleting Intern. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<MentorDTO>
                {
                    IsSuccessful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public static List<MentorDTO> MentorResponseData(List<Mentor> source)
        {
            List<MentorDTO> mentors = new();
            foreach (var mentor in source)
            {
                var interns = AssignedIntern(mentor);
                mentors.Add(new MentorDTO
                {
                    MentorId = mentor.MentorId,
                    Name = mentor.Name,
                    Department = mentor.Department,
                    Interns = interns
                });
            };
            return mentors;
        }

        public static List<MentorInternDTO> AssignedIntern(Mentor mentor)
        {
            List<MentorInternDTO> interns = new List<MentorInternDTO>();
            foreach (var intern in mentor.Interns)
            {
                interns.Add(new MentorInternDTO
                {
                    InternId = intern.InternId,
                    Name = intern.Name,
                });
            }
            return interns;
        }
    }
}
