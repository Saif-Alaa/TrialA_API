using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrialA_API.Models
{
    public class CandidateProfile
    {
        [Key]
        public int Id { get; set; }
        [Required,Phone]
        public string Phone {  get; set; }
        public string? ResumeURL { get; set; }
        [Required,MaxLength(500)]
        public string Skill {  get; set; }
        [Required,Range(0,50)]
        public int YearsOfExerience { get; set; }
        [ForeignKey(nameof(Candidate))]
        public int CandidateId { get; set; }
        public User Candidate { get; set; }

        public ICollection<Application>? Applications { get; set; }
    }
}
