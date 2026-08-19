using Microsoft.VisualBasic;

namespace clinicAPIsSystem.Models.User.Employee.Graduated.NonMedicalStaff
{
    public class Manager:NonMedicalStaff
    {
        public ICollection<FinancialReport> FinancialReports { get; set; } = new HashSet<FinancialReport>();

    }
}
