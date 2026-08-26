using AutoMapper;
using clinicAPIsSystem.DTOs.ExaminationResultDTOs;
using clinicAPIsSystem.IService;
using clinicAPIsSystem.IRepositoryService;
using clinicAPIsSystem.Models;

namespace clinicAPIsSystem.Service
{
    public class ExaminationResultService : IExaminationResultService
    {
        private readonly IMapper _mapper;
        private readonly IExaminationResultRepository _examinationResultRepository;
        public ExaminationResultService(IMapper mapper, IExaminationResultRepository examinationResultRepository)
        {
            _mapper = mapper;

            _examinationResultRepository = examinationResultRepository;

        }
        public async Task<ExaminationResultDto> CreateExaminationResultAsync(CreateExaminationResultDto createExaminationResultDto)
        {
            var examinationResult = new ExaminationResult(
                createExaminationResultDto.TestType
                , createExaminationResultDto.ResultValue
                , createExaminationResultDto.Unit
                , createExaminationResultDto.NormalRange
                , createExaminationResultDto.Note
                , createExaminationResultDto.RecordedAt
                , createExaminationResultDto.NurseId
                , createExaminationResultDto.MedicalRecordId
            );
            examinationResult = await _examinationResultRepository.CreateExaminationResultAsync(examinationResult);
            return _mapper.Map<ExaminationResultDto>(examinationResult);
        }

        public async Task<List<ExaminationResultDto>> GetAllExaminationResultsAsync()
        {
            var examinationResults = await _examinationResultRepository.GetAllExaminationResultsAsync();
            return _mapper.Map<List<ExaminationResultDto>>(examinationResults);
        }

        public async Task<ExaminationResultDto> GetExaminationResultAsync(int id)
        {
            var examinationResult = await _examinationResultRepository.GetExaminationResultAsync(id);
            if (examinationResult == null)
            {
                throw new KeyNotFoundException($"Examination Result with ID {id} not found.");
            }
            return _mapper.Map<ExaminationResultDto>(examinationResult);
        }
        public async Task<List<ExaminationResultDto>> GetExaminationResultsByNurseIdAsync(int nurseId)
        {
         
            var examinationResults = await _examinationResultRepository.GetExaminationResultsByNurseIdAsync(nurseId);
            return _mapper.Map<List<ExaminationResultDto>>(examinationResults);
        }
        public async Task<List<ExaminationResultDto>> GetExaminationResultsByMedicalRecordIdAsync(int medicalRecordId)
        {

            var examinationResults = await _examinationResultRepository.GetExaminationResultsByMedicalRecordIdAsync(medicalRecordId);
            return _mapper.Map<List<ExaminationResultDto>>(examinationResults);
        }
        public async Task<ExaminationResultDto> UpdateExaminationResultAsync(UpdateExaminationResultDto updateExaminationResultDto,int id)
        {
            var examinationResult = await _examinationResultRepository.GetExaminationResultAsync(id);
            if (examinationResult == null)
            {
                throw new KeyNotFoundException($"Examination result with ID {id} not found");
            }
            examinationResult = await _examinationResultRepository.UpdateExaminationResultAsync(examinationResult);
            return _mapper.Map<ExaminationResultDto>(examinationResult);
        }

        public async Task DeleteExaminationResultAsync(int id)
        {
            var examinationResult = await _examinationResultRepository.GetExaminationResultAsync(id);
            if (examinationResult == null)
            {
                throw new KeyNotFoundException($"Examination result with ID {id} not found");
            }
            await _examinationResultRepository.DeleteExaminationResultAsync(examinationResult);
        }
    }
}