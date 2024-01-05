namespace QuizMingle.API.Models
{
    public class UserQuizRequest
    {
        private Guid guid;

        public UserQuizRequest(Guid userId, Guid guid)
        {
            UserId = userId;
            this.guid = guid;
        }

        public Guid UserId { get; set; }
        public Guid QuizId { get; set; }
    }
}