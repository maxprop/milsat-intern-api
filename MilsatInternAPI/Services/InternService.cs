using AutoMapper;
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
        private readonly IAsyncRepository<Intern> _internRepo;
        private readonly IAsyncRepository<Mentor> _mentorRepo;
        private readonly IAsyncRepository<User> _userRepo;
        private readonly IAuthentication _authService;
        private readonly ILogger<InternService> _logger;
        public InternService(IAsyncRepository<Intern> internRepo, IAsyncRepository<Mentor> mentorRepo,
            ILogger<InternService> logger, IAuthentication authService, IAsyncRepository<User> userRepo)
        {
            _internRepo = internRepo;
            _mentorRepo = mentorRepo;
            _userRepo = userRepo;
            _logger = logger;
            _authService = authService;
        }

        public async Task<GenericResponse<List<InternResponseDTO>>> AddIntern(CreateInternDTO request)
        {
            _logger.LogInformation($"Received a request to add new Intern(s): Request:{JsonConvert.SerializeObject(request)}");
            try
            {
                var user = await _userRepo.GetAll().Where(x => x.Email == request.Email).FirstOrDefaultAsync();
                if (user != null)
                {
                    return new GenericResponse<List<InternResponseDTO>>
                    {
                        Successful = false,
                        ResponseCode = ResponseCode.INVALID_REQUEST,
                        Message = "User with this Email already exists"
                    };
                }

                var newUser = new User {
                    Email = request.Email, Role = RoleType.Intern,
                    FirstName = request.FirstName, LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber, Department = request.Department
                };
                newUser = _authService.RegisterPassword(newUser, request.PhoneNumber);

                var newIntern = new Intern 
                { 
                    UserId = newUser.UserId 
                };

                if (!String.IsNullOrEmpty(request.MentorId))
                {
                    var trueGuid = Guid.TryParse(request.MentorId, out var MentorGuid);
                    if (!trueGuid)
                    {
                        return new GenericResponse<List<InternResponseDTO>>
                        {
                            Successful = false,
                            ResponseCode = ResponseCode.INVALID_REQUEST,
                            Message = "Invalid MentorID Supplied"
                        };
                    }
                    Mentor selectedMentor = await _mentorRepo.GetAll().Include(x => x.User)
                                                                      .SingleAsync(x => x.MentorId == MentorGuid);
                    if (selectedMentor != null)
                    {
                        newIntern.MentorId = selectedMentor.MentorId;
                    }
                }
                await _userRepo.AddAsync(newUser);
                newIntern.UserId = newUser.UserId;
                await _internRepo.AddAsync(newIntern);

                //Crete response body
                var newInterns = InternResponseData(new List<Intern> { newIntern });
                return new GenericResponse<List<InternResponseDTO>>
                {
                    Successful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = newInterns
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while Creating Intern. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<List<InternResponseDTO>>
                { 
                    Successful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public async Task<GenericResponse<List<InternResponseDTO>>> GetAllInterns(int pageNumber, int pageSize)
        {
            _logger.LogInformation($"Received a request to fetch paginated Intern(s): Request: pageNumber:{pageNumber}, pageSize:{pageSize}");
            try
            {
                var pagedData = await _internRepo.GetAll()
                    .Include(x => x.User)
                    .Include(x => x.Mentor)
                        .ThenInclude(x => x.User)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var interns = InternResponseData(pagedData);
                return new GenericResponse<List<InternResponseDTO>>
                {
                    Successful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = interns
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured while Fecthing Data Request. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<List<InternResponseDTO>>
                {
                    Successful = false,
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
                    Successful = false,
                    ResponseCode = ResponseCode.NotFound
                };
            }
            try
            {
                if (vm.id != null)
                {
                    var intern = await _internRepo.GetAll().Include(x => x.User)
                                                     .Include(x => x.Mentor)
                                                         .ThenInclude(x => x.User)
                                                     .Where(x => x.InternId == vm.id)
                                                     .FirstOrDefaultAsync();
                    if (intern == null)
                    {
                        _logger.LogInformation($"Invalid ID Received: Request:{JsonConvert.SerializeObject(vm)}");
                        return new GenericResponse<List<InternResponseDTO>>
                        {
                            Successful = false,
                            ResponseCode = ResponseCode.NotFound
                        };
                    }

                    var collectedIntern = InternResponseData(new List<Intern> { intern });
                    return new GenericResponse<List<InternResponseDTO>>
                    {
                        Successful = true,
                        ResponseCode = ResponseCode.Successful,
                        Data = collectedIntern
                    };
                }

                // Received only name without department
                else if (vm.name != null && vm.department == null)
                {
                    var interns = await _internRepo.GetAll().Include(x => x.User)
                                                       .Include(x => x.Mentor)
                                                           .ThenInclude(x => x.User)
                                                       .Where(x => x.User.FirstName.Contains(vm.name) || x.User.LastName.Contains(vm.name))
                                                       .ToListAsync();
                    var collectedInterns = InternResponseData(interns);
                    return new GenericResponse<List<InternResponseDTO>>
                    {
                        Successful = true,
                        ResponseCode = ResponseCode.Successful,
                        Data = collectedInterns
                    };
                }

                //Received only Department without name
                //else if (model.name == null && model.department != null)
                else
                {
                    var interns = await _internRepo.GetAll().Include(x => x.User)
                                                        .Include(x => x.Mentor)
                                                            .ThenInclude(x => x.User)
                                                        .Where(x => x.User.Department == vm.department)
                                                        .ToListAsync();
                    var collectedInterns =  InternResponseData(interns);
                    return new GenericResponse<List<InternResponseDTO>>
                    {
                        Successful = true,
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
                    Successful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }


        public async Task<GenericResponse<InternResponseDTO>> UpdateIntern(UpdateInternVm vm)
        {
            _logger.LogInformation($"Received a request to update Intern: Request:{JsonConvert.SerializeObject(vm)}");
            try
            {
                var intern = await _userRepo.GetByIdAsync(vm.UserId);

                if (intern == null)
                {
                    return new GenericResponse<InternResponseDTO>
                    {
                        Successful = false,
                        ResponseCode = ResponseCode.NotFound
                    };
                }

                intern.Department = vm.Department;
                var selectedMentor = await _mentorRepo.GetByIdAsync(vm.MentorId);
                if (selectedMentor != null)
                {
                    intern.Intern.MentorId = vm.MentorId;
                }
                await _userRepo.UpdateAsync(intern);
                var updatedIntern = new InternResponseDTO
                {
                    InternId = intern.Intern.InternId, FirstName = intern.FirstName,
                    LastName = intern.LastName, Department = intern.Department,
                    MentorName = $"{intern.Intern.Mentor?.User.FirstName} {intern.Intern.Mentor?.User.LastName}"
                };
                return new GenericResponse<InternResponseDTO>
                {
                    Successful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = updatedIntern
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while updating intern. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<InternResponseDTO>
                {
                    Successful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public List<InternResponseDTO> InternResponseData(List<Intern> source)
        {
            List<InternResponseDTO> interns = new();
            foreach (var intern in source)
            {
                interns.Add(new InternResponseDTO
                {
                    InternId = intern.InternId,
                    FirstName = intern.User.FirstName,
                    LastName = intern.User.LastName,
                    Department = intern.User.Department,
                    MentorName = $"{intern.Mentor?.User?.FirstName} {intern.Mentor?.User?.LastName}",
                });
            };
            return interns;
        }
    }

}
