using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;

namespace TestesAutomatizados.Plano_de_Venda
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CancelarEdicaoDePlanoDeVenda
    {
        public CancelarEdicaoDePlanoDeVenda()
        {
        }

        [TestMethod]
        public void CancelarEdicaoDePlanoDeVenda_7502()
        {
            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();

            string ocupationMapName = "Mapa de ocupação criado em " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            McMenus.AcessarMenuAdministracaoFinanceiroPlanosDeVendaPlanos();

            driver.FindElement(By.Id("treeView")).FindElement(By.Name("Ingresso online individual")).Click();
            McFunctions.TreatWaitScreen();

            IWebElement listViewElement = driver.FindElement(By.Id("listView")).FindElement(By.Name(".Ingresso Teste"));
            new Actions(driver).MoveToElement(listViewElement).ContextClick(listViewElement).Build().Perform();
            driver.FindElement(By.Name("Editar")).Click();



            McFunctions.SearchElementByIdAndClick("buttonCancel");
            McFunctions.TreatWaitScreen();

            Assert.AreEqual(driver.FindElements(By.Id("FormSalePlanOnlineEdit")).Count, 0, "Janela fechada");

            McFunctions.CloseWindow("Planos de venda");
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
