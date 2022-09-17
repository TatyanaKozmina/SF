namespace BlogAppAPI.Contracts.Users.Requests
{
    public class PutUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
