﻿

namespace QuizMingle.Domain.Common
{
    public abstract class EntityBase<TKey> : ICreatedOn, IModifiedOn, IDeletedOn
    {
        public TKey Id { get; set; }

        public string CreatedByUserId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public string? ModifiedByUserId { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public string? DeletedByUserId { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }

        public bool Equals(TKey? other)
        {
            throw new NotImplementedException();
        }
    }
}