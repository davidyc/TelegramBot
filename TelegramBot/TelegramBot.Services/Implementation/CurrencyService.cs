using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Services.Interfaces;
using TelegramBot.Services.Model;

namespace TelegramBot.Services.Implementation
{
    public class CurrencyService : ICurrencyService
    {
        private readonly RestClient _client;      
        private readonly string _token;

        private const string HISTORICAL_API = "historical";
        private const string LIVE_API = "live";


        public CurrencyService(string serviceURL, string token)
        {
            _client = new RestClient(serviceURL);
            _token = token;
        }

        public async Task<KTZCurrencyModel> GetKZTBYDate(DateTime dateTime)
        {
            var request = new RestRequest(HISTORICAL_API, Method.Get)
                .AddQueryParameter("access_key", _token)
                .AddQueryParameter("date",  dateTime.ToString("yyyy-MM-dd"));
            return await _client.GetAsync<KTZCurrencyModel>(request);           
        }

        public async Task<KTZCurrencyModel> GetKZTBYLive()
        {
            var request = new RestRequest(LIVE_API, Method.Get)
                .AddQueryParameter("access_key", _token);               
            return await _client.GetAsync<KTZCurrencyModel>(request);
        }

    }
}
