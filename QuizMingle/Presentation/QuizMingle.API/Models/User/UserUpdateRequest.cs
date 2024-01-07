namespace QuizMingle.API.Models.User
{
    public class UserUpdateRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
    }
}
