using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using TKTrialBot.Commands;

namespace TKTrialBot
{
    class Messenger
    {
        private ITelegramBotClient botClient;

        private bool multiQuestionInProcess;
        private AbstractCommand currentCommand;

        public Messenger(ITelegramBotClient botClient)
        {
            this.botClient = botClient;
        }

        public async Task MakeAnswer(Conversation chat)
        {
            var lastmessage = chat.GetLastMessage();

            if (CommandProcessor.IsCommand(lastmessage))
            {
                currentCommand = CommandProcessor.SetCurrentCommand(lastmessage);
                await ExecCommand(chat, currentCommand);
            }
            else
            {
                if (multiQuestionInProcess)
                {
                    if (CommandProcessor.NoMoreQuestions(currentCommand))
                        multiQuestionInProcess = false;
                    else
                    {
                        var text = CommandProcessor.GetQuestion(currentCommand);
                        await SendText(chat, text);
                    }
                }
            }
        }

        private async Task ExecCommand(Conversation chat, AbstractCommand command)
        {
            switch (command.CommandType)
            {
                case CommandType.Text:
                    var text = CommandProcessor.GetReplyText(command);
                    await SendText(chat, text);
                    break;

                case CommandType.Adding:
                    multiQuestionInProcess = true;
                    CommandProcessor.InitSubquestions(command);
                    text = CommandProcessor.GetQuestion(command);
                    await SendText(chat, text);
                    break;

                case CommandType.Button:
                    //    var keys = parser.GetKeyBoard(command);
                    //    var text = parser.GetInformationalMeggase(command);
                    //    parser.AddCallback(command, chat);

                    //    await SendTextWithKeyBoard(chat, text, keys);
                    break;
            }
        }

        private async Task SendText(Conversation chat, string text)
        {
            await botClient.SendTextMessageAsync(
                  chatId: chat.GetId(),
                  text: text
                );
        }

        //private async Task SendTextWithKeyBoard(Conversation chat, string text, InlineKeyboardMarkup keyboard)
        //{
        //    await botClient.SendTextMessageAsync(
        //          chatId: chat.GetId(),
        //          text: text,
        //          replyMarkup: keyboard
        //        );
        //}        
    }
}
