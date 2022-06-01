﻿using Telegram.Bot;
using Telegram.Bot.Args;

namespace TKTrialBot
{
    public class BotWorker
    {
        private ITelegramBotClient? botClient;
        private BotMessageLogic? logic;

        public void Initialize()
        {
            botClient = new TelegramBotClient(BotCredentials.BotToken);
            logic = new BotMessageLogic(botClient);
        }

        public void Start()
        {
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            //botClient.OnCallbackQuery += Bot_Callback;
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
        }

        //private async void Bot_Callback(object sender, CallbackQueryEventArgs e)
        //{
        //    var text = string.Empty;

        //    switch (e.CallbackQuery.Data)
        //    {
        //        case "pushkin":
        //            text = @"Я помню чудное мгновенье:
        //                            Передо мной явилась ты,
        //                            Как мимолетное виденье,
        //                            Как гений чистой красоты.";
        //            break;
        //        case "esenin":
        //            text = @"Не каждый умеет петь,
        //                        Не каждому дано яблоком
        //                        Падать к чужим ногам.";
        //            break;
        //        default:
        //            break;
        //    }

        //    await botClient.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, text);
        //    await botClient.AnswerCallbackQueryAsync(e.CallbackQuery.Id);
        //}
    }
}

