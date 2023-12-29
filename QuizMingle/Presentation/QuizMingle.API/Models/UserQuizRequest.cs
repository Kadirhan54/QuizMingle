namespace QuizMingle.API.Models
{
    public class UserQuizRequest
    {
        public Guid UserId { get; set; }
        public Guid QuizId { get; set; }
    }
}