﻿using System;
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
using OpenQA.Selenium.Support.UI;

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

        public void FecharJanela(string NomeJanela = "")
        {
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

        public void WaitForElementLoad(By by, int attempts = 2)
        {
            int counter = 0;
            while ((driver.FindElement(By.Id("FormMain")).FindElements(by).Count == 0) && counter < attempts)
            {
                Thread.Sleep(500);
                Console.WriteLine("passando pelo loop WaitForElementLoad: {0}", by);
                counter++;
            }

            //}
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
