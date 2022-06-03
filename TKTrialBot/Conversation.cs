using Telegram.Bot.Types;

namespace TKTrialBot
{
    class Conversation
    {
        private Chat telegramChat;

        private List<Message> telegramMessages;

        private List<DictionaryItem> chatDictionary;
        public string ChatDictionary { get { return GetDictionary(); }  }

        public Conversation(Chat chat)
        {
            telegramChat = chat;
            telegramMessages = new List<Message>();
            chatDictionary = DictionaryProcessor.LoadFromFile();
        }

        public void AddMessage(Message message)
        {
            telegramMessages.Add(message);
        }

        public long GetId() => telegramChat.Id;

        public string GetLastMessage() => telegramMessages.Last().Text;

        public void AddToDictionary(DictionaryItem item)
        {
            if (chatDictionary == null)
                chatDictionary = new List<DictionaryItem>();

            if(!chatDictionary.Exists(x => x.RusWord == item.RusWord))
                chatDictionary.Add(item);
        }

        public async Task SaveDictionaryToFile()
        {
            await DictionaryProcessor.SaveToFile(chatDictionary);
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
