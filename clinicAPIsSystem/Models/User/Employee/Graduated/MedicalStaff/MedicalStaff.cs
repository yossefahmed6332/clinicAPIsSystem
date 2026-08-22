namespace clinicAPIsSystem.Models.User.Employee.Graduated.MedicalStaff
{
    public abstract class MedicalStaff:Graduated
    {

        public MedicalStaff(string firstName, string lastName, string userName, string email, decimal salaryPerHour, int hoursWorked, TimeOnly shiftStart, TimeOnly shiftEnd, string degree, string university, int yearsOfExperience, int graduationYear, string license) : base(firstName, lastName, userName, email, salaryPerHour, hoursWorked, shiftStart, shiftEnd, degree, university, yearsOfExperience, graduationYear, license)
        {
        }
        public MedicalStaff() { }
        public ICollection<Appointment> Appointments { get;private set; } = new HashSet<Appointment>();

    }
}
