namespace TKTrialBot
{
    [Serializable]
    public class DictionaryItem
    {
        public string RusWord { get; set; }
        public string EngWord { get; set; }
        public string Theme { get; set; }

        public DictionaryItem() { }

        public DictionaryItem(string rusWord, string engWord, string theme)
        {
            RusWord = rusWord;
            EngWord = engWord;
            Theme = theme;
        }
    }
}
