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
            IWebDriver _driver = DriverFactory.GetDriver(browser);
            loginAction = new LoginAction(_driver);
            _driver.Navigate().GoToUrl(baseUrl);
        }

        [Test]
        [Category("Regression")]
        public void LoginToApp()
        {
            string title = loginAction.LoginAs(userId, password);
            Assert.IsTrue(title.Contains("Practice"));
        }

        [Test]
        [Category("Regression")]
        public void LoginToApp2()
        {
            string title = loginAction.LoginAs(userId, password);
            Assert.IsTrue(title.Contains("Practice"));
        }

        [Test]
        [Category("Regression")]
        public void LoginToApp3()
        {
            string title = loginAction.LoginAs(userId, password);
            Assert.IsTrue(title.Contains("Practice"));
        }

        [Test]
        public void InvalidLoginToApp()
        {
            string title = loginAction.LoginAs(userId, password);
            Assert.IsTrue(title.Contains("Practice"));
        }

        [TearDown]
        public void TearDown()
        {
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
        }
    }
}
