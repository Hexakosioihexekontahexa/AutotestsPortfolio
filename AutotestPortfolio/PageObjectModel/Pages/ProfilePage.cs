using OpenQA.Selenium;
using Tellurium.StableElements;
using static AutotestPortfolio.Tests;

namespace AutotestPortfolio.PageObjectModel.Pages
{
    public class ProfilePage : BasePage
    {
        public const string BasePageUrl = "https://profile.onliner.by/";

        public readonly IWebElement ProfileName = Driver.FindElement(By.ClassName("profile-header__name"));
        

    }
}