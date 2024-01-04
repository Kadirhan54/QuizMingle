

using Microsoft.EntityFrameworkCore;
using QuizMingle.Domain.Common;
using QuizMingle.Persistence.Context;

namespace QuizMingle.Application.Repositories
{
    public class WriteRepository<T, TId> : IWriteRepository<T, TId> where T : EntityBase<TId>
    {
        private readonly QuizMingleDbContext _context;

        public WriteRepository(QuizMingleDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public void Add(T entity)
        {
            Table.Add(entity);
        }

        public void Delete(TId id)
        {
            Table.Remove(Table.FirstOrDefault(x => Guid.Parse(x.Id.ToString()) == Guid.Parse(id.ToString())));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
