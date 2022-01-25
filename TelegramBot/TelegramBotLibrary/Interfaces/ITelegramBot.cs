using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Services.Model;

namespace TelegramBotLibrary.Interfaces
{
    public interface ITelegramBot
    {
        Task<KTZCurrencyModel> GetCurrncyKTZ(DateTime date);

        DateTime GetLastDayOfMonth(DateTime dateTime);
        Task Run();
    }
}
