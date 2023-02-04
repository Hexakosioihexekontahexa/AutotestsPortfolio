using System.Collections.Generic;
using System.Linq;
using AutotestPortfolio.PageObjectModel.Elements;
using OpenQA.Selenium;
using static AutotestPortfolio.Tests;

namespace AutotestPortfolio.PageObjectModel.Pages
{
    public abstract class BasePage
    {
        private const string HomePageUrl = "https://www.onliner.by";

        private IList<IWebElement> SearchResults { get; } = Driver.FindElements(By.ClassName("search__result"));

        public static Header Header = new Header();
        public static Footer Footer = new Footer();

        public static void Refresh()
        {
            Driver.Navigate().Refresh();
        }

        public static void HardRefresh()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Navigate().Refresh();
        }

        public static void OpenHomePage()
        {
            Driver.Navigate().GoToUrl(HomePageUrl);
        }
        
        public static void OpenCategory(IWebElement category)
        {
            category.Click();
        }
        
        public IList<IWebElement> DoSearch(string searchQuery)
        {
            Header.SearchBox.SendKeys(searchQuery);
            return SearchResults;
        }

        public static void DoBaseLogin((string, string) userData)
        {
            Header.LoginForm.LoginField.SendKeys(userData.Item1);
            Header.LoginForm.PasswordField.SendKeys(userData.Item2);
            Header.LoginForm.ConfirmationButton.Click();
        }

        public void ClickFirstItem(IList<IWebElement> list)
        {
            SearchResults.FirstOrDefault().Click();
        }

        public void ClickDefinedItem(IList<IWebElement> list, int index)
        {
            SearchResults.ElementAt(index).Click();
        }
    }
}