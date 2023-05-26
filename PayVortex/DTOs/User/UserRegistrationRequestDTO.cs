using BusinessLayer.Models.Users;

namespace Web.DTOs.User
{
    public class UserRegistrationRequestDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
