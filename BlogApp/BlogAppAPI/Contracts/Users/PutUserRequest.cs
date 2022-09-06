namespace BlogAppAPI.Contracts.Users
{
    public class PutUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
