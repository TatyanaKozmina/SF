namespace TKTrialBot.Commands
{
    public class AddWordCommand : MultiQuestionCommand, ICommandReplyText
    {
        private DictionaryItem dictionaryItem;
        public AddWordCommand()
        {
            CommandText = "/addword";
            CommandType = CommandType.AddWord;
        }

        public override void InitCommand()
        {
            subQuestions = new List<SubQuestion>()
            {
                new SubQuestion("rusword", "Введите русское значение слова"),
                new SubQuestion("engword", "Введите английское значение слова"),
                new SubQuestion("theme", "Введите тематику"),
            };
            dictionaryItem = new DictionaryItem();
        }

        public void FillDictionaryItemField(string key, string value)
        {
            switch(key)
            {
                case "rusword":
                    dictionaryItem.RusWord = value;
                    break;
                case "engword":
                    dictionaryItem.EngWord = value;
                    break;
                case "theme":
                    dictionaryItem.Theme = value;
                    break;
            }
        }

        public DictionaryItem GetDictionaryItem()
        {
            return dictionaryItem;
        }

        public string ReplyText()
        {
            return $"Успешно! Слово {dictionaryItem.EngWord} добавлено в словарь.";
        }
    }
}
