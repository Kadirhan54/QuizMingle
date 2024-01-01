using QuizMingle.Domain.Entities;

namespace QuizMingle.API.Models
{
    public class QuestionCreateRequest
    {
        public string Text { get; set; }

        public string CorrectAnswer { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }

        public Guid QuizId { get; set; }
      
    }
}