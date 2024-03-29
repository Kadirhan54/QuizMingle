﻿using QuizMingle.Domain.Common;
using QuizMingle.Domain.Identity;


namespace QuizMingle.Domain.Entities
{
    public class UserQuiz : ICreatedByEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; }

        // UserQuizAnswers ile ilişki
        public ICollection<UserQuizAnswer> UserQuizAnswers { get; set; }

        public string CreatedByUserId{ get; set; }
        public DateTimeOffset CreatedOn{ get; set; }
    }
}
