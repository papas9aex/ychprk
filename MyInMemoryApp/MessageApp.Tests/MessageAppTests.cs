using Allure.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using Xunit;

namespace MessageApp.Tests
{
    public class MessageAppTests : IClassFixture<AllureLifecycle>
    {
        private readonly IWebDriver _driver;
        private readonly AllureLifecycle _allureLifecycle;

        public MessageAppTests(AllureLifecycle allureLifecycle)
        {
            _driver = new ChromeDriver();
            _allureLifecycle = allureLifecycle;
        }

        [Fact]
        [Trait("Category", "UI")]
        public void SendMessageTest()
        {
            _driver.Navigate().GoToUrl("http://localhost:5000/index.html");

            var messageInput = _driver.FindElement(By.Id("messageInput"));
            var sendButton = _driver.FindElement(By.Id("sendMessageBtn"));

            // Вводим сообщение
            messageInput.SendKeys("Привет, это тестовое сообщение!");

            // Нажимаем кнопку "Отправить"
            sendButton.Click();

            // Ждем некоторое время, чтобы сообщение было отправлено
            Thread.Sleep(2000);

            // Проверяем, что сообщение появилось в списке
            var messagesList = _driver.FindElement(By.Id("messagesList"));
            Assert.Contains("Привет, это тестовое сообщение!", messagesList.Text);
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}
