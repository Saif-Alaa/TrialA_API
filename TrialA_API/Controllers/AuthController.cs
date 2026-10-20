using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrialA_API.DTOs.UserDtos;
using TrialA_API.Helpers;
using TrialA_API.Models;
using TrialA_API.Repositories.Interfaces;

namespace TrialA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        private readonly ITokenHelper _tokenHelper;

        public AuthController(IUnitOfWork repo, ITokenHelper tokenHelper)
        {
            _repo = repo;
            _tokenHelper = tokenHelper;
        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login(LoginRequestDto dto)
        {
            var user = await _repo.UserRepository.GetUserByEmail(dto.Email);

            if (user == null)
                return NotFound("User not found");

            if (user.Password != dto.Password)
                return Unauthorized("Email or password are incorrect");

            var token = _tokenHelper.GenerateToken(user);

            return Ok(token);
        }

        [HttpPost("Register")]

        public async Task<IActionResult> Register(RegisterRequestDto dto)
        {
            if (dto.Role == "Admin")
                return BadRequest("Cannot register new admin");

            if (await _repo.UserRepository.IsEmailExist(dto.Email))
                return BadRequest("Email is already exist");

            var user = new User
            {
                Email = dto.Email,
                FullName = dto.FullName,
                CreatedAt = DateTime.Now,
                Role = dto.Role,
                Password = dto.Password,
            };

            await _repo.UserRepository.Add(user);
            await _repo.SaveChanges();

            return CreatedAtAction("Register", new { Id = user.Id, Email = user.Email, Role = user.Role  });
        }
    }
}
