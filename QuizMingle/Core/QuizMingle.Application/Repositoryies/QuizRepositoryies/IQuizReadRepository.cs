

using QuizMingle.Domain.Entities;

namespace QuizMingle.Application.Repositories.QuizRepositories
{
    public interface IQuizReadRepository : IReadRepository<Quiz, Guid>
    {
        Task<List<Quiz>> GetAllQuizzesAsync(CancellationToken cancellationToken);
        Task<Quiz> GetQuizByIdAsync(CancellationToken cancellationToken, Guid Id);

    }
}
