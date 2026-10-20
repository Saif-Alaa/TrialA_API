using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrialA_API.DTOs.CopmanyDTOs;
using TrialA_API.Repositories.Interfaces;

namespace TrialA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IUnitOfWork _repo;

        public CompanyController(IUnitOfWork repo)
        {
            _repo = repo;
        }

        [HttpGet("most-jobs")]

        public async Task<IActionResult> GetMostJobs()
        {
            var company = await _repo.CompanyRepository.GetMostJobs();

            var companyDto = new CompanyResponseDto
            {
                Id = company.Id,
                Description = company.Description,
                Location = company.Location,
                Name = company.Name,
                Website = company.Website,
            };

            return Ok(companyDto);
        }
    }
}
