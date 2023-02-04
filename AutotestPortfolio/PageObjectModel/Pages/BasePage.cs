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

        public readonly IList<IWebElement> SearchResults = Driver.FindElements(By.XPath("//*[@id=\"search-page\"]//li"));

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
        
        public static void DoSearch(string searchQuery)
        {
            //Header header = new Header();
            Header.SearchBox.SendKeys(searchQuery);
        }

        public static void DoBaseLogin((string, string) userData)
        {
            Header.LoginForm.LoginField.SendKeys(userData.Item1);
            Header.LoginForm.PasswordField.SendKeys(userData.Item2);
            Header.LoginForm.ConfirmationButton.Click();
        }

        public void ClickFirstItem(IList<IWebElement> list)
        {
            list.FirstOrDefault().Click();
        }

        public void ClickDefinedItem(IList<IWebElement> list, int index)
        {
            SearchResults.ElementAt(index).Click();
        }
    }
}