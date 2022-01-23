using Microsoft.Extensions.Configuration;
using System;
using TelegramBot.Services.Implementation;
using TelegramBotLibrary.Implementation;

namespace TelegramBotConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .AddUserSecrets<Program>()
                .Build();


            var c= new CurrencyService(config["currencyAPI"], config["currencyToken"]);
            var s = new SalaryService();
            var bot = new TelegramBots(config["TelegramBotsToken"], c, s);
            bot.Run();
            Console.WriteLine("Hello World!");
        }
    }
}
