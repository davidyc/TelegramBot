using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Services.Implementation;
using TelegramBot.Services.Interfaces;
using TelegramBot.Services.Model;

namespace TelegramBotLibrary.Implementation
{
    public class TelegramBots
    {
        private readonly TelegramBotClient _botClient;
        private readonly ICurrencyService _currencyService;
        private readonly ISalaryService _salaryService;


        public TelegramBots(string tokenTB, ICurrencyService currencyService, ISalaryService salaryService)
        {
            _botClient = new TelegramBotClient(tokenTB);
            _currencyService = currencyService;
            _salaryService = salaryService;
        }

        public async void Run()
        {
            using var cts = new CancellationTokenSource();
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { } // receive all update types
            };

            _botClient.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken: cts.Token);        
            Console.ReadLine();          
            cts.Cancel();
        }

        async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type != UpdateType.Message)
                return;
      
            if (update.Message!.Type != MessageType.Text)
                return;

            var chatId = update.Message.Chat.Id;
            var messageText = update.Message.Text;

           // Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
            {
                new KeyboardButton[] { "Курс и ЗП", "Two" },
                new KeyboardButton[] { "Three", "Four" },
            })
            {
                ResizeKeyboard = true
            };

            var curKZT = await GetCurrncyKTZ(DateTime.Now);
            var curLiveKZT = await _currencyService.GetKZTBYLive();
            var kzt = _salaryService.GetGrossKZTRound(curKZT.Quotes.USDKZT, 1070);

            Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: kzt.ToString(),
                cancellationToken: cancellationToken,
                 replyMarkup: replyKeyboardMarkup);
        }

        Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        async Task<KTZCurrencyModel> GetCurrncyKTZ(DateTime date)
        {           
            return await _currencyService.GetKZTBYDate(date);
        }




    }
}
