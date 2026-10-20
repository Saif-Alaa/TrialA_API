using System.ComponentModel.DataAnnotations;

namespace TrialA_API.DTOs.CopmanyDTOs
{
    public class CompanyResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string? Website { get; set; }
        public string Location { get; set; }
    }
}
