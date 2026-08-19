namespace clinicAPIsSystem.Models.User.Employee.Graduated
{
    public abstract class Graduated:Employee
    {
        protected string Degree { get; set; } = null!;
        protected string University { get; set; } = null!; 
        protected int YearsOfExperience { get; set; }
        protected string License { get; set; }=null!;

    }
}
