using clinicAPIsSystem.IRepositoryService.IUserRepository;
using AutoMapper;
using clinicAPIsSystem.DTOs.UserDTOs.AdminDTO;
using clinicAPIsSystem.IServices.IUserServices;
using clinicAPIsSystem.Models.User;
namespace clinicAPIsSystem.Services.UserServices
{
    public class AdminService:IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService; 

        public AdminService(IAdminRepository adminRepository, IMapper mapper, IUserService userService)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<AdminDto> CreateAdminAsync(CreateAdminDto admin, string password)
        {
            await _userService.ValidateUserCreation(admin.Email, admin.UserName, admin.PhoneNumber);

            var adminEntity = new Admin(admin.FirstName, admin.LastName, admin.Email, admin.UserName, admin.PhoneNumber);
            var createdAdmin = await _adminRepository.CreateAdminAsync(adminEntity, password);

            if (!(createdAdmin.addUserRes &&
                createdAdmin.addPasswordRes &&
                createdAdmin.addRoleRes))
            {
                if (createdAdmin.addUserRes)
                {
                    await _userService.DeleteUserAsync(createdAdmin.admin.Id);
                }

                throw new Exception("Cannot create user, try again");
            }

            return _mapper.Map<AdminDto>(createdAdmin.admin);
        }

        public async Task<List<AdminDto>> GetAllAdminsAsync()
        {
            return _mapper.Map<List<AdminDto>>(await _adminRepository.GetAllAdminsAsync());
        }

        public async Task<AdminDto> GetAdminAsync(int id)
        {
            var admin = await _adminRepository.GetAdminAsync(id);
            if (admin == null)
            {
                throw new KeyNotFoundException($"Cannot find user with ID{id}");
            }

            return _mapper.Map<AdminDto>(admin);
        }


        public async Task<AdminDto> UpdateAdminAsync (UpdateAdminDto admin, int id)
        {
            await _userService.ValidateUserCreation(admin.Email,admin.UserName, admin.PhoneNumber);
            var adminEntity = await _adminRepository.GetAdminAsync(id);
            if (adminEntity == null)
                throw new KeyNotFoundException($"Cannot found user with id {id}");
            adminEntity.UpdateAdminInfo(admin.FirstName, admin.LastName, admin.UserName, admin.Email, admin.PhoneNumber);
            var updateAdmin = await _adminRepository.UpdateAdminAsync(adminEntity); 
            return _mapper.Map<AdminDto>(updateAdmin);
        }




    }
}
