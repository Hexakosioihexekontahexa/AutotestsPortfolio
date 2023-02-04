using System;
using System.Linq;
using AutotestPortfolio.PageObjectModel.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using static AutotestPortfolio.Setup;

namespace AutotestPortfolio
{
    public class Tests
    {
        public static readonly IWebDriver Driver = new ChromeDriver();

        [SetUp]
        public void Setup()
        {
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void CheckCopyrightYear()
        {
            Driver.Navigate().GoToUrl(HomePage.BasePageUrl);
            Assert.That(HomePage.Footer.Copyright.Text.Contains(DateTime.Today.Year.ToString()),
                "Copyright data is not actual.");
        }

        [Test]
        public void CheckCategorySelection()
        {
            Driver.Navigate().GoToUrl(HomePage.BasePageUrl);
            var categoryName = HomePage.Header.CategoriesList.First().GetAttribute("innerText");
            HomePage.OpenCategory(HomePage.Header.CategoriesList.First());
            Assert.That(CataloguePage.NavigationTitle.Text.Contains(categoryName),
                "Category name differs from expected.");
        }

        [Test]
        public void ForumPageHasUpToThreeHeaderAds()
        {
            Driver.Navigate().GoToUrl(ForumPage.BasePageUrl);
            ForumPage forumPage = new ForumPage();
            Assert.That(forumPage.HeaderAdBlock.Displayed, "Missing ad block above header on Forum page.");
        }

        [Test]
        public void UserCanDoBaseLogin()
        {
            Driver.Navigate().GoToUrl(HomePage.BasePageUrl);
            HomePage.Header.LoginForm.LoginField.SendKeys(TestUserData.login);
            HomePage.Header.LoginForm.PasswordField.SendKeys(TestUserData.password);
            HomePage.Header.LoginForm.ConfirmationButton.Click();
            Driver.Navigate().GoToUrl(ProfilePage.BasePageUrl);
            ProfilePage profilePage = new ProfilePage();
            Assert.That(profilePage.ProfileName.GetAttribute("innerText").Equals("3619215"), 
                "User is either not logged or wrong. Possible captcha failure.");
        }

        [Test]
        public void LoggedUserIsRedirectedToHomePageUponHardRefresh()
        {
            Driver.Navigate().GoToUrl(HomePage.BasePageUrl);
            HomePage.Header.LoginForm.LoginField.SendKeys(TestUserData.login);
            HomePage.Header.LoginForm.PasswordField.SendKeys(TestUserData.password);
            HomePage.Header.LoginForm.ConfirmationButton.Click();
            Driver.Navigate().GoToUrl(ProfilePage.BasePageUrl);
            ProfilePage.HardRefresh();
            Assert.That(Driver.Url.Equals(HomePage.BasePageUrl), "User was not redirected to Home page.");
        }

        [Test]
        public void UserCanDoSearch()
        {
            Driver.Navigate().GoToUrl(HomePage.BasePageUrl);
            HomePage homePage = new HomePage();
            var result = homePage.DoSearch("Karcher");
            homePage.ClickFirstItem(result);
            Assert.That(
                CataloguePage.ProductItem.GetAttribute("innerText").Equals("Пылесос Karcher WD 3 V 1.628-101.0"),
                "Either search was not successful, or wrong product page is loaded.");
        }

        [Test]
        public void UserCanApplyFiltersOnCataloguePage()
        {
            Driver.Navigate().GoToUrl("https://catalog.onliner.by/washingmachine");
            for (int i = 0; i < 2; i++)
            {
                CataloguePage.ManufacturerList[i].Click();
            }
            CataloguePage.PriceRange.First().SendKeys("2000");
            var selectSpinSpeed = new SelectElement(CataloguePage.SpinSpeed);
            selectSpinSpeed.SelectByValue("1000 об/мин");
            CataloguePage.SteamTreatment.Last().Click();
            CataloguePage.MaxPrograms.SendKeys("8");
            CataloguePage cataloguePage = new CataloguePage();
            Assert.That(cataloguePage.CatalogueResults.Count.Equals(12), "Filtering applied incorrectly."); 
        }

        [Test]
        public void UserCanCompareProductItems()
        {
            
        }

        [Test]
        public void UserCanPutAnItemToBasket()
        {
            
        }

        [Test]
        public void UserCanRemoveAnItemFromBasket()
        {
            
        }

        [TearDown]
        public void RefreshSession()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Navigate().GoToUrl(HomePage.BasePageUrl);
        }

        [OneTimeTearDown]
        public void EndSession()
        {
            Driver.Quit();
        }
    }
}