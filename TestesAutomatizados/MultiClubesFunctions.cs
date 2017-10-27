using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace TestesAutomatizados
{

    /// <resumo>
    /// Descrição resumida para CodedUITest1
    /// </resumo>
    [CodedUITest]
    public class MultiClubesFunctions
    {
        public MultiClubesFunctions()
        {
            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);

            driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);
        }
                
        public void AcessarCentralDeAtendimento()
        {
            driver.FindElement(By.Name("Operação")).Click();
            driver.FindElement(By.Name("Título")).Click();
            driver.FindElement(By.Name("Central de atendimento")).Click();
        }

        public void CloseWindow(string windowName = "")
        {
            // o parametro 'WindowName' nao altera em nada a função, apenas facilita a identificação da tela em que o mesmo atua.
            driver.FindElementByName("Fechar").Click();
        }

        public void FinalizarAtendimentoTitulo()
        {
            WaitForElementLoad(By.Name("Fechar"));
            driver.FindElement(By.Name("Fechar")).Click();
            WaitForElementLoad(By.Id("buttonOK"));
            driver.FindElement(By.Id("buttonOK")).Click();
        }

        public void TratarTelaAguarde()
        {
            int counter = 0;
            Thread.Sleep(250);
            while ((driver.FindElements(By.Name("Aguarde...")).Count > 0) && counter < 60)
            {
                Thread.Sleep(250);
                counter++;
            }
        }

        public void ClicarBotaoFechar()
        {
            Thread.Sleep(500);
            driver.FindElementById("Close").Click();
        }

        public void AcessarProdutosAReceber()
        {
            driver.FindElement(By.Name("A receber")).Click();
        }

        public void AcessarCobrancas()
        {
            driver.FindElement(By.Name("Cobranças")).FindElement(By.Id("headerButton")).Click();
        }

        public void AcessarCobrancasAtivas()
        {
            AcessarCobrancas();
            driver.FindElement(By.Name("Ativas")).Click();
        }

        public void AcessarCobrancasEditarCobrancas()
        {
            AcessarCobrancas();
            driver.FindElement(By.Name("Editar cobranças")).Click();
        }

        public void WaitForElementLoad(By by, int attempts = 20)
        {
            int counter = 0;
            while ((driver.FindElement(By.Id("FormMain")).FindElements(by).Count == 0) && counter < attempts)
            {
                Thread.Sleep(100);
                Console.WriteLine("passando pelo loop WaitForElementLoad: {0}", by);
                counter++;
            }
        }

        public void CheckBillingForecast()
        {
            WaitForElementLoad(By.Id("pictureBox"));
            string helpText = driver.FindElement(By.Id("pictureBox")).GetAttribute("HelpText");
            while (helpText.Contains("calculando"))
            {
                Thread.Sleep(3000);
                Console.WriteLine("Aguardando cálculo do tempo estimado em {0}", DateTime.Now.ToString("HH:mm:ss"));
                helpText = driver.FindElement(By.Id("pictureBox")).GetAttribute("HelpText");
            }
            Console.WriteLine(helpText);

            string initialTime = helpText.Substring(helpText.IndexOf("Início: ") + 8, 5);
            Console.WriteLine("Inicio da Geração: {0}", initialTime);

            //validando horas início:
            bool convertHours = int.TryParse(initialTime.Substring(0, 2), out int convertedHours);
            Assert.IsTrue(convertHours, "Valor de horas é um número inteiro");

            //validando minutos início:
            bool convertMinutes = int.TryParse(initialTime.Substring(3, 2), out int convertedMinutes);
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
        }

        public void WaitBillingGeneration()
        {
            int counter = 0;
            Thread.Sleep(1000);
            while ((driver.FindElements(By.Name("Gerando...")).Count > 0) && (driver.FindElements(By.Name("OK")).Count < 1) && (counter < 100))
            {
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                // Waiting 3 minutes:
                Thread.Sleep(180000);
                counter++;
            }

            Console.WriteLine("Término da geração de cobrança: {0} (margem de erro menor que 5 minutos)", DateTime.Now.ToString("HH:mm"));

            driver.FindElement(By.Name("OK")).Click();
            CloseWindow("Geração de cobrança");
        }

        public void SearchHolder(string HolderId) { 
            WaitForElementLoad(By.Id("textBoxKeyword"));
            driver.FindElement(By.Id("textBoxKeyword")).Click();
            Keyboard.SendKeys(HolderId);
            Keyboard.SendKeys("{Enter}");
            WaitForElementLoad(By.Name("Titular"));
            new Actions(driver).DoubleClick(driver.FindElement(By.Name("Titular"))).Build().Perform();
        }
        public void BillingRemittanceFiles()
        {
            WaitForElementLoad(By.Id("linkLabelDun"));
            driver.FindElement(By.Id("linkLabelDun")).Click();

            WaitForElementLoad(By.Id("buttonOptions"));
            driver.FindElement(By.Id("buttonOptions")).Click();
            driver.FindElement(By.Name("Editar arquivos remessa")).Click();
                       
        }

        public void CashReceiptByBillingGeneration()
        {
            driver.FindElement(By.Name("tabPageCash")).Click();
            if (driver.FindElements(By.Name("Caixa fechado")).Count == 1)
            {
                OpenCash openCash = new OpenCash();
                openCash.OpenCashMethod();
            }
            WaitForElementLoad(By.Id("buttonReceive"));
            driver.FindElement(By.Id("buttonReceive")).Click();

            driver.FindElement(By.Name("Gerar cobrança")).Click();

            WaitForElementLoad(By.Id("radioButtonMain"));
            driver.FindElement(By.Id("radioButtonMain")).Click();

            TratarTelaAguarde();
            driver.FindElement(By.Id("buttonOK")).Click();

            TratarTelaAguarde();
            driver.FindElement(By.Name("OK")).Click();
        }
        public void ChangePaymentGateway(string paymentGateway)
        {
            MultiClubesMenus mcMenus = new MultiClubesMenus();

            mcMenus.AcessarMenuAdministracaoConfiguracoes();

            TratarTelaAguarde();

            Keyboard.SendKeys("{END}");

            new Actions(driver).MoveToElement(driver.FindElement(By.Name("Regras de pagamento"))).Click(driver.FindElement(By.Name("Regras de pagamento"))).Build().Perform();
            driver.FindElement(By.Id("linkLabelDefaultEcommerce")).Click();

            WaitForElementLoad(By.Id("comboBoxGateway"));

            driver.FindElement(By.Id("comboBoxGateway")).Click();
            driver.FindElement(By.Name(paymentGateway)).Click();

            IWebElement firstCheckbox = driver.FindElement(By.Id("controlCreditCardSelect")).FindElements(By.Id(""))[0];

            new Actions(driver).MoveToElement(firstCheckbox).ContextClick(firstCheckbox).Build().Perform();

            driver.FindElement(By.Name("Todos")).Click();

            driver.FindElement(By.Id("buttonOK")).Click();
            driver.FindElement(By.Id("buttonOK")).Click();

            TratarTelaAguarde();
        }
        public void searchElementByIdAndClick(string idElement)
        {
            driver.FindElement(By.Id(idElement)).Click();
        }
        public void searchElementByIdAndSendKeys(string idElement, string keysToSend)
        {
            searchElementByIdAndClick(idElement);
            Keyboard.SendKeys(keysToSend);
        }
        #region Atributos de teste adicionais

        // É possível usar os seguintes atributos adicionais enquanto escreve os testes:

        ////Use TestInitialize para executar código antes de executar cada teste 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // Para gerar código para este teste, selecione "Gerar Código para Teste de Interface do Usuário Codificado" no menu de atalho e selecione um dos itens do menu.
        //}

        ////Use TestCleanup para executar código depois de cada execução de teste
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // Para gerar código para este teste, selecione "Gerar Código para Teste de Interface do Usuário Codificado" no menu de atalho e selecione um dos itens do menu.
        //}

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
        private RemoteWebDriver driver;


    }
}
