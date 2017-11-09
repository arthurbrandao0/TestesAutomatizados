using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestesAutomatizados.Plano_de_Venda
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CriarPlanoDeVenda
    {
        public CriarPlanoDeVenda()
        {
        }

        [TestMethod]
        public void CriarPlanoDeVenda_10720()
        {
            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();

            string planName = "Plano de venda criado em " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");


            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            McMenus.AcessarMenuAdministracaoFinanceiroPlanosDeVendaPlanos();

            driver.FindElement(By.Id("treeView")).FindElement(By.Name("Título local")).Click();

            IWebElement listViewElement = driver.FindElement(By.Id("listView"));
            new Actions(driver).MoveToElement(listViewElement).ContextClick(listViewElement).Build().Perform();
            driver.FindElement(By.Name("Incluir")).Click();

            McFunctions.TreatWaitScreen();

            McFunctions.WaitForElementLoad(By.Id("textBoxName"), 2);
            McFunctions.SearchElementByIdAndSendKeys("textBoxName", planName);

            driver.FindElement(By.Id("comboBoxTitleType")).Click();
            driver.FindElement(By.Name("AA - Teste")).Click();
            
            driver.FindElement(By.Id("comboBoxTitleCodeSequence")).Click();
            driver.FindElement(By.Name("AE")).Click();

            McFunctions.SearchElementByNameAndClick("Venda");
            
            driver.FindElement(By.Id("comboBoxProduct")).Click();
            driver.FindElement(By.Name("Título A")).Click();

            driver.FindElement(By.Id("comboBoxDunInstitution")).Click();
            driver.FindElement(By.Name("BRADESCO BOLETO MULTICLUBES")).Click();

            McFunctions.SearchElementByIdAndClick("buttonOK");
            McFunctions.TreatWaitScreen();

            bool createdPlan = false;
            if (listViewElement.FindElements(By.Name(planName)).Count > 0)
            {
                createdPlan = true;
            }

            McFunctions.CloseWindow("Planos de venda");

            Assert.IsTrue(createdPlan, "Plano criado");
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
            //McClean.CheckTestTrashMethod();
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
