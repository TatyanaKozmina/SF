using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using UtilityBot_18.Services;

namespace UtilityBot_18.Controllers
{
    public class TextMessageController
    {
        private readonly ITelegramBotClient _telegramClient;
        private readonly IStorage _memoryStorage;
        private readonly ICalc _calc;
        public TextMessageController(ITelegramBotClient telegramBotClient, IStorage memoryStorage, ICalc calc)
        {
            _telegramClient = telegramBotClient;
            _memoryStorage = memoryStorage;
            _calc = calc;
        }

        public async Task Handle(Message message, CancellationToken ct)
        {

            switch (message.Text)
            {
                case "/start":

                    // Объект, представляющий кнопки
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                            InlineKeyboardButton.WithCallbackData($" Число символов" , $"len"),
                            InlineKeyboardButton.WithCallbackData($" Сумма" , $"sum")
                        });

                    // передаем кнопки вместе с сообщением (параметр ReplyMarkup)
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"<b>  Бот может работать в двух режимах.</b> {Environment.NewLine}" +
                        $"{Environment.NewLine}Можно посчитать число символов в тексте или сумму чисел.{Environment.NewLine}", cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));

                    break;
                default:
                    string selectedFunc = _memoryStorage.GetSession(message.Chat.Id).PressedButton; // Здесь получим выбранную функцию
                    var calcResult = await _calc.CalculateAsync(selectedFunc, message.Text, ct);
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"Выбрана функция {selectedFunc}", cancellationToken: ct);
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"Результат {calcResult}", cancellationToken: ct);
                    break;
            }

        }
    }
}
