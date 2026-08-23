namespace clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO
{
    public class ApplicationUserDto
    {
        public int Id { get; private set; } 
        public string UserName { get; private set; }
        public string Email { get; private set; } 
        public string FirstName { get; private set; }
        public string LastName { get; private set; } 
        public string PhoneNumber { get; private set; }


        public ApplicationUserDto(int id, string userName, string email, string firstName, string lastName, string phoneNumber)
        {
            Id = id;
            UserName = userName;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
    }
}
