using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <summary>
    /// Summary description for CodedUITest5
    /// </summary>
    [CodedUITest]
    public class EditarCobrancaBoleto
    {
        public EditarCobrancaBoleto()
        {
        }

        [TestMethod]
        public void EditarCobrancaBoleto_10524()
        {
            MultiClubesFunctions mcFunctions = new MultiClubesFunctions();
            MultiClubesMenus mcMenus = new MultiClubesMenus();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            mcMenus.AcessarMenuOperacaoTituloCentralDeAtendimento();

            mcFunctions.SearchHolder("N/S9440-0");

            mcFunctions.AcessarCobrancasEditarCobrancas();
            mcFunctions.SearchElementByIdAndClick("linkLabelEdit", true);

            mcFunctions.SearchElementByIdAndClick("comboBoxDunType", true);
            mcFunctions.SearchElementByNameAndClick("Boleto bancário");
            mcFunctions.SearchElementByIdAndClick("buttonDetail", true);
            mcFunctions.SearchElementByIdAndClick("comboBoxDunInstitution", true);
            mcFunctions.SearchElementByNameAndClick("BANRISUL BOLETO");

            mcFunctions.SearchElementByIdAndClick("buttonOK", true);
            mcFunctions.SearchElementByIdAndClick("buttonOK", true);

            mcFunctions.CloseWindow("Cobranças do título");
            mcFunctions.FinalizarAtendimentoTitulo();
            mcFunctions.CloseWindow("Central de Atendimento");
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
