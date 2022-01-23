using System;
using System.Collections.Generic;
using System.Text;
using TelegramBot.Services.Interfaces;
using TelegramBot.Services.Model;

namespace TelegramBot.Services.Implementation
{
    public class SalaryService : ISalaryService
    {

        public double GrossKZT(double USDKZT, int count) => count * Math.Round(USDKZT);
            
        

        
    }
}
