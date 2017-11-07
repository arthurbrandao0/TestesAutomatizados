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
using System.Threading;

namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <resumo>
    /// Descrição resumida para CodedUITest1
    /// </resumo>
    [CodedUITest]
    public class SimulacaodeGeracaodeCobrancaTodas6387
    {
        public SimulacaodeGeracaodeCobrancaTodas6387()
        {
        }

        [TestMethod]
        public void SimulacaodeGeracaodeCobrancaTodas_6387()
        {
            MultiClubesFunctions mcFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);
            
            McMenus.AcessarMenuOperacaoFinanceiroCobrancaSimulacaoDeCobranca();

            
            mcFunctions.WaitForElementLoad(By.Id("buttonSimulate"));
            driver.FindElement(By.Id("buttonSimulate")).Click();

            mcFunctions.WaitForElementLoad(By.Name("Sim"));
            driver.FindElement(By.Name("Sim")).Click();

            mcFunctions.CheckBillingForecast();
            
            int counter = 0;
            Thread.Sleep(1000);
            while ((driver.FindElements(By.Name("Simulando...")).Count > 0) && (driver.FindElements(By.Name("OK")).Count < 1) && (counter < 100))
            {
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                // Waiting 3 minutes:
                Thread.Sleep(180000);
                counter++;
            }

            Console.WriteLine("Término da simulação de cobrança: {0} (margem de erro menor que 5 minutos)", DateTime.Now.ToString("HH:mm"));

            driver.FindElement(By.Name("OK")).Click();

            mcFunctions.CloseWindow();
        }

        #region Atributos de teste adicionais

        // É possível usar os seguintes atributos adicionais enquanto escreve os testes:

        ////Use TestInitialize para executar código antes de executar cada teste 
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
