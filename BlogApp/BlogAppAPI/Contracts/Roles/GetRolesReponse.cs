namespace BlogAppAPI.Contracts.Roles
{
    public class GetAuthorsReponse
    {
        public List<RoleView> Roles { get; set; }
    }

    public class RoleView
    {
        public string Name { get; set; }
    }
}
