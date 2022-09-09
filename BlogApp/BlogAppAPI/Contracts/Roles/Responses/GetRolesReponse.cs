namespace BlogAppAPI.Contracts.Roles.Responses
{
    public class GetRolesResponse
    {
        public List<RoleView> Roles { get; set; }
    }

    public class RoleView
    {
        public string Name { get; set; }
    }
}
