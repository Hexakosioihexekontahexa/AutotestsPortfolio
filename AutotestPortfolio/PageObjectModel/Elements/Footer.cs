using System.Collections.Generic;
using OpenQA.Selenium;
using Tellurium.StableElements;
using static AutotestPortfolio.Tests;

namespace AutotestPortfolio.PageObjectModel.Elements
{
    public class Footer
    {
        public readonly IList<IWebElement> FooterLinks = Driver.FindElements(By.ClassName("footer-style__item"));
        public readonly IList<IWebElement> FooterSocials =
            Driver.FindElements(By.ClassName("footer-style__social-button"));
        public readonly IWebElement Copyright = Driver.FindStableElement(By.ClassName("footer-style__copy"));
    }
}