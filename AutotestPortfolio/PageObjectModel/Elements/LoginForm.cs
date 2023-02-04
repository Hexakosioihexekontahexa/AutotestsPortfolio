using OpenQA.Selenium;
using Tellurium.StableElements;
using static AutotestPortfolio.Tests;

namespace AutotestPortfolio.PageObjectModel.Elements
{
    public class LoginForm
    {
        public readonly IWebElement LoginField = Driver.FindStableElement(By.XPath("//form/div[1]//input"));
        public readonly IWebElement PasswordField = Driver.FindStableElement(By.XPath("//form/div[2]//input"));

        public readonly IWebElement ConfirmationButton =
            Driver.FindStableElement(By.XPath("//*[@id=\"auth-container\"]//button"));
    }
}