using OpenQA.Selenium;
using Tellurium.StableElements;
using static AutotestPortfolio.Tests;

namespace AutotestPortfolio.PageObjectModel.Pages
{
    public class ForumPage : BasePage
    {
        public const string BasePageUrl = "https://forum.onliner.by/";

        public readonly IWebElement HeaderAdBlock =
            Driver.FindStableElement(By.ClassName("bnr-top-wide"));
    }
}