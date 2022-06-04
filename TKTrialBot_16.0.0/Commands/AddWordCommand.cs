namespace TKTrialBot.Commands
{
    public class AddWordCommand : MultiQuestionCommand, ICommandReplyText
    {
        public AddWordCommand()
        {
            CommandText = "/addword";
            CommandType = CommandType.AddWord;
            subQuestions = new List<SubQuestion>()
            {
                new SubQuestion("rusword", "Введите русское значение слова"),
                new SubQuestion("engword", "Введите английское значение слова"),
                new SubQuestion("theme", "Введите тематику"),
            };
        }

        public string ReplyText()
        {
            return $"Успешно! Слово добавлено в словарь.";
        }
    }
}
