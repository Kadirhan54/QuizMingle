using System.Text.Json.Serialization;

namespace QuizMingle.API.Models
{
    public class UserQuizRequest
    {
        private Guid guid;

		[JsonConstructor]
		public UserQuizRequest(string userId, Guid guid)
        {
            UserId = userId;
            this.guid = guid;
        }

        public string UserId { get; set; }
        public string QuizId { get; set; }
    }
}