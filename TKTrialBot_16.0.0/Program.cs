﻿using TKTrialBot;

var bot = new BotWorker();
bot.Initialize();

bot.Start();

Console.WriteLine("Напишите stop для прекращения работы");

string command;
do
{
    command = Console.ReadLine();

} while (command != "stop");

bot.Stop();
