using QuizMingle.Domain.Common;
using QuizMingle.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMingle.Domain.Entities
{
    public class UserQuiz : IEntityBase<Guid>
    {
        public User User { get; set; }

        public string name { get; set; }

        public Quiz Quiz { get; set; }
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreatedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? ModifiedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTime IModifiedOn.ModifiedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTimeOffset? IEntityBase<Guid>.ModifiedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTimeOffset IEntityBase<Guid>.CreatedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTimeOffset ICreatedOn.CreatedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTimeOffset? IEntityBase<Guid>.DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTimeOffset IDeletedOn.DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
