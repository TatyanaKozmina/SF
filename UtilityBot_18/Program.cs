﻿using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using UtilityBot_18;
using UtilityBot_18.Controllers;
using UtilityBot_18.Services;

Console.OutputEncoding = Encoding.Unicode;

// Объект, отвечающий за постоянный жизненный цикл приложения
var host = new HostBuilder()
.ConfigureServices((hostContext, services) => ConfigureServices(services)) // Задаем конфигурацию
.UseConsoleLifetime() // Позволяет поддерживать приложение активным в консоли
.Build(); // Собираем

Console.WriteLine("Сервис запущен");
// Запускаем сервис
await host.RunAsync();
Console.WriteLine("Сервис остановлен");

static void ConfigureServices(IServiceCollection services)
{
    // Подключаем контроллеры сообщений и кнопок
    services.AddTransient<DefaultMessageController>();
    services.AddTransient<TextMessageController>();
    services.AddTransient<InlineKeyboardController>();

    // Регистрируем объект TelegramBotClient c токеном подключения
    services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient("5424249902:AAGJ0C9LdG38a1ZuBMqLennz9DhWAbmnWX8"));
    services.AddSingleton<IStorage, MemoryStorage>();
    services.AddSingleton<ICalc, Calc>();
    // Регистрируем постоянно активный сервис бота
    services.AddHostedService<Bot>();
}