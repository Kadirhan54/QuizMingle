
using Microsoft.AspNetCore.Identity;
using QuizMingle.Domain.Common;
using QuizMingle.Domain.Entities;

namespace QuizMingle.Domain.Identity
{
    public class User : IdentityUser<Guid>, IEntityBase<Guid>, ICreatedByEntity, IModifiedByEntity
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
