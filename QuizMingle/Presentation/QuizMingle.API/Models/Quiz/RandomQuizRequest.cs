namespace QuizMingle.API.Models.Quiz
{
    public class RandomQuizRequest
    {
        public Guid UserId { get; set; }
        public int questionCount { get; set; }

        public int timeDuration { get; set; }


    }
}
