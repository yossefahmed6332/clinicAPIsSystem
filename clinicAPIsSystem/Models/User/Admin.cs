namespace clinicAPIsSystem.Models.User
{
    public class Admin:ApplicationUser
    {
       
        public Admin(string firstName, string lastName, string userName, string email): base(firstName, lastName, userName, email)
        {

        }

    }
}
