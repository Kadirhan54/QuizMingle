using QuizMingle.Domain.Entities;

namespace QuizMingle.API.Models.User
{
    public class UpdateUserResponseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public string? ModifiedByUserId { get; set; }
    }
}
