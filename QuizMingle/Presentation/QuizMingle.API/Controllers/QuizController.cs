using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizMingle.API.Models;
using QuizMingle.Domain.Entities;
using QuizMingle.Domain.Identity;
using QuizMingle.Persistence.Context;
using System.Security.Claims;

namespace QuizMingle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly QuizMingleDbContext _context;

        public QuizController(QuizMingleDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        [HttpPost]
        [Route("CreateQuiz")]
        public async Task<IActionResult> CreateQuiz([FromBody] QuizCreateRequest quizRequest)
        {
            // Model doğrulaması
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Quiz nesnesi oluşturma
            var quiz = new Quiz
            {
                StartTime = quizRequest.StartTime,
                TimeLimit = quizRequest.TimeLimit,
                Questions = new List<Question>(), // Sorular için boş liste oluştur
                UserQuizzes = new List<UserQuiz>(), // UserQuizzes için boş liste oluştur
                CreatedByUserId = "halaymaster"
            };

            _context.Quizzes.Add(quiz);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Quiz başarıyla oluşturuldu", QuizId = quiz.Id });
        }

        [HttpPost]
        [Route("AddQuestion")]
        public async Task<IActionResult> AddQuestion([FromBody] QuestionCreateRequest questionRequest)
        {
            // Model doğrulaması
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var selectedQuiz = _context.Quizzes.Include(q => q.Questions)
                          .FirstOrDefault(q => q.Id == questionRequest.QuizId);

            if (selectedQuiz == null)
            {
                return NotFound("Quiz bulunamadı.");
            }


            // Soru nesnesi oluşturma
            var question = new Question
            {
                Text = questionRequest.Text,
                CorrectAnswer = questionRequest.CorrectAnswer,
                OptionA = questionRequest.OptionA,
                OptionB = questionRequest.OptionB,
                OptionC = questionRequest.OptionC,
                OptionD = questionRequest.OptionD,
                QuizId = questionRequest.QuizId, // Quiz ile ilişkilendir
                CreatedByUserId = "halaymaster"
            };


            selectedQuiz.Questions.Add(question); //secili quize soru eklemek
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Soru başarıyla eklendi", QuestionId = question.Id });
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
