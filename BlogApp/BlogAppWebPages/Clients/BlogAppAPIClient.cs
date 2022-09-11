namespace BlogAppWebPages.Clients
{
    public class BlogAppAPIClient
    {
        private static HttpClient client;
        private const string apiUrl = "https://localhost:7049/";

        public static HttpClient getInstance()
        {
            if (client == null)
                client = new HttpClient() { BaseAddress = new Uri(apiUrl) };
            return client;            
        }
    }
}
