using NUnit.Framework;
using System;
using TelegramBot.Services.Implementation;
using TelegramBot.Services.Interfaces;

namespace TelegramBot.Tests
{
    
    public class SalaryServiceTests
    {
        private SalaryService salaryService;

        [SetUp]
        public void Setup()
        {
            ISalaryService salaryService = new SalaryService();
        }

        [Test]
        [TestCase(1000.1234,100, 100012)]
        [TestCase(188.54, 100, 18854)]
        [TestCase(500.1234, 10, 5001)]
        [TestCase(0.0, 100, 0)]
        [TestCase(1000.0, 100, 100000)]
        public void GrossKZT_Current_Salary(double USDKZT, int count, double excepted)
        {
            salaryService = new SalaryService();
            var actual = salaryService.GetGrossKZTRound(USDKZT, count);
            Assert.AreEqual(excepted, actual);
        }

        [Test]
        [TestCase(-1000.1234, 100)]
        [TestCase(-188.54, 100)]
        [TestCase(500.1234, -10)]
        [TestCase(-0.1, 100)]
        [TestCase(1000.0, -1)]
        public void GrossKZT_Less0_Argument(double USDKZT, int count)
        {
            salaryService = new SalaryService();          
            Assert.Throws<ArgumentException>(() => salaryService.GetGrossKZTRound(USDKZT, count));
        }
    }
}