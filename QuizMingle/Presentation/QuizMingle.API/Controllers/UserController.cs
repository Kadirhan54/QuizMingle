using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizMingle.API.Models;
using QuizMingle.Domain.Entities;
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
        [Route("GetUserById/{Id:Guid}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid Id)
        {
            var user = _context.Users
                .Include(x => x.UserQuizzes)
                .FirstOrDefault(u => u.Id == Id);

            if (user == null)
            {
                return NotFound("Kullanıcı ID'si bulunamadı.");
            }

            var result = new UserResponseModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                CreatedByUserId = user.CreatedByUserId,
                CreatedOn = user.CreatedOn,
                ModifiedByUserId = user.ModifiedByUserId,
                ModifiedOn = user.ModifiedOn,
                UserQuizzes = user.UserQuizzes
                    .Select(quiz => new UserQuiz
                    {
                        UserId = Id,
                        QuizId = quiz.QuizId,
                        CreatedByUserId = quiz.CreatedByUserId,
                        CreatedOn = quiz.CreatedOn,

                    })
                    .ToList()
            };

            return Ok(result);
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
