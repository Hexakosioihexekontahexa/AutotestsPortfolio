using System;
using OpenQA.Selenium.Support.UI;
using static AutotestPortfolio.Tests;

namespace AutotestPortfolio
{
    public static class Setup
    {
        public static readonly WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

        public static (string login, string password) TestUserData = ("jehevif362@bymercy.com", "Test1q2w");
    }
}