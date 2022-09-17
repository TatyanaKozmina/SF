namespace BlogAppAPI.Contracts.Roles.Responses
{
    public class GetRolesResponse
    {
        public List<RoleView> Roles { get; set; }
    }

    public class RoleView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
