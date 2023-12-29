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
      
        private readonly QuizMingleDbContext _context;

        public QuizController(QuizMingleDbContext context)
        {
            _context = context;
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

            return Ok(new { Message = "Soru başarıyla eklendi", QuestionId = question.Id , Quiz =question.QuizId });
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
        [Route("CreateAnswer")]
        public async Task<IActionResult> CreateAnswer([FromBody] AnswerRequest answerRequest)
        {
            // Model doğrulaması
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // UserId doğrulaması
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!Guid.TryParse(userIdString, out Guid userId))
            {
                return BadRequest("Geçersiz kullanıcı ID'si.");
            }

            // User ve Quiz varlıklarının kontrolü
            var selectedUser = await _context.Users.FindAsync(userId);
            if (selectedUser is null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            var selectedQuiz = await _context.Quizzes.FindAsync(answerRequest.QuizId);
            if (selectedQuiz is null)
            {
                return NotFound("Quiz bulunamadı.");
            }

            // UserQuizExists kontrolü
            var userQuizExists = _context.UserQuizzes.Any(uq => uq.UserId == userId && uq.QuizId == answerRequest.QuizId);
            if (!userQuizExists)
            {
                return BadRequest("Belirtilen kullanıcı quiz için kayıt bulunamadı (önce AddUserQuiz adımı).");
            }

            // UserQuizAnswer nesnesi oluşturma
            var answer = new UserQuizAnswer
            {
                GivenAnswer = answerRequest.GivenAnswer,
                QuestionId = answerRequest.QuestionId,
                UserId = userId,
                QuizId = answerRequest.QuizId,
                CreatedByUserId = "halaymaster"
            };

            _context.UserQuizAnswers.Add(answer);
            await _context.SaveChangesAsync();


            return Ok(new { Message = "Cevap başarıyla oluşturuldu." });
        }





        [HttpPost]
        [Route("AddUserQuiz")]
        public async Task<IActionResult> AddUserQuiz([FromBody] UserQuizRequest userQuizRequest)
        {
            var userQuizExists = _context.UserQuizzes.Any(uq => uq.UserId == userQuizRequest.UserId && uq.QuizId == userQuizRequest.QuizId);
            
            if (!userQuizExists)
            {
                var userQuiz = new UserQuiz
                {
                    UserId = userQuizRequest.UserId,
                    QuizId = userQuizRequest.QuizId,
                    CreatedByUserId = "halaymaster"
                };

                User selectedUser = _context.Users.FirstOrDefault(x => x.Id == userQuizRequest.UserId);
                if (selectedUser == null)
                {
                    return NotFound("Kullanıcı bulunamadı.");
                }

                if (selectedUser.UserQuizzes == null)
                {
                    selectedUser.UserQuizzes = new List<UserQuiz>();
                }

                selectedUser.UserQuizzes.Add(userQuiz);
                _context.Users.Update(selectedUser);
                _context.UserQuizzes.Add(userQuiz);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Kullanıcı quiz kaydı başarıyla eklendi." });
            }

            return BadRequest("Belirtilen kullanıcı ve quiz için kayıt zaten mevcut.");
        }


    }
}
