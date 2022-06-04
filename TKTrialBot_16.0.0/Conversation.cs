using Telegram.Bot.Types;

namespace TKTrialBot
{
    class Conversation
    {
        private Chat telegramChat;

        private List<Message> telegramMessages;

        private List<DictionaryItem> chatDictionary;
        public string ChatDictionary { get { return GetDictionary(); } }

        public Conversation(Chat chat)
        {
            telegramChat = chat;
            telegramMessages = new List<Message>();
            chatDictionary = DictionaryFileProcessor.LoadFromFile();
        }

        public void AddMessage(Message message)
        {
            telegramMessages.Add(message);
        }

        public long GetId() => telegramChat.Id;

        public string GetLastMessage() => telegramMessages.Last().Text;

        public void InitDictItem()
        {
            if (chatDictionary == null)
                chatDictionary = new List<DictionaryItem>();
            chatDictionary.Add(new DictionaryItem());
        }

        public void FillDictItem(string key, string value)
        {
            switch (key.ToUpper())
            {
                case "RUSWORD":
                    chatDictionary.Where(x => x.RusWord == null).Last().RusWord = value;
                    break;
                case "ENGWORD":
                    chatDictionary.Where(x => x.EngWord == null).Last().EngWord = value;
                    break;
                case "THEME":
                    chatDictionary.Where(x => x.Theme == null).Last().Theme = value;
                    break;
            }
        }

        public async Task SaveDictionaryToFile()
        {
            await DictionaryFileProcessor.SaveToFile(chatDictionary);
        }

        public void DeleteFromDictionary(string rusword)
        {
            if (chatDictionary != null)
                chatDictionary.Remove(chatDictionary.First(x => x.RusWord == rusword));
        }

        private string GetDictionary()
        {
            string result = string.Empty;

            foreach (var wordItem in chatDictionary)
            {
                result = result +
                         string.Format("{0} {1} {2}", wordItem.RusWord, wordItem.EngWord, wordItem.Theme) +
                         "\n";
            }

            return result;
        }
    }
}
