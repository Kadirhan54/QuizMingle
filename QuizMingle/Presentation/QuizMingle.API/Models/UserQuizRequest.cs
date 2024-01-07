using System.Text.Json.Serialization;

namespace QuizMingle.API.Models
{
    public class UserQuizRequest
    {
        private Guid guid;
        public Guid UserId { get; set; }
        public Guid QuizId { get; set; }

        public UserQuizRequest(Guid userId, Guid guid)
        {
            this.UserId = userId;
            this.guid = guid;
        }

    }
}