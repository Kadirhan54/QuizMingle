using System.Text.Json.Serialization;

namespace QuizMingle.API.Models.Quiz
{
    public class UserQuizRequestRandom
    {
        private Guid guid;

        public UserQuizRequestRandom(Guid userId, Guid guid)
        {
            UserId = userId;
            this.guid = guid;
        }

        public Guid UserId { get; set; }
        public Guid QuizId { get; set; }
    }
}