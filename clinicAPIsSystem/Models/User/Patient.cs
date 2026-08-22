namespace clinicAPIsSystem.Models.User
{
    public class Patient: ApplicationUser
    {
        public ICollection<Appointment> Appointments { get;  set; } = new HashSet<Appointment>();
        public MedicalRecord MedicalRecord {  get;  set; } = new MedicalRecord();
        public int MedicalRecordId { get; set; } 

        public ICollection<PaymentOperation> PaymentOperations { get; set; } = new HashSet<PaymentOperation>();


    }
}
