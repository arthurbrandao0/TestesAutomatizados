using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
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

            mcMenus.AcessarMenuOperacaoFinanceiroTransacoesBancariasRemessasAnteriores();
            mcFunctions.WaitForElementLoad(By.Id("listView"));
            driver.FindElement(By.Id("listView")).FindElements(By.Id(""))[0].Click();
            
            driver.FindElement(By.Id("buttonOptions")).Click();
            driver.FindElement(By.Name("Desfazer")).Click();
            mcFunctions.TratarTelaAguarde();
            driver.FindElement(By.Name("Sim")).Click();
            mcFunctions.WaitForElementLoad(By.Id("OPERATION_FINANCIAL+BANK+REMITTANCE_HISTORY"), 2);
            mcFunctions.CloseWindow("Remessas anteriores", "OPERATION_FINANCIAL+BANK+REMITTANCE_HISTORY");

            mcMenus.AcessarMenuOperacaoFinanceiroTransacoesBancariasEmissaoDeRemessa();
                        
            mcFunctions.SearchElementByIdAndClick("comboBoxDunInstitution", true);
            mcFunctions.SearchElementByNameAndClick("BANRISUL BOLETO");

            mcFunctions.SearchElementByIdAndClick("comboBoxRemittanceType");
            mcFunctions.SearchElementByNameAndClick("Impressão");

            mcFunctions.SearchElementByIdAndSendKeys("textBoxFileName", filePath);

            mcFunctions.SearchElementByIdAndClick("buttonOK");
            mcFunctions.SearchElementByNameAndClick("Sim", true);

            bool finishedRemittance = false;
            if (driver.FindElements(By.Name("Erro")).Count > 0)
            {
                Assert.Fail(driver.FindElement(By.Id("ContentText")).GetAttribute("Name"));
            }
            else if (driver.FindElements(By.Name("Concluído")).Count > 0)
            {
                finishedRemittance = true;
            }
            Assert.IsTrue(finishedRemittance, "Gerou a cobrança com sucesso");
            Assert.IsTrue(File.Exists(filePath), "Arquivo criado com sucesso");

            mcFunctions.SearchElementByIdAndClick("buttonOK");
            mcFunctions.CloseWindow("Emissão de remessa", "OPERATION_FINANCIAL+BANK+REMITTANCE_GENERATION");
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
