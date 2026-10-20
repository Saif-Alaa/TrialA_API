using System.ComponentModel.DataAnnotations;

namespace TrialA_API.DTOs.ProfileDTOs
{
    public class ProfileUpdateDto
    {
        [Required, Phone]
        public string Phone { get; set; }
        public string? ResumeURL { get; set; }
        [Required, MaxLength(500)]
        public string Skill { get; set; }
        [Required, Range(0, 50)]
        public int YearsOfExerience { get; set; }
    }
}
