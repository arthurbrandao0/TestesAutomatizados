using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;

namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <resumo>
    /// Descrição resumida para CodedUITest1
    /// </resumo>
    [CodedUITest]
    public class EditarCobrancaDebitoEmConta6442
    {
        public EditarCobrancaDebitoEmConta6442()
        {
        }

        [TestMethod]
        public void EditarCobrancaDebitoEmConta_6442()
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
            //driver.FindElement(By.Id("linkLabelEdit")).Click();

            mcFunctions.SearchElementByIdAndClick("comboBoxDunType", true);
            mcFunctions.SearchElementByNameAndClick("À vista");
            mcFunctions.SearchElementByIdAndClick("buttonOK", true);
            mcFunctions.CloseWindow("Cobranças do título");
            //---
            mcFunctions.AcessarCobrancasEditarCobrancas();

            mcFunctions.SearchElementByIdAndClick("linkLabelEdit", true);
            //driver.FindElement(By.Id("linkLabelEdkit")).Click();

            mcFunctions.SearchElementByIdAndClick("comboBoxDunType", true);
            mcFunctions.SearchElementByNameAndClick("Débito em conta");
            mcFunctions.SearchElementByIdAndClick("buttonDetail");

            // Instituição de cobrança
            mcFunctions.SearchElementByIdAndClick("comboBoxDunInstitution", true);
            string instituition = "BANCO DO BRASIL DEBITO AUTOMATICO";
            mcFunctions.SearchElementByNameAndClick(instituition);

            // Ciclo
            mcFunctions.SearchElementByIdAndClick("comboBoxCycle", true);
            string cycle = "Mensal";
            mcFunctions.SearchElementByNameAndClick(cycle);

            // Agencia e dígito
            //textBoxCode
            //textBoxDigit

            // Conta e dígito
            //textBoxCode
            //textBoxDigit

            // Dia vencimento
            //IWebElement boxDueDay = driver.FindElement(By.Id("textBoxDueDay"));
            //boxDueDay.Clear();
            //boxDueDay.Click();
            //Keyboard.SendKeys("5");

            mcFunctions.SearchElementByIdAndSendKeys("textBoxDueDay", "5");

            mcFunctions.SearchElementByIdAndClick("buttonOK", true);
            mcFunctions.SearchElementByIdAndClick("buttonOK", true);
            mcFunctions.CloseWindow("Cobranças do título");

            Assert.AreEqual(driver.FindElement(By.Id("labelDunModeValue")).GetAttribute("Name"), instituition + " " + cycle.ToLower(), "Verificando se o campo Cobrança presente no título informa os valores escolhidos.");

            mcFunctions.FinalizarAtendimentoTitulo();
            mcFunctions.CloseWindow("Central de Atendimento");
        }

        #region Atributos de teste adicionais

        ////Use TestInitialize para executar código antes de executar cada teste 
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

        /// <resumo>
        ///Obtém ou define o contexto do teste que provê
        ///informação e funcionalidade da execução de teste atual.
        ///</resumo>
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
