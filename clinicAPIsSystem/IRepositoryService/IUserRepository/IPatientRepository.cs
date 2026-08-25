using clinicAPIsSystem.Models;
using clinicAPIsSystem.Models.User;

namespace clinicAPIsSystem.IRepositoryService.IUserRepository
{
    public interface IPatientRepository
    {
        public Task<Patient> ICreatePatientAsync();
        public Task<List<Patient>> IGetAllPatientsAsync ();
        public Task<Patient> IGetPatientAsync(int id);
        public Task<(List<Appointment>, List<PaymentOperation>)> IGetPatientDetailsAsync(int id);
        public Task<Patient> IUpdatePatientAsync( Patient patient);
        public Task IDeletePatientAsync(int id);

    }
}
