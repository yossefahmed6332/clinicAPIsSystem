using clinicAPIsSystem.IRepositoryService;
using clinicAPIsSystem.IService;
using AutoMapper;
using clinicAPIsSystem.DTOs.PrescriptionDTOs;
using clinicAPIsSystem.Models;

namespace clinicAPIsSystem.Service
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IMapper _mapper;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository, IMapper mapper)
        {
            _mapper = mapper;
            _prescriptionRepository = prescriptionRepository;
        }


        public async Task<PrescriptionDto> CreatePrescriptionAsync(CreatePrescriptionDto createPrescriptionDto)
        {
            var prescription = new Prescription(
                createPrescriptionDto.MedicalName,
                createPrescriptionDto.Dosage,
                createPrescriptionDto.Frequency,
                createPrescriptionDto.Duration,
                createPrescriptionDto.Instructions,
                createPrescriptionDto.Diagnosis,
                createPrescriptionDto.Date,
                createPrescriptionDto.DoctorId,
                createPrescriptionDto.medicalRecordId
            );  
            prescription = await _prescriptionRepository.CreatePrescriptionAsync(prescription);
            return _mapper.Map<PrescriptionDto>(prescription);
        }

        public async Task<List<PrescriptionDto>> GetAllPrescriptionsAsync()
        {
            return _mapper.Map<List<PrescriptionDto>>(await _prescriptionRepository.GetAllPrescriptionsAsync());
        }

        public async Task<PrescriptionDto> GetPrescriptionAsync(int id)
        {
            var prescription = await _prescriptionRepository.GetPrescriptionAsync(id);
            if (prescription == null)
            {
                throw new KeyNotFoundException($"Prescription with ID{id} does not exist");

            }

            return _mapper.Map<PrescriptionDto>(prescription);
        }

        public async Task<List<PrescriptionDto>> GetPrescriptionsByMedicalRecordIdAsync(int medicalRecordId)
        {
            return _mapper.Map<List<PrescriptionDto>>(await _prescriptionRepository.GetPrescriptionsByMedicalRecordIdAsync(medicalRecordId));
        }

        public async Task<List<PrescriptionDto>> GetPrescriptionsByDoctorIdAsync(int doctorId)
        {
            return _mapper.Map<List<PrescriptionDto>>(await _prescriptionRepository.GetPrescriptionsByDoctorIdAsync(doctorId));

        }

        public async Task<PrescriptionDto> UpdatePrescriptionAsync(UpdatePrescriptionDto updatePrescriptionDto,int id)
        {
            var prescription = await _prescriptionRepository.GetPrescriptionAsync(id);
            if (prescription == null)
            {
                throw new KeyNotFoundException($"Prescription with ID {id} does not exist");
            }

            prescription.Update(
                updatePrescriptionDto.MedicalName,
                updatePrescriptionDto.Dosage,
                updatePrescriptionDto.Frequency,
                updatePrescriptionDto.Duration,
                updatePrescriptionDto.Instructions,
                updatePrescriptionDto.Diagnosis
                );
            prescription = await _prescriptionRepository.UpdatePrescriptionAsync(prescription);

            return _mapper.Map<PrescriptionDto>(prescription) ;
        }

        public async Task DeletePrescriptionAsync(int id)
        {
            var prescription = await _prescriptionRepository.GetPrescriptionAsync(id); 
            if (prescription == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found");
            }
            await _prescriptionRepository.DeletePrescriptionAsync(prescription);
            

        }
    }
}
