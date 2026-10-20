using System.ComponentModel.DataAnnotations;
using TrialA_API.DTOs.CopmanyDTOs;

namespace TrialA_API.DTOs.JobDTOs
{
    public class JobResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal Salary { get; set; }
        public string EmploymentType { get; set; }

        public DateTime PostedDate { get; set; }
        public DateTime Deadline { get; set; }

        public string Status { get; set; }

        public CompanyResponseDto Company { get; set; }
    }
}
