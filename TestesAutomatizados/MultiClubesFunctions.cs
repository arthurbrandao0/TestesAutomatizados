﻿using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
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

        public void FecharJanela(string windowName = "")
        {
            // o parametro 'WindowName' nao altera em nada a função, apenas facilita a identificação da tela em que o mesmo atua.
            driver.FindElementByName("Fechar").Click();
        }

        public void FinalizarAtendimentoTitulo()
        {
            driver.FindElement(By.Name("Fechar")).Click();
            try
            {
                Thread.Sleep(2000);
                driver.FindElement(By.Id("buttonOK")).Click();
            }
            catch {
                Console.WriteLine("Atendimento finalizado sem necessidade de apertar ok");
            }
        }

        public void TratarTelaAguarde()
        {
            int counter = 0;
            Thread.Sleep(1000);
            while ((driver.FindElements(By.Name("Aguarde...")).Count > 0) && counter < 60)
            {
                Thread.Sleep(500);
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
            //this.UIMap.AcessarProdutosAReceber();
            driver.FindElement(By.Name("A receber")).Click();
        }

        public void AcessarCobrancasAtivas()
        {
            driver.FindElement(By.Name("Cobranças")).FindElement(By.Id("headerButton")).Click();
            driver.FindElement(By.Name("Ativas")).Click();
        }

        public void WaitForElementLoad(By by, int attempts = 5)
        {
            int counter = 0;
            while ((driver.FindElement(By.Id("FormMain")).FindElements(by).Count == 0) && counter < attempts)
            {
                Thread.Sleep(500);
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
