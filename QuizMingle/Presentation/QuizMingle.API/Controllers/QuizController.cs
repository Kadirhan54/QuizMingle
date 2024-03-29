using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizMingle.API.Models;
using FluentValidation;
using FluentValidation.Results;
using QuizMingle.API.Validators;
using QuizMingle.Domain.Entities;
using QuizMingle.Domain.Identity;
using QuizMingle.Persistence.Context;
using System.Security.Claims;
using Microsoft.Extensions.Caching.Memory;
using QuizMingle.API.Models.Quiz;
using QuizMingle.API.Services;
using QuizMingle.Application.Features.Queries.GetAllQuiz;
using QuizMingle.Application.Features.Queries.GetQuizById;

namespace QuizMingle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuizController : ControllerBase
    {

        private readonly QuizMingleDbContext _context;
        readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _cacheEntryOptions;
        private readonly QuizCreateCounter _quizCreateCounter;
        private const string CacheKey = "quizKey";
		public QuizController(QuizMingleDbContext context, IMediator mediator,IMemoryCache memoryCache, QuizCreateCounter quizCreateCounter)
        {
            _context = context;
            _mediator = mediator;
            _memoryCache = memoryCache;
            _quizCreateCounter = quizCreateCounter;
            _cacheEntryOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(30),
                Priority = CacheItemPriority.High,
            };
        }

        [HttpPost]
        [Route("CreateQuiz")]
        public async Task<IActionResult> CreateQuiz([FromBody] QuizCreateRequest quizRequest)
        {

            QuizCreateRequestValidator validator = new QuizCreateRequestValidator();

            ValidationResult results = validator.Validate(quizRequest);

            if (!results.IsValid)
            {
                //foreach (var failure in results.Errors)
                //{
                //    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                //}

                return BadRequest(results);

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

            QuestionCreateReqauestValidator validator = new QuestionCreateReqauestValidator();

            ValidationResult results = validator.Validate(questionRequest);

            if (!results.IsValid)
            {
                //foreach (var failure in results.Errors)
                //{
                //    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                //}

                return BadRequest(results);

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

            return Ok(new { Message = "Soru başarıyla eklendi", QuestionId = question.Id, Quiz = question.QuizId });
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
            //request sayısını sayıyor.
            //var _quizCreateCounter = new QuizCreateCounter(); //bunu yorum satırına alınca çalıştı ıdk why.
            _quizCreateCounter.count +=1;

			return Ok(new { Name = userName, Id = userId, Count= _quizCreateCounter.count });
            //buraya kadarki kısım request sayısını saymak için.
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
            var userQuizExists = _context.UserQuizzes.Any(x => x.UserId == userId && x.QuizId == answerRequest.QuizId);
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
        public async Task<IActionResult> AddUserQuiz([FromBody] UserQuizRequestModel userQuizRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userQuizExists = _context.UserQuizzes.Any(x => x.UserId == userQuizRequest.UserId && x.QuizId == userQuizRequest.QuizId);

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


        [HttpPost]
        [Route("AddUserQuizScore")]
        public async Task<IActionResult> AddUserQuizScore([FromBody] ScoreRequest scoreRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!Guid.TryParse(userIdString, out Guid userId))
            {
                return BadRequest("Geçersiz kullanıcı ID'si.");
            }

            var userQuizAnswers = _context.UserQuizAnswers
                .Where(x => x.UserId == userId && x.QuizId == scoreRequest.QuizId)
                .Include(x => x.Question)
                .ToList();

            if (!userQuizAnswers.Any())
            {
                return BadRequest("Bu quiz için cevaplar bulunamadı.");
            }

            int score = userQuizAnswers.Count(x => x.GivenAnswer == x.Question.CorrectAnswer);
            var totalQuestions = await _context.Questions.CountAsync(x => x.QuizId == scoreRequest.QuizId);

            var userQuizScore = new Score
            {
                UserId = userId,
                QuizId = scoreRequest.QuizId,
                ScoreValue = score,
                DateTaken = DateTimeOffset.UtcNow,
                CreatedByUserId = "halaymaster"
            };

            _context.Scores.Add(userQuizScore);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Skor başarıyla eklendi", Score = score, TotalQuestions = totalQuestions });
        }

        // GET: api/Quiz/GetQuizById
        [HttpGet]
        [Route("GetQuizById")]
        public async Task<ActionResult<GetQuizByIdResponse>> GetQuizById([FromQuery] Guid id)
        {
            var request = new GetQuizByIdQuery { Id = id };
            GetQuizByIdResponse response = await _mediator.Send(request);
            return Ok(response);
        }


        // GET: api/Quiz/GetQuizzes
        [HttpGet]
        [Route("GetQuizzes")]
        public async Task<ActionResult<IEnumerable<QuizResponseModel>>> GetQuizzes(CancellationToken cancellationToken)
        {
            if (_memoryCache.TryGetValue(CacheKey, out var quizzes)) { return Ok(quizzes); }

            quizzes = await _context.Quizzes.AsNoTracking().ToListAsync(cancellationToken);

            _memoryCache.Set(CacheKey, quizzes, _cacheEntryOptions);

            return Ok(quizzes);
        }


        //delete kısmını ekliyorum
        [HttpDelete("{id}")]
        //[Route("QuizDeleteRequest")] //bunu yorum satırına alınca çalıştı neden bilmiyorum :)
        public IActionResult QuizDelete(Guid id)
        {
            var quizToDelete = _context.Quizzes.Find(id);

        	if (quizToDelete == null)
        	{
        		return NotFound("geçersiz id girdin abla az dikkatli ol"); // ıd bulunamazsa 404 vercek.
        	}

        	_context.Quizzes.Remove(quizToDelete);
        	_context.SaveChanges();

        // Invalidate the cache since the data has been modified
        	_memoryCache.Remove(CacheKey); 

        	return NoContent();
        }
        //buraya kadar delete kısmı


        //farklı bir şekilde delete yapmaya çalışıyorum.

  //      [Route("QuizDeleteRequest")]
  //      public class QuizController : ControllerBase
  //      {
		//	[HttpDelete("{id}")]
  //          public List<Quiz>
		//}




        //buraya kadar ikinci yöntem işte


        
		[HttpPost]
        [Route("UpdateQuiz")]
        public async Task<IActionResult> UpdateQuiz([FromBody] QuizUpdateRequest quizRequest)
        {
            // Model doğrulaması
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quiz = await _context.Quizzes.FindAsync(quizRequest.QuizId);
            if (quiz == null)
            {
                return NotFound("Quiz bulunamadı.");
            }

            quiz.StartTime = quizRequest.StartTime;
            quiz.TimeLimit = quizRequest.TimeLimit;

            _context.Quizzes.Update(quiz);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Quiz başarıyla güncellendi", QuizId = quiz.Id });
        }

        //CQRS ile GetAllQuiz sorgusu
        [HttpGet]
        [Route("GetAllQuiz")]
        public async Task<IActionResult> GetAllQuiz([FromQuery] GetAllQuizQueryRequest getAllQuizQueryRequest) {

        GetAllQuizQueryResponse response = await _mediator.Send(getAllQuizQueryRequest);
        return Ok(response);

        }

      

        [HttpPost]
        [Route("GetBestScoreInQuiz")]
        public async Task<IActionResult> GetBestScoreInQuiz([FromBody] BestScoreRequest bestScoreRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Guid quizId = Guid.Parse(bestScoreRequest.QuizId);

                var bestScores = _context.Scores
                    .Where(score => score.QuizId == quizId)
                    .OrderByDescending(score => score.ScoreValue)
                    .Take(bestScoreRequest.ScoreRequestCount) // Assuming you want to get the top 10 scores
                    .ToList();

                return Ok(bestScores);
            }
            catch (FormatException)
            {
                return BadRequest("Invalid QuizId format.");
            }
        }



    }

}
