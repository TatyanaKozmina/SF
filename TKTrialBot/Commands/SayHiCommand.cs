namespace TKTrialBot.Commands
{
    public class SayHiCommand : AbstractCommand, IChatCommandReplyText
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
