namespace TKTrialBot.Commands
{
    internal class DictionaryCommand : AbstractCommand
    {
        public DictionaryCommand()
        {
            CommandText = "/dictionary";
            CommandType = CommandType.Dictionary;
        }
    }
}
