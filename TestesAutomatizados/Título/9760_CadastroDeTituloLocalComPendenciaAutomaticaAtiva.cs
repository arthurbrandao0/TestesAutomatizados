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
    /// Summary description for CodedUITest2
    /// </summary>
    [CodedUITest]
    public class CadastroDeTituloLocalComPendenciaAutomaticaAtiva
    {
        public CadastroDeTituloLocalComPendenciaAutomaticaAtiva()
        {
        }

        [TestMethod]
        public void CadastroDeTituloLocalComPendenciaAutomaticaAtiva_9760()
        {
            MultiClubesFunctions mcFunctions = new MultiClubesFunctions();
            MultiClubesMenus mMcMenus = new MultiClubesMenus();
            OpenCash openCash = new OpenCash();
            openCash.OpenCashMethod();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            string name = "Sócio criado em " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            mMcMenus.AcessarMenuOperacaoTituloCadastroDeTitulo();

            mcFunctions.SearchElementByIdAndClick("comboBoxSalePlan");
            mcFunctions.SearchElementByNameAndClick("AGE - AGEPES 2");

            mcFunctions.SearchElementByIdAndSendKeys("maskedTextBoxPostalCode", "01311000");

            mcFunctions.SearchElementByIdAndClick("buttonSearch");

            mcFunctions.SearchElementByIdAndSendKeys("textBoxNumber", "100", true);

            mcFunctions.SearchElementByIdAndClick("buttonOK");

            mcFunctions.SearchElementByIdAndSendKeys("textBoxName", name);

            mcFunctions.SearchElementByIdAndClick("buttonChangeDocumentType");
            mcFunctions.SearchElementByNameAndClick("Outro");

            mcFunctions.SearchElementByIdAndSendKeys("textBox", "123{TAB}321");
            mcFunctions.SearchElementByIdAndClick("buttonOK");

            if (driver.FindElements(By.Name("Duplicidade de sócio")).Count > 0)
            {
                mcFunctions.SearchElementByIdAndClick("buttonOK");
            }

            mcFunctions.SearchElementByIdAndClick("comboBoxDunType");
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

            mcFunctions.SearchElementByIdAndSendKeys("comboBoxCycle", "{TAB}123{TAB}1{TAB}321{TAB}2");
            
            mcFunctions.SearchElementByIdAndSendKeys("textBoxDueDay", "5");

            mcFunctions.SearchElementByIdAndClick("buttonOK", true);
            mcFunctions.SearchElementByIdAndClick("buttonFinalize");
            mcFunctions.SearchElementByNameAndClick("Sim", true);

            mcFunctions.SearchElementByIdAndClick("buttonService", true);

            mcFunctions.WaitForElementLoad(By.Id("labelWarning"));

            mcFunctions.WaitForElementLoad(By.Id("labelWarning"));
            Assert.IsTrue(driver.FindElement(By.Id("labelWarning")).GetAttribute("Name").Contains("Cadastro de título local"), "Texto \"Cadastro de título local\" presente na \"labelWarning\"");

            mcFunctions.WaitForElementLoad(By.Name("Fechar"));
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
