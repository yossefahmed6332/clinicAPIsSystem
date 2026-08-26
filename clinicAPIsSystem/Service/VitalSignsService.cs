using AutoMapper;
using clinicAPIsSystem.DTOs.VitalSignsDTOs;
using clinicAPIsSystem.IService;
using clinicAPIsSystem.Models;
using clinicAPIsSystem.IRepositoryService;
using clinicAPIsSystem.Models.User;
namespace clinicAPIsSystem.Service
{
    public class VitalSignsService:IVitalSignsService
    {
        private readonly IVitalSignsRepository _vitalSignsRepository;
        private readonly IMapper _mapper;

        public VitalSignsService(IVitalSignsRepository vitalSignsService, IMapper mapper)
        {
            _mapper = mapper;
            _vitalSignsRepository = vitalSignsService;
        }

        public async Task<VitalSignsDto> CreateVitalSignsAsync (CreateVitalSignsDto createVitalSignsDto)
        {
            var vitalSigns = _mapper.Map<VitalSigns>(createVitalSignsDto);
            vitalSigns = await _vitalSignsRepository.CreateVitalSignsAsync(vitalSigns);
            return _mapper.Map<VitalSignsDto>(vitalSigns);
        }

        public async Task<List<VitalSignsDto>> GetAllVitalSignsAsync ()
        {
            return _mapper.Map<List<VitalSignsDto>>(await _vitalSignsRepository.GetAllVitalSignsAsync());
        }

        public async Task<VitalSignsDto> GetVitalSignsAsync (int id) 
      {
            var vitalSigns = await _vitalSignsRepository.GetVitalSignsAsync(id); 
            if (vitalSigns == null)
            {
                throw new Exception($"User with ID{id} not found.");
            }

            return _mapper.Map<VitalSignsDto> (vitalSigns); 
      }

        public async Task<List<VitalSignsDto>> GetVitalSignsByMedicalRecordIdAsync(int medicalRecordId)
        {
            return _mapper.Map<List<VitalSignsDto>>(await _vitalSignsRepository.GetVitalSignsByMedicalRecordIdAsync(medicalRecordId)); 
        }


        public async Task<List<VitalSignsDto>> GetVitalSignsByNurseIdAsync(int nurseId)
        {
            return _mapper.Map<List<VitalSignsDto>>(await _vitalSignsRepository.GetVitalSignsByNurseIdAsync(nurseId));
        }

        public async Task<VitalSignsDto> UpdateVitalSignsAsync(UpdateVitalSignsDto updateVitalSignsDto,int id)
        {
            var vitalSigns = _mapper.Map<VitalSigns>(updateVitalSignsDto);
            vitalSigns.Id = id;

             vitalSigns = await _vitalSignsRepository.UpdateVitalSignsAsync(vitalSigns);
            return _mapper.Map<VitalSignsDto>(vitalSigns);

        }

        public async Task DeleteVitalSignsAsync (int id)
        {
            var vitalSigns = await _vitalSignsRepository.GetVitalSignsAsync(id);
            if (vitalSigns == null)
            {
                throw new KeyNotFoundException($"Vital Signs with ID{id} Not found");
            }
        }


    }
}
