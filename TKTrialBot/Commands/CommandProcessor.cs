namespace TKTrialBot.Commands
{
    public static class CommandProcessor
    {
        private static List<AbstractCommand> chatCommands;

        static CommandProcessor()
        {
            chatCommands = new List<AbstractCommand>();
            chatCommands.Add(new SayHiCommand());
            chatCommands.Add(new AddWordCommand());
        }        

        public static AbstractCommand SetCurrentCommand(string message)
        {
            return chatCommands.Where(r => r.CommandText.Equals(message, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

        public static bool IsCommand(string message)
        {
            return chatCommands.Where(r => r.CommandText.Equals(message, StringComparison.OrdinalIgnoreCase)).Any();
        }            

        public static string GetReplyText(AbstractCommand command)
        {
            return ((IChatCommandReplyText)command).ReplyText();
        }

        #region MultiQuestion       

        public static void InitSubquestions(AbstractCommand command)
        {
            MultiQuestionCommand? mqcommand = command as MultiQuestionCommand;
            if (mqcommand != null)
                mqcommand.InitSubquestions();            
        }

        public static string GetQuestion(AbstractCommand command)
        {
            MultiQuestionCommand? mqcommand = command as MultiQuestionCommand;
            if (mqcommand != null)
            {
                var currentQuestion = mqcommand.Subquestions.Where(x => x.Processed == false).First();
                var text = currentQuestion.Question;
                currentQuestion.Processed = true;

                return currentQuestion.Question;
            }
            else
                return string.Empty;
        }

        public static bool NoMoreQuestions(AbstractCommand command)
        {
            MultiQuestionCommand? mqcommand = command as MultiQuestionCommand;
            if (mqcommand != null && (!mqcommand.Subquestions.Exists(x => x.Processed == false)))
                return true;
            else
                return false;
        }
        #endregion
    }
}
