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
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <summary>
    /// Summary description for CodedUITest5
    /// </summary>
    [CodedUITest]
    public class EditarMensagemInstrucaoEMensagemExternaDeBoletoPendente
    {
        public EditarMensagemInstrucaoEMensagemExternaDeBoletoPendente()
        {
        }

        [TestMethod]
        public void EditarMensagemInstrucaoEMensagemExternaDeBoletoPendente_9078()
        {
            string holder = "A28282";

            string message = "mensagem teste" + DateTime.Now.ToString("_dd_MM_yyyy_HH_mm_ss");
            string instruction = "instrução teste" + DateTime.Now.ToString("_dd_MM_yyyy_HH_mm_ss");
            string externalMessage = "mensagem externa teste" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss");


            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();
            OpenCash openCash = new OpenCash();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            McMenus.AcessarMenuOperacaoTituloCentralDeAtendimento();
            McFunctions.SearchHolder(holder);

            McFunctions.AcessarCobrancasAtivas();

            McFunctions.WaitForElementLoad(By.Id("listViewDun"));
            new Actions(driver).MoveToElement(driver.FindElement(By.Id("listViewDun")).FindElements(By.Id(""))[0]).Build().Perform();
            new Actions(driver).DoubleClick(driver.FindElement(By.Id("listViewDun")).FindElements(By.Id(""))[0]).Build().Perform();

            McFunctions.TratarTelaAguarde();
            McFunctions.SearchElementByIdAndClick("buttonOptions");
            McFunctions.SearchElementByNameAndClick("Boleto");
            McFunctions.SearchElementByNameAndClick("Alterar mensagem");

            McFunctions.ClearTextAreaById("clipboardTextBox");
            McFunctions.SearchElementByIdAndSendKeys("clipboardTextBox", message);

            McFunctions.SearchElementByNameAndClick("Instrução");
            McFunctions.ClearTextAreaById("clipboardTextBox");
            McFunctions.SearchElementByIdAndSendKeys("clipboardTextBox", instruction);

            McFunctions.SearchElementByNameAndClick("Mensagem externa");
            McFunctions.ClearTextAreaById("clipboardTextBox");
            McFunctions.SearchElementByIdAndSendKeys("clipboardTextBox", externalMessage);

            McFunctions.SearchElementByIdAndClick("buttonOK");

            McFunctions.SearchElementByIdAndClick("buttonOptions");
            McFunctions.SearchElementByNameAndClick("Boleto");
            McFunctions.SearchElementByNameAndClick("Alterar mensagem");

            Assert.AreEqual(driver.FindElement(By.Id("clipboardTextBox")).GetAttribute("Name"), message);

            McFunctions.SearchElementByNameAndClick("Instrução");
            Assert.AreEqual(driver.FindElement(By.Id("clipboardTextBox")).GetAttribute("Name"), instruction);

            McFunctions.SearchElementByNameAndClick("Mensagem externa");
            Assert.AreEqual(driver.FindElement(By.Id("clipboardTextBox")).GetAttribute("Name"), externalMessage);

            McFunctions.SearchElementByIdAndClick("buttonOK");

            McFunctions.CloseWindow("Detalhes da cobrança");
            McFunctions.CloseWindow("Cobranças ativas");
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
