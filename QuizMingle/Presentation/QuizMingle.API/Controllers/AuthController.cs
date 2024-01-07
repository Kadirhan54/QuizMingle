using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizMingle.API.Models;
using QuizMingle.API.Services;
using QuizMingle.Domain.Identity;
using QuizMingle.Persistence.Context;
using QuizMingle.Persistence.Service;
using System.Security.Claims;

namespace QuizMingle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly QuizMingleDbContext _context;
        private readonly ITokenService _tokenService;
        public AuthController(UserManager<User> userManager, QuizMingleDbContext quizMingleDbContext, ITokenService tokenService )
        {
            _userManager = userManager;
            _context = quizMingleDbContext;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Guid userId = Guid.NewGuid();
            var result = await _userManager.CreateAsync(
                new User 
                {
                    Id= userId,
                    UserName = request.Username,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    CreatedByUserId = "halaymaster"
                },
                request.Password
            );

            if (result.Succeeded)
            {
                request.Password = "";
                return CreatedAtAction(nameof(Register), new { email = request.Email }, request);
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var managedUser = await _userManager.FindByEmailAsync(request.Email);
            if (managedUser == null)
            {
                return BadRequest("Bad credentials");
            }
            var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);
            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }
            var userInDb = _context.Users.FirstOrDefault(u => u.Email == request.Email);
            if (userInDb is null)
                return Unauthorized();

            var accessToken = _tokenService.CreateToken(userInDb);
            await _context.SaveChangesAsync();
            return Ok(new AuthResponse
            {
                Username = userInDb.UserName,
                Email = userInDb.Email,
                Token = accessToken,
            });
        }

        [HttpGet]
        [Route("GetUserId")]
        public IActionResult GetUserId()
        {
            var userName = User.FindFirst(ClaimTypes.Name)?.Value;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized("Kullanıcı ID'si bulunamadı.");
            }

            return Ok(new { Name = userName, Id = userId });
        }
    }
}