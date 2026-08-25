using clinicAPIsSystem.Models;
using Microsoft.Identity.Client;

namespace clinicAPIsSystem.IRepositoryService
{
    public interface IPrescriptionRepository
    {
        public Task<Prescription> ICreatePrescriptionAsync();
        public Task<List<Prescription>> IGetAllPrescriptionsAsync();
        public Task<Prescription> IGetPrescriptionAsync(int id);
        public Task<List<Prescription>> IGetPrescriptionsByPatientIdAsync(int patientId);
        public Task<List<Prescription>> IGetPrescriptionsByDoctorIdAsync(int doctorId);
        public Task<Prescription> IUpdatePrescriptionAsync(Prescription prescription);
        public Task IDeletePrescriptionAsync(int id);   
    }
}
