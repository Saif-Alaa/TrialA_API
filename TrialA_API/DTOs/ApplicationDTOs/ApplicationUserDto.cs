using System.ComponentModel.DataAnnotations;

namespace TrialA_API.DTOs.ApplicationDTOs
{
    public class ApplicationUserDto
    {
        public int Id { get; set; }

        public DateTime ApplicationDate { get; set; }

        public string Status { get; set; }
        public string CoverLetter { get; set; }
    }
}
