using QuizMingle.Persistence.Context;

namespace QuizMingle.API.Services
{
	public class QuizCreateCounter1 : IQuizCreateCounter1
	{
		private readonly QuizMingleDbContext _quizMingleDbContext;

		public QuizCreateCounter1(QuizMingleDbContext quizMingleDbContext)
        {
			_quizMingleDbContext = quizMingleDbContext;

		}

		public int getCount()
		{
			return _quizMingleDbContext.Quizzes.Count();
		}
	}
}
