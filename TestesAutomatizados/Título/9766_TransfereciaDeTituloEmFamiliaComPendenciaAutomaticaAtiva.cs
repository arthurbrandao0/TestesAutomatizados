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
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace TestesAutomatizados.Título
{
    /// <summary>
    /// Summary description for CodedUITest2
    /// </summary>
    [CodedUITest]
    public class TransfereciaDeTituloEmFamiliaComPendenciaAutomaticaAtiva
    {
        public TransfereciaDeTituloEmFamiliaComPendenciaAutomaticaAtiva()
        {
        }

        [TestMethod]
        public void TransfereciaDeTituloEmFamiliaComPendenciaAutomaticaAtiva_9766()
        {
            MultiClubesFunctions mcFunctions = new MultiClubesFunctions();
            MultiClubesMenus mcMenus = new MultiClubesMenus();
            OpenCash openCash = new OpenCash();
            openCash.OpenCashMethod();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            string dependentName = "Sócio criado em " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            mcMenus.AcessarMenuAdministracaoTituloPendencias();
            mcFunctions.SearchElementByNameAndClick("Título");

            mcFunctions.SearchElementByNameAndRightClick("Transferência de título");

            if (driver.FindElements(By.Name("Ativar")).Count > 0)
            {
                mcFunctions.SearchElementByNameAndClick("Ativar");
            }

            mcFunctions.CloseWindow("Pendências");

            mcFunctions.AcessarCentralDeAtendimento();
            mcFunctions.SearchHolder("age0397");

            mcFunctions.SearchElementByNameAndClick("Título", true);

            mcFunctions.SearchElementByIdAndClick("sideButtonNewMember", true);

            mcFunctions.SearchElementByIdAndSendKeys("textBoxName", dependentName, true);
            mcFunctions.SearchElementByIdAndClick("comboBoxParentage");
            mcFunctions.SearchElementByNameAndClick("Parentesco Teste Automatizado");
            mcFunctions.SearchElementByIdAndSendKeys("textBox", "123");
            mcFunctions.SearchElementByIdAndClick("buttonOK");

            mcFunctions.WaitForElementLoad(By.Id("LargeIncrement"));
            driver.FindElement(By.Id("sideBar")).FindElement(By.Id("LargeIncrement")).Click();

            mcFunctions.SearchElementByIdAndClick("sideButtonTransferTitle", true);
            mcFunctions.SearchElementByIdAndClick("radioButtonFamily", true);
            mcFunctions.SearchElementByIdAndClick("comboBoxProduct");
            mcFunctions.SearchElementByNameAndClick("Transferencia sem custo");

            mcFunctions.SearchElementByIdAndClick("buttonOK");

            mcFunctions.SearchElementByIdAndClick("comboBoxMember", true);
            mcFunctions.SearchElementByNameAndClick(dependentName);
            mcFunctions.SearchElementByIdAndClick("buttonAdvance");
            mcFunctions.SearchElementByNameAndClick("Sim", true);
            mcFunctions.SearchElementByNameAndClick("OK", true);

            IWebElement holderElement = driver.FindElement(By.Name("Dependente"));

            holderElement.Click();
            new Actions(driver).MoveToElement(holderElement).ContextClick(holderElement).Build().Perform();

            mcFunctions.SearchElementByNameAndClick("Status", true);
            mcFunctions.SearchElementByNameAndClick("Ativar", true);
            mcFunctions.SearchElementByNameAndClick("OK", true);

            holderElement.Click();
            new Actions(driver).MoveToElement(holderElement).ContextClick(holderElement).Build().Perform();

            mcFunctions.SearchElementByNameAndClick("Status", true);
            mcFunctions.SearchElementByNameAndClick("Excluir", true);
            mcFunctions.SearchElementByNameAndClick("Sim", true);
            mcFunctions.SearchElementByNameAndClick("OK", true);

            mcFunctions.FinalizarAtendimentoTitulo();
            mcFunctions.CloseWindow();
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
