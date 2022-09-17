namespace BlogAppAPI.Contracts.Users.Requests
{
    public class PutUserRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
    }
}
