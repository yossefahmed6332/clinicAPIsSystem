namespace clinicAPIsSystem.Models.User.Employee.Graduated.MedicalStaff
{
    public class Doctor:MedicalStaff
    {

        public Doctor(string firstName, string lastName, string userName, string email, decimal salaryPerHour, int hoursWorked, TimeOnly shiftStart, TimeOnly shiftEnd, string degree, string university, int yearsOfExperience, int graduationYear, string license) : base(firstName, lastName, userName, email, salaryPerHour, hoursWorked, shiftStart, shiftEnd, degree, university, yearsOfExperience, graduationYear, license)
        {
        }
        public Doctor() { }
        public ICollection<Prescription> Prescriptions { get; private set; } = new HashSet<Prescription>();
    }
}
