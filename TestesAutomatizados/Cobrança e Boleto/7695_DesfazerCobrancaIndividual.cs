using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;

namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }

        [TestMethod]
        public void DesfazerCobrancaIndividual_Metodo()
        {
            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            McMenus.AcessarMenuOperacaoTituloCentralDeAtendimento();
            McFunctions.SearchHolder("A28248");

            McFunctions.AcessarCobrancasAtivas();
            
            McFunctions.WaitForElementLoad(By.Id("listViewYear"));
            driver.FindElement(By.Id("listViewYear")).FindElements(By.Id(""))[0].Click();
            
            McFunctions.WaitForElementLoad(By.Id("listViewDun"));
            var listViewDunElements = driver.FindElement(By.Id("listViewDun")).FindElements(By.Id(""));

            int counter = 0;
            foreach (IWebElement i in listViewDunElements)
            {
                if (i.GetAttribute("Name") == "")
                {
                    break;
                }
                counter++;
            }
            string billing = listViewDunElements[counter - 4].GetAttribute("Name");
            Console.WriteLine(billing);
            listViewDunElements[counter - 4].Click();

            new Actions(driver).DoubleClick(listViewDunElements[counter - 4]).Build().Perform();
            
            McFunctions.WaitForElementLoad(By.Id("buttonOptions"));
            driver.FindElement(By.Id("buttonOptions")).Click();

            driver.FindElement(By.Name("Desfazer cobrança")).Click();
            driver.FindElement(By.Name("Sim")).Click();

            McFunctions.WaitForElementLoad(By.Name("OK"));
            driver.FindElement(By.Name("OK")).Click();

            bool undoneBilling = true;
            if (driver.FindElement(By.Id("listViewDun")).FindElements(By.Name(billing)).Count > 0)
            {
                undoneBilling = false;
            }
            
            McFunctions.WaitForElementLoad(By.Name("Cobranças ativas"));
            McFunctions.CloseWindow("Cobranças ativas");
            McFunctions.FinalizarAtendimentoTitulo();
            McFunctions.CloseWindow("Central de atendimento");

            Assert.IsTrue(undoneBilling, "Cobrança desfeita");
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
