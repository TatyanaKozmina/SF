namespace TKTrialBot.Commands
{
    public class AddWordCommand : MultiQuestionCommand
    {
        public AddWordCommand()
        {
            CommandText = "/addword";
            CommandType = CommandType.Adding;
        }

        public override void InitSubquestions()
        {
            subQuestions = new List<SubQuestion>()
            {
                new SubQuestion("rusword", "Введите русское значение слова"),
                new SubQuestion("engword", "Введите английское значение слова"),
                new SubQuestion("theme", "Введите тематику"),
            };
        }
    }
}
