using QuizMingle.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMingle.Domain.Entities
{
    public class Question : IEntityBase<Guid>
    {

        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreatedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? ModifiedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTime IModifiedOn.ModifiedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Quiz Quiz { get; set; }

        public string text { get; set; }

        public string optionA { get; set; }
        public string optionB { get; set; }
        public string optionC { get; set; }
        public string optionD { get; set; }
        DateTimeOffset IEntityBase<Guid>.CreatedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTimeOffset? IEntityBase<Guid>.ModifiedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTimeOffset? IEntityBase<Guid>.DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTimeOffset ICreatedOn.CreatedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTimeOffset IDeletedOn.DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
