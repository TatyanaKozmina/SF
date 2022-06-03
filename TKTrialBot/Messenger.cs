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
                if (multiQuestionInProcess)
                {
                    await SendText(chat, "Предыдущая задача не завершена.");
                    await SendText(chat, currentQuestion.Question);
                }
                else
                {
                    currentCommand = CommandProcessor.SetCurrentCommand(lastmessage);
                    await ExecCommand(chat);
                }                
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
                        await SendText(chat, CommandProcessor.GetReplyText(currentCommand));
                    }
                    else
                    {
                        currentQuestion = CommandProcessor.GetQuestion(currentCommand);
                        await SendText(chat, currentQuestion.Question);
                    }
                }
            }
        }

        private async Task ExecCommand(Conversation chat)
        {
            switch (currentCommand.CommandType)
            {
                case CommandType.Text:
                    await SendText(chat, CommandProcessor.GetReplyText(currentCommand));
                    break;

                case CommandType.AddWord:
                    multiQuestionInProcess = true;
                    AddWordStarted?.Invoke(chat);
                    currentQuestion = CommandProcessor.GetQuestion(currentCommand);
                    await SendText(chat, currentQuestion.Question);
                    break;

                case CommandType.Save:
                    await chat.SaveDictionaryToFile();
                    await SendText(chat, CommandProcessor.GetReplyText(currentCommand));
                    break;

                case CommandType.DeleteWord:
                    chat.DeleteFromDictionary(CommandProcessor.GetCommandParams(currentCommand).First());
                    await SendText(chat, CommandProcessor.GetReplyText(currentCommand));
                    break;

                case CommandType.Dictionary:
                    await SendText(chat, chat.ChatDictionary);
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
    }
}
