using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrialA_API.DTOs.ProfileDTOs;
using TrialA_API.Repositories.Interfaces;

namespace TrialA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateProfileController : ControllerBase
    {
        private readonly IUnitOfWork _repo;

        public CandidateProfileController(IUnitOfWork repo)
        {
            _repo = repo;
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id,ProfileUpdateDto dto)
        {
            var profile = await _repo.CandidateProfileRepository.GetById(id);

            if (profile == null)
                return NotFound("Profile not found");

            profile.Phone = dto.Phone;
            profile.ResumeURL = dto.ResumeURL;
            profile.YearsOfExerience = dto.YearsOfExerience;
            profile.Skill = dto.Skill;

            _repo.CandidateProfileRepository.Update(profile);
            await _repo.SaveChanges();

            return NoContent();

        }
    }
}
