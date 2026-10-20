using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrialA_API.DTOs.JobDTOs;
using TrialA_API.Models;
using TrialA_API.Repositories.Interfaces;

namespace TrialA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IUnitOfWork _repo;

        public JobController(IUnitOfWork repo)
        {
            _repo = repo;
        }

        [HttpGet("third-highest-salary")]

        public async Task<IActionResult> GetThirdHihestSalary()
        {
            var job = await _repo.JobRepository.GetThirdHighestSalary();

            if (job == null)
                return NotFound("No third option");

            return Ok(new { Salary = job.Salary});
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var job = await _repo.JobRepository.GetById(id);

            if (job == null)
                return NotFound("Job not found");

            var jobDto = new JobResponseDto
            {
                Id = job.Id,
                Status = job.Status,
                Deadline = job.Deadline,
                Description = job.Description,
                EmploymentType = job.EmploymentType,
                Location = job.Location,
                Salary = job.Salary,
                PostedDate = job.PostedDate,
                Title = job.Title,
                Company = new DTOs.CopmanyDTOs.CompanyResponseDto
                {
                    Id = job.CompanyId,
                    Name = job.Company.Name,
                    Description = job.Company.Description,
                    Location = job.Company.Location,
                    Website = job.Company.Website,
                }
            };

            return Ok(jobDto);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(int id)
        {
            var job = await _repo.JobRepository.GetById(id);

            if (job == null)
                return NotFound("Job not found");

            foreach(var application in job.Applications)
            {
                _repo.ApplicationRepository.Delete(application);
            }

            _repo.JobRepository.Delete(job);

            await _repo.SaveChanges();

            return NoContent();
        }
        [HttpGet("search")]

        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var jobs = await _repo.JobRepository.Search(keyword);

            var jobsDto = jobs.Select(job => new JobResponseDto
            {
                Id = job.Id,
                Status = job.Status,
                Deadline = job.Deadline,
                Description = job.Description,
                EmploymentType = job.EmploymentType,
                Location = job.Location,
                Salary = job.Salary,
                PostedDate = job.PostedDate,
                Title = job.Title,
                Company = new DTOs.CopmanyDTOs.CompanyResponseDto
                {
                    Id = job.CompanyId,
                    Name = job.Company.Name,
                    Description = job.Company.Description,
                    Location = job.Company.Location,
                    Website = job.Company.Website,
                }
            });

            return Ok(jobsDto);
        }
    }
}
