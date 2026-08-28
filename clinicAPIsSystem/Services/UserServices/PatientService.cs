using clinicAPIsSystem.DTOs.MedicalRecordDTOs;
using clinicAPIsSystem.DTOs.UserDTOs.PatientDTO;
using clinicAPIsSystem.IRepositoryService.IUserRepository;
using clinicAPIsSystem.IService;
using clinicAPIsSystem.IServices.IUserServices;
using clinicAPIsSystem.Models.User;
using AutoMapper; 
namespace clinicAPIsSystem.Services.UserServices

{
    public class PatientService:IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUserService _userService;
        private readonly IMedicalRecordService _medicalRecordService; 
        private readonly IMapper _mapper;
        public PatientService(IPatientRepository patientRepository, IUserService userService, IMedicalRecordService medicalRecordService, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _userService = userService;
            _medicalRecordService = medicalRecordService;
            _mapper = mapper;
        }

        public async Task<PatientDto> CreatePatientAsync(CreatePatientDto createPatientDto,CreateMedicalRecordDto createMedicalRecordDto, string password)
        {
            await _userService.ValidateUserCreation(createPatientDto.Email,createPatientDto.UserName,createPatientDto.PhoneNumber);
            var medicalRecord= await _medicalRecordService.CreateMedicalRecordAsync(createMedicalRecordDto);

            var patient = new Patient(medicalRecord.Id,createPatientDto.FirstName,createPatientDto.LastName,createPatientDto.UserName,createPatientDto.Email,createPatientDto.PhoneNumber);
            var patientCreated = await  _patientRepository.CreatePatientAsync(patient, password);

            if (!(patientCreated.addUserRes &&
                patientCreated.addPasswordRes &&
                patientCreated.addRoleRes))
            {
                if (patientCreated.addUserRes)
                {
                    await _userService.DeleteUserAsync(patientCreated.patient.Id);
                }
                throw new Exception("Cannot create user, try again");
            }

            return _mapper.Map<PatientDto>(patientCreated.patient);
        }


        public async Task<List<PatientDto>> GetAllPatientsAsync()
        {
            return _mapper.Map<List<PatientDto>>(await _patientRepository.GetAllPatientsAsync());
        }
        public async Task<PatientDto?> GetPatientAsync(int id)
        {
            var patient = await _patientRepository.GetPatientAsync(id);
            if (patient == null)
            {
                throw new KeyNotFoundException($"Cannot find user with ID{id}");
            }
            return _mapper.Map<PatientDto>(patient);
        }
        public async Task<PatientDto> UpdatePatientAsync(UpdatePatientDto patient, int id)
        {
            var patientEntity = await _patientRepository.GetPatientAsync(id);
            if (patientEntity == null)
            {
                throw new KeyNotFoundException($"Cannot find user with ID{id}");
            }
            patientEntity.UpdatePatientInfo(patient.FirstName, patient.LastName, patient.UserName, patient.Email, patient.PhoneNumber);
            var updatedPatient = await _patientRepository.UpdatePatientAsync(patientEntity);    
            return _mapper.Map<PatientDto>(updatedPatient);
        }



    }
}
