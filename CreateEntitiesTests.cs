using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace RHiDv2_E2E_Tests.CreateInstances
{
    public class CreateEntitiesTests : IDisposable
    {

        protected static IWebDriver driver;
        public CreateEntitiesTests() 
        {

            driver = WebDriverInfra.Create_Browser(BrowserType.Chrome);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl($"{Utils.testURL}/login");

            driver.Manage().Window.Maximize();

            Thread.Sleep(2000);
            Assert.Equal("RHiD - Login", driver.Title);

            // Click on First Check box
            IWebElement emailInput = driver.FindElement(By.Id("email"));
            emailInput.SendKeys(Utils.login);

            IWebElement passwordInput = driver.FindElement(By.Id("password"));
            passwordInput.Click();
            passwordInput.SendKeys(Utils.password);

            // Click on Second Check box
            IWebElement loginButton = driver.FindElement(By.Id("m_login_signin_submit"));
            loginButton.Click();

            Thread.Sleep(2000);
        }

        [Fact]
        public void ShouldCreateCompany()
        {
            var cadastroMenu = driver.FindElement(By.XPath("/html/body/div[3]/div/div[1]/div/ul/li[1]/a/span"));
            cadastroMenu.Click();
            Thread.Sleep(2000);
            var empresaMenu = driver.FindElement(By.XPath("/html/body/div[3]/div/div[1]/div/ul/li[1]/div/ul/li[2]/a/span"));
            empresaMenu.Click();
            Thread.Sleep(2000);
            Assert.Equal("RHiD - Empresas", driver.Title);

            var addCompanyButton = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div/div[1]/div/div/div[1]/div[2]/ul/li[1]/a"));
            addCompanyButton.Click();
            Thread.Sleep(2000);

            var name = "CompanyName";
            IWebElement companyNameInput = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div/div[1]/div/div/div/div/div/div/div[2]/div/div[1]/form/div/div/my-input-text[1]/div/div/div/input"));
            companyNameInput.Click();
            companyNameInput.SendKeys(name);

            IWebElement companyFantasyNameInput = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div/div[1]/div/div/div/div/div/div/div[2]/div/div[1]/form/div/div/my-input-text[2]/div/div/div/input"));
            companyFantasyNameInput.Click();
            companyFantasyNameInput.SendKeys(name);

            var cnpj = "93543434000119";
            IWebElement cnpjInput = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div/div[1]/div/div/div/div/div/div/div[2]/div/div[1]/form/div/div/my-input-text[3]/div/div/div/input"));
            cnpjInput.Click();
            cnpjInput.SendKeys(cnpj);

            var cep = "15500000";
            IWebElement cepInput = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div/div[1]/div/div/div/div/div/div/div[2]/div/div[1]/form/div/div/my-input-text[5]/div/div/div/input"));
            cepInput.Click();
            cepInput.SendKeys(cep);

            var endereco = "Endereco";
            IWebElement enderecoInput = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div/div[1]/div/div/div/div/div/div/div[2]/div/div[1]/form/div/div/my-input-text[6]/div/div/div/input"));
            enderecoInput.Click();
            enderecoInput.SendKeys(endereco);

            var bairro = "Bairro";
            IWebElement bairroInput = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div/div[1]/div/div/div/div/div/div/div[2]/div/div[1]/form/div/div/my-input-text[7]/div/div/div/input"));
            bairroInput.Click();
            bairroInput.SendKeys(bairro);

            var cidade = "Cidade";
            IWebElement cidadeInput = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div/div[1]/div/div/div/div/div/div/div[2]/div/div[1]/form/div/div/my-input-text[8]/div/div/div/input"));
            cidadeInput.Click();
            cidadeInput.SendKeys(cidade);

            var ufSelect = new SelectElement(driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div/div[1]/div/div/div/div/div/div/div[2]/div/div[1]/form/div/div/my-combo-box[1]/div/div/div/select")));
            //select by value
            //selectElement.SelectByValue("Jr.High");
            // select by text
            ufSelect.SelectByText("SP");

            var nFolha = "2";
            IWebElement nFolhaInput = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div/div[1]/div/div/div/div/div/div/div[2]/div/div[1]/form/div/div/my-input-text[9]/div/div/div/input"));
            nFolhaInput.Click();
            nFolhaInput.SendKeys(nFolha);

            var insEstadual = "2";
            IWebElement insEstadualInput = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div/div[1]/div/div/div/div/div/div/div[2]/div/div[1]/form/div/div/my-input-text[10]/div/div/div/input"));
            insEstadualInput.Click();
            insEstadualInput.SendKeys(insEstadual);
            
            IWebElement responsavelLegal = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div/div[1]/div/div/div/div/div/div/div[1]/div[2]/ul/li[2]/a"));
            responsavelLegal.Click();
            Thread.Sleep(1000);

            var cpfLegal = "58617123010";
            IWebElement cpfLegalInput = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div/div[1]/div/div/div/div/div/div/div[2]/div/div[2]/form/div/div[1]/my-input-text[1]/div/div/div/input"));
            cpfLegalInput.Click();
            cpfLegalInput.SendKeys(cpfLegal);

            var nomeLegal = "Nome Legal";
            IWebElement enomeLegalInput = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div/div[1]/div/div/div/div/div/div/div[2]/div/div[2]/form/div/div[1]/my-input-text[2]/div/div/div/input"));
            enomeLegalInput.Click();
            enomeLegalInput.SendKeys(nomeLegal);

            var cargoLegal = "cargo";
            IWebElement cargoLegalInput = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div/div[1]/div/div/div/div/div/div/div[2]/div/div[2]/form/div/div[1]/my-input-text[3]/div/div/div/input"));
            cargoLegalInput.Click();
            cargoLegalInput.SendKeys(cargoLegal);

            var emailLegal = "email@email.com";
            IWebElement emailLegalInput = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div/div[1]/div/div/div/div/div/div/div[2]/div/div[2]/form/div/div[2]/my-input-text/div/div/div/input"));
            emailLegalInput.Click();
            emailLegalInput.SendKeys(emailLegal);

            IWebElement saveButton = driver.FindElement(By.Id("btnSave"));
            saveButton.Click();
            Thread.Sleep(3000);
            Assert.Equal("RHiD - Empresas", driver.Title);

            IWebElement baseTable = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div/div[1]/div/div/div[2]/div/div/div/div/div[2]/div/table"));
            var tableRows = baseTable.FindElements(By.TagName("tr"));
            foreach (var item in tableRows)
            {
                if (item.Text.Contains(name))
                {
                    var deleteButton = item.FindElements(By.ClassName("m-btn--hover-danger")).FirstOrDefault();
                    if(deleteButton != null) deleteButton.Click();
                    break;
                }
            }

            Thread.Sleep(1000);

            IWebElement confirmButton = driver.FindElement(By.XPath("/html/body/div[7]/div/div/div[2]/button[2]"));
            confirmButton.Click();

            Thread.Sleep(1000);

            Assert.Equal("RHiD - Empresas", driver.Title);

        }

        [Fact]
        public void ShouldCreateDepartment() 
        {
            var cadastroMenu = driver.FindElement(By.XPath("/html/body/div[3]/div/div[1]/div/ul/li[1]/a/span"));
            cadastroMenu.Click();
            Thread.Sleep(2000);

            var departamentoMenu = driver.FindElement(By.XPath("/html/body/div[3]/div/div[1]/div/ul/li[1]/div/ul/li[3]/a"));
            departamentoMenu.Click();
            Thread.Sleep(2000);

            Assert.Equal("RHiD - Departamentos", driver.Title);

            var addButtonDepartamento = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div/div[1]/div/div/div[1]/div[2]/ul/li[1]/a"));
            addButtonDepartamento.Click();
            Thread.Sleep(2000);

            var name = "DepartmentName";
            IWebElement DepartmentNameInput = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div/div[1]/div/div/div/div/div/div/div[2]/div/div[1]/form/div/div/my-input-text[1]/div/div/div/input"));
            DepartmentNameInput.Click();
            DepartmentNameInput.SendKeys(name);

            var numeroFolha = "1234";
            IWebElement NumeroFolhaInput = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div/div[1]/div/div/div/div/div/div/div[2]/div/div[1]/form/div/div/my-input-text[2]/div/div/div/input"));
            NumeroFolhaInput.Click();
            NumeroFolhaInput.SendKeys(numeroFolha);

            IWebElement saveButton = driver.FindElement(By.Id("btnSave"));
            saveButton.Click();
            Thread.Sleep(3000);

            Assert.Equal("RHiD - Departamentos", driver.Title);

            IWebElement baseTable = driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div/div[1]/div/div/div[2]/div/div/div/div/div[2]/div/table"));
            var tableRows = baseTable.FindElements(By.TagName("tr"));
            foreach (var item in tableRows)
            {
                if (item.Text.Contains(name))
                {
                    var deleteButton = item.FindElements(By.ClassName("m-btn--hover-danger")).FirstOrDefault();
                    if (deleteButton != null) deleteButton.Click();
                    break;
                }
            }

            Thread.Sleep(1000);

            IWebElement confirmButton = driver.FindElement(By.XPath("/html/body/div[7]/div/div/div[2]/button[2]"));
            confirmButton.Click();

            Thread.Sleep(1000);

            Assert.Equal("RHiD - Departamentos", driver.Title);

        }


        public void Dispose()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }
    }
}