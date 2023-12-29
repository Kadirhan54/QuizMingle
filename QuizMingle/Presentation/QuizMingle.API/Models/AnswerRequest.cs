namespace QuizMingle.API.Models
{
    public class AnswerRequest
    {
        public string GivenAnswer { get; set; }
        public Guid QuizId { get; set; }
        public Guid QuestionId { get; set; }
        
    }
}