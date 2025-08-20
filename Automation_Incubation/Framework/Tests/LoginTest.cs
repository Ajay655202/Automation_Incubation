using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggingAutomation.Framework.Actions;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace LoggingAutomation.Framework.Tests
{
    [TestFixture]
    public class LoginTests
    {
        private IWebDriver _driver;
        private LoginAction loginAction;
        private string? browser;
        private string? baseUrl;
        private string? userId;
        private string? password;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            string path = string.Concat(AppContext.BaseDirectory, "Framework");
            var config = new ConfigurationBuilder()
            .SetBasePath(path)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
            browser = config["Browser"];
            baseUrl = config["BaseUrl"];
            userId = config["UserName"];
            password = config["Password"];
        }

        [SetUp]
        public void SetUp()
        {
            _driver = DriverFactory.GetDriver(browser);
            loginAction = new LoginAction(_driver);
            _driver.Navigate().GoToUrl(baseUrl);
        }

        [Test]
        [Category("Regression")]
        public void LoginToApp()
        {
            loginAction.LoginAs(userId, password);
            Assert.IsTrue(_driver.Title.Contains("Practice"));
        }

        [Test]
        [Category("Regression")]
        public void LoginToApp2()
        {
            loginAction.LoginAs(userId, password);
            Assert.IsTrue(_driver.Title.Contains("Practice"));
        }

        [Test]
        [Category("Regression")]
        public void LoginToApp3()
        {
            loginAction.LoginAs(userId, password);
            Assert.IsTrue(_driver.Title.Contains("Practice"));
        }

        [Test]
        public void InvalidLoginToApp()
        {
            loginAction.LoginAs(userId, password);
            Assert.IsTrue(_driver.Title.Contains("123Practice123"));
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Dispose();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver?.Dispose();
        }
    }
}
