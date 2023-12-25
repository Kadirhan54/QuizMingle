
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMingle.Domain.Common
{
    public interface IEntityBase<Tkey> : ICreatedOn, IModifiedOn, IDeletedOn
    {
        public Tkey Id { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset? ModifiedOn { get; set; }

        public DateTimeOffset? DeletedOn { get; set; }
    }
}
