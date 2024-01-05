using QuizMingle.Domain.Entities;

namespace QuizMingle.API.Models.Quiz
{
    public class RandomQuizResponse
    {
        public List<Question> Questions { get; set; }
        public int TimeLimitInSeconds { get; set; }
    }
}
