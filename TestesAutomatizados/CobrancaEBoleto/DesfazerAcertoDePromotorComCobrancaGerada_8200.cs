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

namespace TestesAutomatizados.CobrancaEBoleto
{
    /// <resumo>
    /// Descrição resumida para CodedUITest1
    /// </resumo>
    [CodedUITest]
    public class DesfazerAcertoDePromotorComCobrancaGerada_8200
    {
        public DesfazerAcertoDePromotorComCobrancaGerada_8200()
        {
        }

        [TestMethod]
        public void DesfazerAcertoDePromotorComCobrancaGerada_8200_Metodo()
        {
            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            Driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            // Para gerar código para este teste, selecione "Gerar Código para Teste de Interface do Usuário Codificado" no menu de atalho e selecione um dos itens do menu.
            this.UIMap.GerarAcertoDeComissao();
            this.UIMap.ClicarBotaoOkAcertoDeComissao();

            this.UIMap.LocalizarHistoricoDeAcertos();
            Driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            var list = Driver.FindElement(By.Id("listView")).FindElements(By.Name("Sophie Promotor"));
            //Arrumar essa gambiarra do click:
            list[2].Click();
            list[2].Click();
            list[2].Click();

            Driver.FindElement(By.Name("Opções")).Click();
            Thread.Sleep(3000);
            Driver.FindElement(By.Name("Desfazer acerto")).Click();
            Thread.Sleep(3000);
            Driver.FindElement(By.Name("Sim")).Click();
            Thread.Sleep(3000);
            Driver.FindElement(By.Name("Fechar")).Click();
            Thread.Sleep(3000);
            Driver.FindElement(By.Name("Fechar")).Click();
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
        }

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
        private RemoteWebDriver Driver;
    }
}
