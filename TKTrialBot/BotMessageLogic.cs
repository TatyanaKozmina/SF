using Telegram.Bot;
using Telegram.Bot.Args;

namespace TKTrialBot
{
    class BotMessageLogic
    {
        private Messenger messenger;
        private Dictionary<long, Conversation> chatList;

        public BotMessageLogic(ITelegramBotClient botClient)
        {
            messenger = new Messenger(botClient);
            chatList = new Dictionary<long, Conversation>();
            messenger.AddWordStarted += InitDictItem;
            messenger.WordEntered += FillDictItem;
        }

        public async Task Response(MessageEventArgs e)
        {
            var Id = e.Message.Chat.Id;

            if (!chatList.ContainsKey(Id))
            {
                var newchat = new Conversation(e.Message.Chat);

                chatList.Add(Id, newchat);
            }

            var chat = chatList[Id];

            chat.AddMessage(e.Message);

            await messenger.MakeAnswer(chat);
        }

        public void InitDictItem(Conversation chat)
        {
            chat.InitDictItem();
        }

        public void FillDictItem(Conversation chat, string key, string value)
        {
            chat.FillDictItem(key, value);
        }
    }
}
