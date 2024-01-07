using QuizMingle.Domain.Entities;

namespace QuizMingle.API.Models
{
    public class UserResponseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<UserQuiz> UserQuizzes { get; set; }

        public string CreatedByUserId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public string? ModifiedByUserId { get; set; }
    }
}
