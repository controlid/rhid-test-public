using OpenQA.Selenium;

namespace RHiDv2_E2E_Tests.Login
{
    public class LoginTests: IDisposable
    {

        protected static IWebDriver driver;
        public LoginTests() 
        {
            driver = WebDriverInfra.Create_Browser(BrowserType.Chrome);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl($"{Utils.testURL}/login");

            driver.Manage().Window.Maximize();
        }

        [Theory]
        [InlineData(Utils.login, Utils.password, true)]
        [InlineData(Utils.login, $"{Utils.password}+**", false)]
        public void NavigateToApp(string login, string password, bool shouldLogin)
        {
                Thread.Sleep(2000);
                Assert.Equal("RHiD - Login", driver.Title);

                // Click on First Check box
                IWebElement emailInput = driver.FindElement(By.Id("email"));
                emailInput.SendKeys(login);

                IWebElement passwordInput = driver.FindElement(By.Id("password"));
                passwordInput.Click();
                passwordInput.SendKeys(password);
                //firstCheckBox.Click();

                // Click on Second Check box
                IWebElement loginButton = driver.FindElement(By.Id("m_login_signin_submit"));
                loginButton.Click();

                Thread.Sleep(2000);


                if (shouldLogin)
                {
                    Assert.Equal("RHiD - Dashboard", driver.Title);
                }
                else
                {
                
                    Assert.True(IsElementPresent(driver, By.XPath("/html/body/div[7]/div/div/div[1]/div[contains(., 'Usuário ou senha inválidos')]")));
                }
        }

        private bool IsElementPresent(IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}