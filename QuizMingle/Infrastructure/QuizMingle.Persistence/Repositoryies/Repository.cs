

using Microsoft.EntityFrameworkCore;
using QuizMingle.Domain.Common;

namespace QuizMingle.Application.Repositories
{
    public interface Repository<T, TId> where T : EntityBase<TId>
    {
        DbSet<T> Table { get; }
    }
}
