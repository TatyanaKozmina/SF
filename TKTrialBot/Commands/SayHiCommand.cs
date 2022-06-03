namespace TKTrialBot.Commands
{
    public class SayHiCommand : AbstractCommand, ICommandReplyText
    {
        public SayHiCommand()
        {
            CommandText = "/saymehi";
            CommandType = CommandType.Text;
        }
        public string ReplyText()
        {
            return "Привет";
        }
    }
}
