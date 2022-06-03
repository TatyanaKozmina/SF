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
            chatCommands.Add(new SaveCommand());
            chatCommands.Add(new DeleteCommand());
            chatCommands.Add(new DictionaryCommand());
        }

        public static AbstractCommand SetCurrentCommand(string message)
        {
            string[] wordsInMessage = message.Trim().Split(" ");
            if (wordsInMessage.Length > 1)
            {
                var chatCommand = chatCommands.Where(r => r.CommandText.StartsWith(wordsInMessage[0], StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                var commandWithParam = chatCommand as ICommandParam;
                for (int i = 1; i < wordsInMessage.Length; i++)
                    commandWithParam.Parameters.Add(wordsInMessage[i]);
                return (commandWithParam as AbstractCommand);
            }
            else
                return chatCommands.Where(r => r.CommandText.StartsWith(message, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

        public static List<string> GetCommandParams(AbstractCommand command)
        {
            ICommandParam commandWithParam = command as ICommandParam;
            return commandWithParam.Parameters;
        }

        public static bool IsCommand(string message)
        {
            return chatCommands.Exists(r => r.CommandText.StartsWith(message.Split(" ")[0], StringComparison.OrdinalIgnoreCase));
        }

        public static string GetReplyText(AbstractCommand command)
        {
            return ((ICommandReplyText)command).ReplyText();
        }

        #region MultiQuestion          

        public static SubQuestion? GetQuestion(AbstractCommand command)
        {
            MultiQuestionCommand? mqcommand = command as MultiQuestionCommand;
            if (mqcommand != null)
            {
                var currentQuestion = mqcommand.Subquestions.Where(x => x.Processed == false).First();
                currentQuestion.Processed = true;

                return currentQuestion;
            }
            else
                return null;
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