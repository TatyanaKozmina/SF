using Telegram.Bot;
using Telegram.Bot.Args;

namespace TKTrialBot
{
    public class BotWorker
    {
        private ITelegramBotClient botClient;
        private BotMessageLogic logic;

        public void Initialize()
        {
            botClient = new TelegramBotClient(BotCredentials.BotToken);
            logic = new BotMessageLogic(botClient);
        }

        public void Start()
        {
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
        }

        public void Stop()
        {
            botClient.StopReceiving();
        }

        private async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message != null)
            {
                await logic.Response(e);
            }
            //if (e.Message.Text != null)
            //{
            //    Console.WriteLine($"Получено сообщение в чате: {e.Message.Chat.Id}.");

            //    await botClient.SendTextMessageAsync(
            //    chatId: e.Message.Chat, text: "Вы написали:\n" + e.Message.Text);
            //}
        }
    }
}

