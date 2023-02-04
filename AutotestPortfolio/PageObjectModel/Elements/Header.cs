using System.Collections.Generic;
using OpenQA.Selenium;
using static AutotestPortfolio.Tests;

namespace AutotestPortfolio.PageObjectModel.Elements
{
    public class Header
    {
        public readonly IList<IWebElement> CategoriesList = Driver.FindElements(By.ClassName("b-main-navigation__text"));
        // public static readonly IWebElement Catalogue = Driver.FindElement(By.XPath("//nav/ul[1]/li[1]//span"));
        // public static readonly IWebElement News = Driver.FindElement(By.XPath("//nav/ul[1]/li[2]/a[1]/span"));
        // public static readonly IWebElement Autos = Driver.FindElement(By.XPath("//nav/ul[1]/li[3]/a[1]/span"));
        // public static readonly IWebElement Houses = Driver.FindElement(By.XPath("//nav/ul[1]/li[4]/a[1]/span"));
        // public static readonly IWebElement Services = Driver.FindElement(By.XPath("//nav/ul[1]/li[5]//span"));
        // public static readonly IWebElement FleaMarket = Driver.FindElement(By.XPath("//nav/ul[1]/li[6]//span"));
        // public static readonly IWebElement Forum = Driver.FindElement(By.XPath("//nav/ul[1]/li[7]//span"));

        public readonly IWebElement OfferCard = Driver.FindElement(By.ClassName("b-top-navigation-clover"));

        public readonly IWebElement CurrencyRate = Driver.FindElement(By.ClassName("top-informer-currency"));
        public readonly IWebElement WeatherCast = Driver.FindElement(By.ClassName("top-informer-weather"));

        public readonly IWebElement SiteLogo = Driver.FindElement(By.ClassName("onliner_logo"));

        public readonly IWebElement SearchBox = Driver.FindElement(By.ClassName("fast-search__input"));

        public readonly IWebElement BaseLoginButton = Driver.FindElement(By.ClassName("auth-bar__item--text"));
        //there are other login methods being omitted

        public static readonly IWebElement Cart = Driver.FindElement(By.ClassName("auth-bar__item--cart"));

        public LoginForm LoginForm = new LoginForm();
    }
}