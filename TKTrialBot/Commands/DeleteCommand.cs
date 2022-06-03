namespace TKTrialBot.Commands
{
    public class DeleteCommand : AbstractCommand, ICommandReplyText, ICommandParam
    {
        public DeleteCommand()
        {
            CommandText = "/deleteword";
            CommandType = CommandType.DeleteWord;
            Parameters = new List<string>();
        }

        public List<string> Parameters { get; set; }

        public string ReplyText()
        {
            return "Слово удалено из словаря";
        }
    }
}