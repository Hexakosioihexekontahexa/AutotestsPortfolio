using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Tellurium.StableElements;
using static AutotestPortfolio.Setup;
using static AutotestPortfolio.Tests;

namespace AutotestPortfolio.PageObjectModel.Pages
{
    public class CataloguePage : BasePage
    {
        public const string BasePageUrl = "https://catalog.onliner.by/";
        public IList<IWebElement> CatalogueResults { get; } = Driver.FindElements(By.ClassName("schema-product__group"));

        public static readonly IWebElement NavigationTitle = Wait.Until(e =>
            Driver.FindElements(By.ClassName("catalog-navigation__title")).FirstOrDefault());

        public static readonly IWebElement ProductItem = Driver.FindStableElement(By.ClassName("catalog-masthead__title"));

        public static readonly IList<IWebElement> ManufacturerList = Driver.FindElements(By.XPath("//div[4]/div[4]//ul"));

        public static readonly IList<IWebElement> PriceRange =
            Driver.FindElements(By.XPath("//*[@id=\"schema-filter\"]//div[5]/div[2]/div/div"));

        public static readonly IWebElement SpinSpeed = Driver.FindStableElement(By.XPath("//div[1]/select"));

        public static readonly IList<IWebElement> SteamTreatment = Driver.FindElements(By.XPath("//div[20]/div[3]/div"));

        public static readonly IWebElement MaxPrograms = Driver.FindStableElement(By.XPath("//div[21]/div[3]//div[2]"));
    }
}