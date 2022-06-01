namespace TKTrialBot.Commands
{
    public abstract class AbstractCommand
    {
        public string CommandText;
        public CommandType CommandType;
    }

    public enum CommandType
    {
        Text,
        Button,
        Adding
    }
}
