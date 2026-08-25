using clinicAPIsSystem.Models;

namespace clinicAPIsSystem.IRepositoryService
{
    public interface IExaminationResult
    {
        public Task<ExaminationResult> ICreateExaminationResultAsync();
        public Task<List<ExaminationResult>> IGetAllExaminationResultsAsync();
        public Task<ExaminationResult> IGetExaminationResultAsync(int id);
        public Task<List<ExaminationResult>> IGetExaminationResultsByNurseIdAsync(int nurseId);
        public Task<List<ExaminationResult>> IGetExaminationResultsByPatientIdAsync(int patientId);
        public Task<ExaminationResult> IUpdateExaminationResultAsync(ExaminationResult examinationResult);
        public Task IDeleteExaminationResultAsync(int id);
    }
}
