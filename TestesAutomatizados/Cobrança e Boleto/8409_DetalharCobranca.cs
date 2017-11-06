using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;

namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <summary>
    /// Summary description for CodedUITest5
    /// </summary>
    [CodedUITest]
    public class DetalharCobranca
    {
        public DetalharCobranca()
        {
        }

        [TestMethod]
        public void DetalharCobranca_8409()
        {
            string holder = "A28282";
            string modalityName = "AP 2826 - Beach Tênis - Normal - 15:00:00";
            string modalityBillingName = "Beach Tênis";

            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();
            OpenCash openCash = new OpenCash();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            openCash.OpenCashMethod();

            McMenus.AcessarMenuOperacaoTituloCentralDeAtendimento();
            McFunctions.SearchHolder(holder);

            McFunctions.WaitForElementLoad(By.Id("listViewMembers"));

            IWebElement holderElement = driver.FindElement(By.Id("listViewMembers")).FindElements(By.Name("Titular"))[0];

            holderElement.Click();

            new Actions(driver).MoveToElement(holderElement).ContextClick(holderElement).Build().Perform();
            driver.FindElement(By.Name("Modalidades")).Click();
            driver.FindElement(By.Name("Nova matrícula")).Click();

            McFunctions.WaitForElementLoad(By.Name(modalityName));
            driver.FindElement(By.Name(modalityName)).Click();

            driver.FindElement(By.Name("Avançar")).Click();
            
            McFunctions.WaitForElementLoad(By.Id("checkBoxFirstMaintenance"));
            driver.FindElement(By.Id("checkBoxFirstMaintenance")).Click();
            driver.FindElement(By.Id("radioButtonMain")).Click();

            McFunctions.WaitForElementLoad(By.Id("buttonOK"));
            driver.FindElement(By.Id("buttonOK")).Click();           
            driver.FindElement(By.Name("Sim")).Click();

            McFunctions.TratarTelaAguarde();

            McFunctions.CashReceiptByBillingGeneration();
            
            McFunctions.AcessarProdutosAReceber();

            new Actions(driver).DoubleClick(driver.FindElement(By.Name(modalityBillingName))).Build().Perform();

            McFunctions.TratarTelaAguarde();
            driver.FindElement(By.Id("buttonOptions")).Click();
            driver.FindElement(By.Name("Detalhar manutenção")).Click();

            McFunctions.WaitForElementLoad(By.Id("listViewDiscounts"));

            bool discountFound = false;
            bool yesterdayDateFound = false;
            foreach (IWebElement i in driver.FindElement(By.Id("listViewDiscounts")).FindElements(By.Id("")))
            {
                if (i.GetAttribute("Name") == "Até " + DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy"))
                {
                    yesterdayDateFound = true;
                }
                if (i.GetAttribute("Name") == "Aplicado")
                {
                    discountFound = true;
                }
            }
            Assert.IsTrue(yesterdayDateFound, "Período de desconto correto");
            Assert.IsTrue(discountFound, "Desconto proporcional aplicado");

            McFunctions.CloseWindow("Manutenção - Detalhe da geração da manutenção");
            McFunctions.CloseWindow("Parcela - Detalhes da parcela e venda");
            McFunctions.CloseWindow("Parcelas - Produtos a receber");

            new Actions(driver).MoveToElement(holderElement).ContextClick(holderElement).Build().Perform();
            driver.FindElement(By.Name("Modalidades")).Click();

            driver.FindElement(By.Name(modalityBillingName + " - " + modalityName)).Click();

            McFunctions.WaitForElementLoad(By.Id("buttonOptions"));
            driver.FindElement(By.Id("buttonOptions")).Click();
            driver.FindElement(By.Name("Cancelar matrícula")).Click();

            foreach (IWebElement i in driver.FindElement(By.Id("listViewParcel")).FindElements(By.Id("")))
            {
                if (i.GetAttribute("ControlType") == "ControlType.CheckBox")
                {
                    i.Click();
                }
            }
            driver.FindElement(By.Id("buttonOK")).Click();
            driver.FindElement(By.Name("Sim")).Click();
            
            McFunctions.TratarTelaAguarde();

            bool remainingRegistration = false;
            new Actions(driver).MoveToElement(holderElement).ContextClick(holderElement).Build().Perform();
            driver.FindElement(By.Name("Modalidades")).Click();
            if (driver.FindElements(By.Name(modalityName)).Count == 0)
            {
                remainingRegistration = true;
            }

            Assert.IsTrue(remainingRegistration, "Matrícula cancelada com sucesso");
            McFunctions.FinalizarAtendimentoTitulo();
            McFunctions.CloseWindow("Central de atendimento");
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            CheckLoginMulticlubes loginMC = new CheckLoginMulticlubes();
            loginMC.VerificarSeMultiClubesEstaAbertoELogado();
            loginMC.CheckMCWindow();
        }

        ////Use TestCleanup para executar código depois de cada execução de teste
        [TestCleanup()]
        public void MyTestCleanup()
        {
            CheckTestTrash McClean = new CheckTestTrash();
            McClean.CheckTestTrashMethod();
        }

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
