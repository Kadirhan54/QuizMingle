using QuizMingle.Domain.Common;
using QuizMingle.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMingle.Domain.Entities
{
    public class Score : IEntityBase<Guid>
    {
        public User User { get; set; }

        public Quiz Quiz { get; set; }

        public double score { get; set; }
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset CreatedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime ModifiedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTimeOffset? IEntityBase<Guid>.DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTimeOffset IEntityBase<Guid>.CreatedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTimeOffset? IEntityBase<Guid>.ModifiedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
