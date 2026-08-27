using clinicAPIsSystem.IService;
using AutoMapper;
using clinicAPIsSystem.IRepositoryService;
using clinicAPIsSystem.DTOs.MedicalRecordDTOs;
using clinicAPIsSystem.Models;
namespace clinicAPIsSystem.Service
{
    public class MedicalRecordService:IMedicalRecordService
    {
        private readonly IMapper _mapper;
        private readonly IMedicalRecordRepository _medicalRecordRepository;
        public MedicalRecordService(IMapper mapper, IMedicalRecordRepository medicalRecordRepository)
        {
            _mapper = mapper;
            _medicalRecordRepository = medicalRecordRepository;
        }

        public async Task<MedicalRecordDto> CreateMedicalRecordAsync(CreateMedicalRecordDto createMedicalRecord)
        {
            var medicalRecord = new MedicalRecord
                (
                );
            medicalRecord = await _medicalRecordRepository.CreateMedicalRecordAsync(medicalRecord);
            return _mapper.Map<MedicalRecordDto>(medicalRecord);
        }

        public async Task<List<MedicalRecordDto>> GetAllMedicalRecordsAsync()
        {
            var medicalRecords = await _medicalRecordRepository.GetAllMedicalRecordsAsync();
            return _mapper.Map<List<MedicalRecordDto>>(medicalRecords);
        }

        public async Task<MedicalRecordDto> GetMedicalRecord(int id)
        {
            var medicalRecord = await _medicalRecordRepository.GetMedicalRecordAsync(id);
            return _mapper.Map<MedicalRecordDto>(medicalRecord);
        }

        public async Task<MedicalRecordDto> GetMedicalByPatientIdRecord(int PatientId)
        {
            var medicalRecord = await _medicalRecordRepository.GetMedicalRecordByPatientIdAsync(PatientId);
            return _mapper.Map<MedicalRecordDto>(medicalRecord);
        }

        public async Task<MedicalRecordDto> UpdateMedicalRecordAsync(UpdateMedicalRecordDto updateMedicalRecord)
        {
            var medicalRecord = _mapper.Map<MedicalRecord>(updateMedicalRecord);
            medicalRecord = await _medicalRecordRepository.UpdateMedicalRecordAsync(medicalRecord);
            return _mapper.Map<MedicalRecordDto>(medicalRecord);
        }



    }
}
