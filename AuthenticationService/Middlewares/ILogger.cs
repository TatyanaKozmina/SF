namespace AuthenticationService.Middlewares
{
    public interface ILogger
    {
        void WriteEvent(string message);
        void WriteError(string message);
    }
}
