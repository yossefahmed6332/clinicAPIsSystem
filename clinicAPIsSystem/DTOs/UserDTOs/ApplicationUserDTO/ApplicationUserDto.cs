namespace clinicAPIsSystem.DTOs.UserDTOs.ApplicationUserDTO
{
    public class ApplicationUserDto
    {
        public int Id { get; protected set; } 
        public string UserName { get; protected set; }
        public string Email { get; protected set; } 
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; } 
        public string PhoneNumber { get; protected set; }


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
