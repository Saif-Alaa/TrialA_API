using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrialA_API.DTOs.ApplicationDTOs;
using TrialA_API.Repositories.Interfaces;

namespace TrialA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IUnitOfWork _repo;

        public ApplicationController(IUnitOfWork repo)
        {
            _repo = repo;
        }

        [HttpPatch("{id}/status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            var application = await _repo.ApplicationRepository.GetById(id);

            if (application == null)
                return NotFound("Application not found");
            //"Pending","UnderReview","Accepted","Rejected"
            if (status == "Pending" || status == "UnderReview" || status == "Accepted" || status == "Rejected")
                application.Status = status;
            else
                return BadRequest("Status value is not valid");

            _repo.ApplicationRepository.Update(application);
            await _repo.SaveChanges();

            return NoContent();


        }
        [HttpGet]
        [Authorize(Roles = "Candidate")]
        public async Task<IActionResult> GetAllByCandidate()
        {
            var candidateId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var candidate = await _repo.UserRepository.GetUser(candidateId);

            if (candidate == null)
                return NotFound("Candidate not found");;

            var candidateProfile = candidate.CandidateProfile;

            var applications = await _repo.ApplicationRepository.GetAllByCandidateId(candidateProfile.Id);

            var applicationsDto = applications.Select(a => new ApplicationUserDto
            {
                Id = a.Id,
                ApplicationDate = a.ApplicationDate,
                Status = a.Status,
                CoverLetter = a.CoverLetter,
            });

            return Ok(applicationsDto);
        }
    }
}
