using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizMingle.Domain.Identity;
using QuizMingle.Persistence.Context;
using QuizMingle.Persistence.Service;
using System.Security.Claims;

namespace QuizMingle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly QuizMingleDbContext _context;
        private readonly ITokenService _tokenService;

        public UserController(UserManager<User> userManager, QuizMingleDbContext quizMingleDbContext, ITokenService tokenService)
        {
            _userManager = userManager;
            _context = quizMingleDbContext;
            _tokenService = tokenService;
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

        [HttpPost]
        [Route("DeleteUserById/{Id:Guid}")]
        public async Task<IActionResult> DeleteUserById([FromRoute] Guid Id)
        {
            var userToDelete = _context.Users.FirstOrDefault(u => u.Id == Id);

            if (userToDelete == null)
            {
                return NotFound("Kullanıcı bulunamadı."); 
            }

            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync(); 

            return Ok($"ID: {Id} " + "\nKullanıcı başarıyla silindi.");
        }

    }
}
