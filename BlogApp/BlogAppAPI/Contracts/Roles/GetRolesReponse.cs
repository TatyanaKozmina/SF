namespace BlogAppAPI.Contracts.Roles
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
