using System.ComponentModel.DataAnnotations;

namespace TrialA_API.DTOs.UserDtos
{
    public class RegisterRequestDto
    {
        [Required, Length(3, 100)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required, AllowedValues("Candidate", "Employer")]
        public string Role { get; set; }
    }
}
