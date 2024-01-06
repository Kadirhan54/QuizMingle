using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace QuizMingle.API.Models.Quiz
{
    public class BestScoreRequest
    {
        [Required(ErrorMessage = "quizId is required.")]
        public string QuizId { get; set; }

        public int ScoreRequestCount { get; set; }
        public DateTimeOffset StartTime {  get; set; }
        public DateTimeOffset TimeLimit { get; set;}
	}
}
