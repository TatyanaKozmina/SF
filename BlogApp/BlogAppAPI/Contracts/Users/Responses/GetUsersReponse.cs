﻿namespace BlogAppAPI.Contracts.Users.Responses
{
    public class GetUsersReponse
    {
        public List<UserView> Users { get; set; }
    }

    public class UserView
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
