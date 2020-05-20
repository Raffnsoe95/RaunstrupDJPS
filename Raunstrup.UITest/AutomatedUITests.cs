using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace Raunstrup.UITest
{
    public class AutomatedUITests :IDisposable
    {
        private readonly IWebDriver _driver;
        public AutomatedUITests()
        {
            _driver = new ChromeDriver();
        }
        [Fact]
        public void Test1()
        {
            _driver.Navigate()
        .GoToUrl("https://localhost:44347/");

            Assert.Equal("Create - EmployeesApp", _driver.Title);
            Assert.Contains("Please provide a new employee data", _driver.PageSource);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
