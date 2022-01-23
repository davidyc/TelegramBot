using System;
using System.Collections.Generic;
using System.Text;
using TelegramBot.Services.Interfaces;
using TelegramBot.Services.Model;

namespace TelegramBot.Services.Implementation
{
    public class SalaryService : ISalaryService
    {

        public double GetGrossKZTRound(double USDKZT, int count)
        { 
            if(USDKZT < 0)
                throw new ArgumentException("USDKZT can not be less 0");
            if (count < 0)
                throw new ArgumentException("count can not be less 0");

            return Math.Round(count * USDKZT); 
        }
            
        

        
    }
}
