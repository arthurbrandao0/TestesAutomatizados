using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System;

namespace TestesAutomatizados.Título
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class VenderTituloNoCaixaDefinirValores
    {
        public VenderTituloNoCaixaDefinirValores()
        {
        }

        [TestMethod]
        public void VenderTituloNoCaixaDefinirValores_5590()
        {
            string name = "Sócio criado em " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();
            OpenCash openCash = new OpenCash();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            openCash.OpenCashMethod();

            McMenus.AcessarMenuOperacaoTituloCadastroDeTitulo();

            McFunctions.SearchElementByIdAndClick("comboBoxSalePlan", true, 2);
            McFunctions.SearchElementByNameAndClick("AGE - AGEPES");

            McFunctions.TreatWaitScreen();

            McFunctions.SearchElementByIdAndSendKeys("maskedTextBoxPostalCode", "01311000");

            McFunctions.SearchElementByIdAndClick("buttonSearch");
            McFunctions.TreatWaitScreen();

            McFunctions.SearchElementByIdAndSendKeys("textBoxNumber", "100");

            McFunctions.SearchElementByIdAndClick("buttonOK");

            McFunctions.SearchElementByIdAndSendKeys("textBoxName", name);
            McFunctions.SearchElementByIdAndSendKeys("textBox", "123");
            McFunctions.SearchElementByIdAndClick("buttonOK");

            McFunctions.SearchElementByIdAndSendKeys("numericUpDownParcelQuantity", "10", true, 2);
            McFunctions.SearchElementByIdAndSendKeys("numericUpDownEntranceValue", "10,00", true, 2);
            McFunctions.SearchElementByIdAndClick("radioButtonDiscountPercentage");
            McFunctions.SearchElementByIdAndSendKeys("numericUpDownDiscountPercentage", "10", true, 2);
            McFunctions.SearchElementByIdAndClick("numericUpDownParcelQuantity");

            this.UIMap.VerificarValorDaParcela();
            this.UIMap.VerificarValorTotal();
            this.UIMap.VerificarValorOriginal();

            McFunctions.SearchElementByIdAndClick("buttonCancel");
            McFunctions.SearchElementByNameAndClick("Sim");
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