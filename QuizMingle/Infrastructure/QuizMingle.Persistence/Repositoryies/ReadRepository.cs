

using Microsoft.EntityFrameworkCore;
using QuizMingle.Domain.Common;
using QuizMingle.Persistence.Context;

namespace QuizMingle.Application.Repositories
{
    public class ReadRepository<T, TId> : IReadRepository<T, TId> where T : EntityBase<TId>
    {
        private readonly QuizMingleDbContext _context;

        public ReadRepository(QuizMingleDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public List<T> GetAll()
        {
            return Table.ToList();
        }

        public T GetById(TId id)
        {
            return Table.FirstOrDefault(x => x.Id.ToString() == id.ToString());
        }
    }
}
