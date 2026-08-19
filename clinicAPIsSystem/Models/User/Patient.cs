namespace clinicAPIsSystem.Models.User
{
    public class Patient: ApplicationUser
    {
        public ICollection<Appointment> Appointments { get;  set; } = new HashSet<Appointment>();
        public ICollection<Prescription> Prescriptions { get;  set; } = new HashSet<Prescription>();
        public ICollection <VitalSigns> VitalSigns { get;  set; } = new HashSet<VitalSigns>();
        public ICollection<ExaminationResult> ExaminationResults { get;  set; } = new HashSet<ExaminationResult>(); 
        public MedicalRecord MedicalRecord {  get;  set; } = new MedicalRecord();
        public int MedicalRecordId { get; set; } 

        public ICollection<Operation> Operations { get; set; } = new HashSet<Operation>();


    }
}
