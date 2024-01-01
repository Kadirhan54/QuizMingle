namespace QuizMingle.API.Models
{
    public class ScoreRequest
    {
        public Guid QuizId { get; set; }
        public Guid UserId { get; set; }
    }
}