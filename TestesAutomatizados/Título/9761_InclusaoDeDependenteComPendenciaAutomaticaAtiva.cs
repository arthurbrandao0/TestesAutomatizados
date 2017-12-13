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

namespace TestesAutomatizados.Título
{
    /// <summary>
    /// Summary description for CodedUITest2
    /// </summary>
    [CodedUITest]
    public class InclusaoDeDependenteComPendenciaAutomaticaAtiva
    {
        public InclusaoDeDependenteComPendenciaAutomaticaAtiva()
        {
        }

        [TestMethod]
        public void InclusaoDeDependenteComPendenciaAutomaticaAtiva_9761()
        {
            MultiClubesFunctions mcFunctions = new MultiClubesFunctions();
            MultiClubesMenus mMcMenus = new MultiClubesMenus();
            OpenCash openCash = new OpenCash();
            openCash.OpenCashMethod();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            string dependentName = "Dependente criado em " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            mcFunctions.AcessarCentralDeAtendimento();
            mcFunctions.SearchHolder("age0399");

            mcFunctions.SearchElementByNameAndClick("Título", true);

            mcFunctions.SearchElementByIdAndClick("sideButtonNewMember", true);

            mcFunctions.SearchElementByIdAndSendKeys("textBoxName", dependentName, true);
            mcFunctions.SearchElementByIdAndClick("comboBoxParentage");
            mcFunctions.SearchElementByNameAndClick("Nora");
            mcFunctions.SearchElementByIdAndSendKeys("textBox", "123");
            mcFunctions.SearchElementByIdAndClick("buttonOK");

            mcFunctions.WaitForElementLoad(By.Id("labelWarning"));

            bool foundText = driver.FindElement(By.Id("labelWarning")).GetAttribute("Name").Contains("Cadastro de dependente local");

            IWebElement holderElement = driver.FindElement(By.Name("Dependente"));

            holderElement.Click();
            new Actions(driver).MoveToElement(holderElement).ContextClick(holderElement).Build().Perform();

            mcFunctions.SearchElementByNameAndClick("Status", true);
            mcFunctions.SearchElementByNameAndClick("Excluir", true);
            mcFunctions.SearchElementByNameAndClick("Sim", true);
            mcFunctions.SearchElementByNameAndClick("OK", true);

            mcFunctions.FinalizarAtendimentoTitulo();
            mcFunctions.CloseWindow();

            Assert.IsTrue(foundText, "Texto \"Cadastro de dependente local\" presente na \"labelWarning\"");
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
