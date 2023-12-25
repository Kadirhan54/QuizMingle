
using QuizMingle.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMingle.Domain.Entities
{
    public class Quiz : IEntityBase<Guid>
    {
        public int timeLimit {  get; set; }
        
        public DateTimeOffset startTime { get; set; }
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreatedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? ModifiedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTime IModifiedOn.ModifiedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTime IDeletedOn.DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
