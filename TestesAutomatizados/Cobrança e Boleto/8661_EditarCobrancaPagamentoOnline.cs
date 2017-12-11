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
    public class EditarCobrancaPagamentoOnline
    {
        public EditarCobrancaPagamentoOnline()
        {
        }

        [TestMethod]
        public void EditarCobrancaPagamentoOnline_8661()
        {
            string holder = "n/s41344-0";
            string paymentGateway = "Cielo Qa";
            string cardHolderName = "Usuario Teste QA";
            string cardNumber = "4111111111111111";
            string cardValidity = "12/21";
            string securityCode = "123";

            MultiClubesFunctions mcFunctions = new MultiClubesFunctions();
            MultiClubesMenus mcMenus = new MultiClubesMenus();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            mcFunctions.ChangePaymentGateway(paymentGateway);
            
            mcMenus.AcessarMenuOperacaoTituloCentralDeAtendimento();

            mcFunctions.SearchHolder(holder);

            mcFunctions.AcessarCobrancasEditarCobrancas();
            mcFunctions.SearchElementByIdAndClick("linkLabelEdit", true);

            mcFunctions.SearchElementByIdAndClick("comboBoxDunType");
            mcFunctions.SearchElementByNameAndClick("À vista");
            mcFunctions.SearchElementByIdAndClick("buttonOK");
            mcFunctions.CloseWindow("Cobranças do título");
            mcFunctions.AcessarCobrancasEditarCobrancas();
            mcFunctions.SearchElementByIdAndClick("linkLabelEdit");
            mcFunctions.SearchElementByIdAndClick("comboBoxDunType");
            mcFunctions.SearchElementByNameAndClick("Pagamento online");
            mcFunctions.SearchElementByIdAndClick("buttonDetail");

            mcFunctions.SearchElementByIdAndClick("buttonCreditCardEdit");

            mcFunctions.SearchElementByIdAndClick("comboBoxCardType");

            mcFunctions.SearchElementByNameAndClick("Visa");

            mcFunctions.SearchElementByIdAndSendKeys("textBoxCardHolderName", cardHolderName);
            mcFunctions.SearchElementByIdAndSendKeys("textBoxCardNumber", cardNumber);
            mcFunctions.SearchElementByIdAndSendKeys("maskedTextBoxCardValidity", "{HOME}" + cardValidity);
            mcFunctions.SearchElementByIdAndSendKeys("textBoxSecurityCode", securityCode);

            mcFunctions.SearchElementByIdAndClick("buttonOK", true);
            mcFunctions.SearchElementByIdAndClick("buttonOK", true);
            mcFunctions.SearchElementByIdAndClick("buttonOK", true);

            mcFunctions.CloseWindow("Cobranças do título");
            mcFunctions.FinalizarAtendimentoTitulo();
            mcFunctions.CloseWindow("Central de atendimento");
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
