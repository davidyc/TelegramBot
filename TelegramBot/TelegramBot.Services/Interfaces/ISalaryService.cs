using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBot.Services.Interfaces
{
    public interface ISalaryService
    {
        double GetGrossKZTRound(double USDKZT, int count);


    }
}
