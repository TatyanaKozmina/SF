using Telegram.Bot;
using Telegram.Bot.Args;

namespace TKTrialBot
{
    class BotMessageLogic
    {
        private Messenger messenger;
        private Dictionary<long, Conversation> chatList;
        private ITelegramBotClient botClient;

        public BotMessageLogic(ITelegramBotClient botClient)
        {
            messenger = new Messenger();
            chatList = new Dictionary<long, Conversation>();
            this.botClient = botClient;
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

            await SendTextMessage(chat);
        }

        private async Task SendTextMessage(Conversation chat)
        {
            var text = messenger.CreateTextMessage(chat);

            await botClient.SendTextMessageAsync(chatId: chat.GetId(), text: text);
        }
    }
}
