using System;
using TelegramBotLibrary.Implementation;

namespace TelegramBotConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new TelegramBot("5015727824:AAHk4W_vg2GIXk6f0Yx3krol6DGl-UE5rMc");
            bot.Run();
            Console.WriteLine("Hello World!");
        }
    }
}
