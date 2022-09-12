namespace BlogAppAPI.Contracts.Tags.Responses
{
    public class GetTagResponse
    {
        public List<TagView> Tags { get; set; }
    }

    public class TagView
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
    }
}
