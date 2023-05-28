using System.ComponentModel.DataAnnotations;

namespace Web.DTOs.User
{
    public class UserUpdateDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
