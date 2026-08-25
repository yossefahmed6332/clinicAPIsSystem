using clinicAPIsSystem.Data;
using clinicAPIsSystem.IRepositoryService.IUserRepository.INonMedicalStaffRepository;
using clinicAPIsSystem.Models;
using clinicAPIsSystem.Models.User;
using clinicAPIsSystem.Models.User.Employee.Graduated.NonMedicalStaff;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace clinicAPIsSystem.RepositoryService.UserRepository.NonMedicalStaffRepository
{
    public class ReceptionistRepository : IReceptionistRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ClinicDbContext _context;

        public ReceptionistRepository(
            UserManager<ApplicationUser> userManager,
            ClinicDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<(
            Receptionist receptionist,
            bool addUserRes,
            bool addPasswordRes,
            bool addRoleRes)> ICreateReceptionistAsync(
                Receptionist receptionist,
                string password)
        {
            var addUserRes =
                await _userManager.CreateAsync(receptionist);

            if (!addUserRes.Succeeded)
                return (receptionist, false, false, false);

            var addPasswordRes =
                await _userManager.AddPasswordAsync(
                    receptionist,
                    password);

            if (!addPasswordRes.Succeeded)
                return (receptionist, true, false, false);

            var addRoleRes =
                await _userManager.AddToRoleAsync(
                    receptionist,
                    UserRole.Receptionist.ToString());

            return (
                receptionist,
                true,
                true,
                addRoleRes.Succeeded);
        }

        public async Task<List<Receptionist>> IGetAllReceptionistsAsync()
        {
            return await _context.TReceptionists.ToListAsync();
        }

        public async Task<Receptionist> IGetReceptionistAsync(int id)
        {
            return await _context.TReceptionists.FindAsync(id);
        }

        public async Task<Receptionist> IUpdateReceptionistAsync(
            Receptionist receptionist)
        {
            _context.TReceptionists.Update(receptionist);

            await _context.SaveChangesAsync();

            return receptionist;
        }

        public async Task IDeleteReceptionistAsync(
            Receptionist receptionist)
        {
            _context.TReceptionists.Remove(receptionist);

            await _context.SaveChangesAsync();
        }
    }
}