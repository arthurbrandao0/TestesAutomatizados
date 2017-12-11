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

            new Actions(driver).MoveToElement(driver.FindElement(By.Name("Modalidades"))).Click(driver.FindElement(By.Name("Modalidades"))).Build().Perform();
            
            driver.FindElement(By.Name("Modalidades")).FindElement(By.Name("Nova matrícula")).Click();

            McFunctions.SearchElementByNameAndClick(modalityName, true);

            McFunctions.SearchElementByNameAndClick("Avançar");
            
            McFunctions.SearchElementByIdAndClick("checkBoxFirstMaintenance", true);

            McFunctions.SearchElementByIdAndClick("radioButtonMain");

            McFunctions.SearchElementByIdAndClick("buttonOK", true);

            McFunctions.SearchElementByNameAndClick("Sim");
            
            McFunctions.CashReceiptByBillingGeneration();
            
            McFunctions.AcessarProdutosAReceber();

            McFunctions.WaitForElementLoad(By.Id("listViewYear"));
            driver.FindElement(By.Id("listViewYear")).FindElements(By.Id(""))[0].Click();

            McFunctions.WaitForElementLoad(By.Id("listViewParcel"), 60);

            IWebElement billingName = driver.FindElement(By.Name(modalityBillingName));

            new Actions(driver).MoveToElement(billingName).DoubleClick(billingName).Build().Perform();

            McFunctions.SearchElementByIdAndClick("buttonOptions", true);
            McFunctions.SearchElementByNameAndClick("Detalhar manutenção");
            
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
            McFunctions.SearchElementByNameAndClick("Modalidades");

            driver.FindElement(By.Name(modalityBillingName + " - " + modalityName)).Click();

            McFunctions.SearchElementByIdAndClick("buttonOptions");

            McFunctions.SearchElementByNameAndClick("Cancelar matrícula");

            McFunctions.WaitForElementLoad(By.Id("listViewParcel"));
            foreach (IWebElement i in driver.FindElement(By.Id("listViewParcel")).FindElements(By.Id("")))
            {
                if (i.GetAttribute("ControlType") == "ControlType.CheckBox")
                {
                    i.Click();
                }
            }
            McFunctions.SearchElementByIdAndClick("buttonOK");
            McFunctions.SearchElementByNameAndClick("Sim");
            
            McFunctions.TreatWaitScreen();

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
