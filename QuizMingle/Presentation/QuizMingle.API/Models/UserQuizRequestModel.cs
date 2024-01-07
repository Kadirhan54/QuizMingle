namespace QuizMingle.API.Models
{
    public class UserQuizRequestModel
    {
        public Guid UserId { get; set; }
        public Guid QuizId { get; set; }
    }
}
