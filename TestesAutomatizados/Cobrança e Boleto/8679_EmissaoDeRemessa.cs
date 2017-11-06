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
using System.IO;

namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <summary>
    /// Summary description for CodedUITest5
    /// </summary>
    [CodedUITest]
    public class EmissaoDeRemessa
    {
        public EmissaoDeRemessa()
        {
        }

        [TestMethod]
        public void EmissaoDeRemessa_8679()
        {
            MultiClubesFunctions mcFunctions = new MultiClubesFunctions();
            MultiClubesMenus mcMenus = new MultiClubesMenus();

            string folderPath = "C:/TestesAutomatizados/TestResults";
            string fileName = "REMESSA" + DateTime.Now.ToString("_dd_MM_yyyy_HH_mm_ss") + ".rem";
            string filePath = folderPath + "/" + fileName;

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            mcMenus.AcessarMenuOperacaoFinanceiroTransacoesBancariasEmissaoDeRemessa();

            
            mcFunctions.SearchElementByIdAndClick("comboBoxDunInstitution", true);
            mcFunctions.SearchElementByNameAndClick("BANRISUL BOLETO");

            mcFunctions.SearchElementByIdAndClick("comboBoxRemittanceType");
            mcFunctions.SearchElementByNameAndClick("Impressão");

            mcFunctions.SearchElementByIdAndSendKeys("textBoxFileName", filePath);

            mcFunctions.SearchElementByIdAndClick("buttonOK");
            mcFunctions.SearchElementByNameAndClick("Sim", true);

            bool finishedRemittance = false;
            if (driver.FindElements(By.Name("Erro")).Count == 1)
            {
                mcFunctions.WaitForElementLoad(By.Name("Concluído"));
                if (driver.FindElements(By.Name("Concluído")).Count > 0)
                {
                    finishedRemittance = true;
                }
            }
            else
            {
                Assert.Fail(driver.FindElement(By.Id("ContentText")).GetAttribute("Name"));
            }
            Assert.IsTrue(finishedRemittance, "Gerou a cobrança com sucesso");
            Assert.IsTrue(File.Exists(filePath), "Arquivo criado com sucesso");

            mcFunctions.SearchElementByIdAndClick("buttonOK");
            mcFunctions.CloseWindow("Emissão de remessa");
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
