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

namespace TestesAutomatizados.Título
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class VendaDeTituloPorBoleto
    {
        public VendaDeTituloPorBoleto()
        {
        }

        [TestMethod]
        public void VendaDeTituloPorBoleto_7221()
        {
            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();
            OpenCash openCash = new OpenCash();
            openCash.OpenCashMethod();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            string name = "Sócio criado em " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string planName = "Gratuito";

            McMenus.AcessarMenuOperacaoTituloCadastroDeTitulo();

            McFunctions.SearchElementByIdAndClick("comboBoxSalePlan");
            McFunctions.SearchElementByNameAndClick("AGE - AGEPES");

            McFunctions.SearchElementByIdAndSendKeys("maskedTextBoxPostalCode", "01311000", true);

            McFunctions.SearchElementByIdAndClick("buttonSearch");

            McFunctions.SearchElementByIdAndSendKeys("textBoxNumber", "100", true);

            McFunctions.SearchElementByIdAndClick("buttonOK");

            McFunctions.SearchElementByIdAndSendKeys("textBoxName", name);
            McFunctions.SearchElementByIdAndSendKeys("textBox", "123");
            McFunctions.SearchElementByIdAndClick("buttonOK");

            McFunctions.SearchElementByIdAndClick("buttonFinalize", true);
            McFunctions.SearchElementByNameAndClick("Sim", true);

            McFunctions.SearchElementByIdAndClick("buttonService", true);

            McFunctions.AcessarProdutosAReceber();

            McFunctions.WaitForElementLoad(By.Id("listViewParcel"), 2);

            var listViewParcelElements = driver.FindElement(By.Id("listViewParcel")).FindElements(By.Id(""));

            Assert.AreEqual(planName, listViewParcelElements[0].GetAttribute("Name"));
            Assert.IsNotNull(listViewParcelElements[6].GetAttribute("Name"));

            McFunctions.CloseWindow("Parcelas");
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
