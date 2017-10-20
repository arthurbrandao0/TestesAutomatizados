using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <resumo>
    /// Descrição resumida para CodedUITest1
    /// </resumo>
    [CodedUITest]
    public class GerarCobrancaEmMassaSemImportacaoDeConsumoTodas6283
    {
        public GerarCobrancaEmMassaSemImportacaoDeConsumoTodas6283()
        {
        }

        //Timeout = 4h (converted in ms)
        [TestMethod(), Timeout(14400000)]
        public void GerarCobrancaEmMassaSemImportacaoDeConsumoTodas6283Metodo()
        {
            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            McMenus.AcessarMenuOperacaoFinanceiroCobrancaGeracaoDeCobranca();
            this.UIMap.VerificarTituloGeracaoCobranca();
            this.UIMap.DesabilitarOpcaoImportarConsumosAte();
            this.UIMap.SelecionarTodasCobrancas();
            this.UIMap.DesabilitarGerarComOpcaoPorCiclo();
            this.UIMap.ClicarBotaoGeracaoCobranca();
            this.UIMap.VerificarTituloGeracaoCobranca();

            Thread.Sleep(60000);
            string helpText = driver.FindElement(By.Id("pictureBox")).GetAttribute("HelpText");
            Console.WriteLine(helpText);

            string initialTime = helpText.Substring(helpText.IndexOf("Início: ")+8, 5);
            Console.WriteLine("Inicio da Geração: {0}", initialTime);

            //validando horas início:
            bool convertHours = int.TryParse(initialTime.Substring(0,2), out int convertedHours);
            Assert.IsTrue(convertHours, "Valor de horas é um número inteiro");
            
            //validando minutos início:
            bool convertMinutes = int.TryParse(initialTime.Substring(3,2), out int convertedMinutes);
            Assert.IsTrue(convertMinutes, "Valor de minutos é um número inteiro");
                       
            string expectedEnd = helpText.Substring(helpText.IndexOf("Término previsto: ") + 18, 5);
            Console.WriteLine("Término Previsto: {0}", expectedEnd);
            bool convertExpectedEnd = int.TryParse(expectedEnd.Substring(3, 2), out int convertedExpectedEnd);
            Assert.IsTrue(convertExpectedEnd, "Valor de minutos é um número inteiro");

            string estimatedDurationMinutes = "";

            if (helpText.IndexOf("hora") > -1)
            {
                string estimatedDurationHours = helpText.Substring(helpText.IndexOf("Duração prevista: ") + 18, 1);
                Console.WriteLine("Duração Prevista Horas: {0} h", estimatedDurationHours);
                bool convertEstimatedTimeHours = int.TryParse(estimatedDurationHours, out int convertedEstimatedTimeHours);
                Assert.IsTrue(convertEstimatedTimeHours, "Valor de horas previstas é um número inteiro");

                estimatedDurationMinutes = helpText.Substring(helpText.IndexOf(" e ") + 3, 2);
                estimatedDurationMinutes = estimatedDurationMinutes.Replace("  ", string.Empty);                
            }
            else if (helpText.IndexOf("minuto") > -1)
            {
                estimatedDurationMinutes = helpText.Substring(helpText.IndexOf("Duração prevista: ") + 18, 2);                
            }

            Console.WriteLine("Duração Prevista Minutos: {0} min", estimatedDurationMinutes);
            bool convertEstimatedMinutes = int.TryParse(estimatedDurationMinutes, out int convertedEstimatedMinutes);
            Assert.IsTrue(convertEstimatedMinutes, "Valor de minutos previstos é um número inteiro");


            string media = helpText.Substring(helpText.IndexOf("Média: ") + 7, 4);
            Console.WriteLine("Média: {0} seg/título", media);
            bool convertAverage = decimal.TryParse(expectedEnd.Substring(3, 2), out decimal convertedAverage);
            Assert.IsTrue(convertExpectedEnd, "Valor de minutos é um número decimal");

            int counter = 0;
            Thread.Sleep(1000);
            while ((driver.FindElements(By.Name("Gerando...")).Count > 0) && (counter < 100) && (driver.FindElements(By.Name("OK")).Count < 1))
            {
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                // Waiting 3 minutes each loop:
                Thread.Sleep(180000);
                counter++;
            }

            Console.WriteLine("Término da geração de cobrança: {0} (margem de erro menor que 5 minutos)", DateTime.Now.ToString("HH:mm"));

            driver.FindElement(By.Name("OK")).Click();
            McFunctions.FecharJanela("Geração de cobrança");
        }
        
        #region Atributos de teste adicionais

        // É possível usar os seguintes atributos adicionais enquanto escreve os testes:

        ////Use TestInitialize para executar código antes de executar cada teste 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            // Para gerar código para este teste, selecione "Gerar Código para Teste de Interface do Usuário Codificado" no menu de atalho e selecione um dos itens do menu.
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
