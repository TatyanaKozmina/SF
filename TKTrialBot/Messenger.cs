using Telegram.Bot;
using TKTrialBot.Commands;

namespace TKTrialBot
{
    class Messenger
    {
        private ITelegramBotClient botClient;

        private bool multiQuestionInProcess;
        private AbstractCommand? currentCommand;
        private SubQuestion? currentQuestion;

        public delegate void WordEnteredHandler(Conversation chat, string key, string value);
        public event WordEnteredHandler WordEntered;

        public delegate void AddWordStartedHandler(Conversation chat);
        public event AddWordStartedHandler AddWordStarted;

        public Messenger(ITelegramBotClient botClient)
        {
            this.botClient = botClient;
        }

        public async Task MakeAnswer(Conversation chat)
        {
            var lastmessage = chat.GetLastMessage();

            if (CommandProcessor.IsCommand(lastmessage))
            {
                /// Пользователь ввёл команду - /nnnn
                currentCommand = CommandProcessor.SetCurrentCommand(lastmessage);
                await ExecCommand(chat, currentCommand);
            }
            else
            {
                if (multiQuestionInProcess)
                {
                    if (currentCommand.CommandType == CommandType.AddWord)
                    {
                        WordEntered?.Invoke(chat, currentQuestion.Key, lastmessage);
                    }

                    if (CommandProcessor.NoMoreQuestions(currentCommand))
                    {
                        multiQuestionInProcess = false;
                    }
                    else
                    {
                        currentQuestion = CommandProcessor.GetQuestion(currentCommand);
                        await SendText(chat, currentQuestion.Question);
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

                case CommandType.AddWord:
                    multiQuestionInProcess = true;
                    AddWordStarted?.Invoke(chat);
                    currentQuestion = CommandProcessor.GetQuestion(command);
                    await SendText(chat, currentQuestion.Question);
                    break;

                case CommandType.Save:
                    await chat.SaveDictionaryToFile();
                    text = CommandProcessor.GetReplyText(command);
                    await SendText(chat, text);
                    break;

                case CommandType.DeleteWord:
                    chat.DeleteFromDictionary(CommandProcessor.GetCommandParams(command).First());
                    text = CommandProcessor.GetReplyText(command);
                    await SendText(chat, text);
                    break;

                case CommandType.Dictionary:
                    await SendText(chat, chat.ChatDictionary);
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
