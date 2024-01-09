

using Microsoft.EntityFrameworkCore;
using QuizMingle.Domain.Entities;
using QuizMingle.Persistence.Context;

namespace QuizMingle.Application.Repositories.QuizRepositories
{
    public class QuizReadRepository : ReadRepository<Quiz, Guid>, IQuizReadRepository
    {
        public QuizReadRepository(QuizMingleDbContext context) : base(context) { }

        public async Task<List<Quiz>> GetAllQuizzesAsync(CancellationToken cancellationToken)
        {
            return await Table.ToListAsync(cancellationToken);
        }

        public async Task<Quiz> GetQuizByIdAsync(CancellationToken cancellationToken, Guid Id)
        {
            return await Table.Where(q => q.Id == Id).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
