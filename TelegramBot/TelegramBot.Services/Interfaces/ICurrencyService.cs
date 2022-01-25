using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Services.Model;

namespace TelegramBot.Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<KTZCurrencyModel> GetKZTBYDate(DateTime dateTime);
        Task<KTZCurrencyModel> GetKZTBYLive();
    }
}
