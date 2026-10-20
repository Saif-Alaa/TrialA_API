using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace TrialA_API.Models
{
    [Index(nameof(Email),IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required,Length(3,100)]
        public string FullName { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required,AllowedValues("Candidate","Employer","Admin")]
        public string Role { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        public CandidateProfile? CandidateProfile { get; set; }

        public ICollection<Company>? EmpployerCompanies { get; set; }
    }
}
