namespace TKTrialBot.Commands
{
    public class SaveCommand : AbstractCommand, ICommandReplyText
    {
        public SaveCommand()
        {
            CommandText = "/savetofile";
            CommandType = CommandType.Save;
        }
        public string ReplyText()
        {
            return "Словарь сохранён";
        }
    }
}