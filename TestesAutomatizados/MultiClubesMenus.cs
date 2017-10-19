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

namespace TestesAutomatizados
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class MultiClubesMenus
    {
        public MultiClubesMenus()
        {
            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);

            Driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);
        }

        #region Acesso aos Menus

        public void AcessarMenu(string NomeMenu)
        {
            Driver.FindElement(By.Name(NomeMenu)).Click();
        }

        // Arquivo
        public void AcessarMenuArquivo()
        {
            this.AcessarMenu("Arquivo");
        }

        // Arquivo - Alterar senha
        // Arquivo - Bloquear
        // Arquivo - Trocar usuário
        // Arquivo - Sair
        public void AcessarMenuArquivoSair()
        {
            this.AcessarMenuArquivo();
            this.AcessarMenu("Sair");
        }

        // Operação
        public void AcessarMenuOperacao()
        {
            this.AcessarMenu("Operação");
        }

        // Operação - Acesso
        // Operação - Achados e Perdidos
        // Operação - Armários 
        // Operação - Autoatendimento
        // Operação - Benefícios
        // Operação - Biblioteca
        // Operação - Dependências
        // Operação - Eleições
        // Operação - Estábulos
        // Operação - Estacionamentos
        // Operação - Estádios
        // Operação - Ferramentas
        // Operação - Financeiro
        public void AcessarMenuOperacaoFinanceiro()
        {
            this.AcessarMenuOperacao();
            this.AcessarMenu("Financeiro");
        }

        // Operação - Financeiro - Acerto de comissão
        public void AcessarMenuOperacaoFinanceiroAcertoDeComissao()
        {
            this.AcessarMenuOperacaoFinanceiro();
            this.AcessarMenu("Acerto de comissão");
        }
        // Operação - Financeiro - Caixas
        // Operação - Financeiro - Cheques
        // Operação - Financeiro - Cobrança
        public void AcessarMenuOperacaoFinanceiroCobranca()
        {
            this.AcessarMenuOperacaoFinanceiro();
            this.AcessarMenu("Cobrança");
        }

        // Operação - Financeiro - Cobrança - Mensagens de cobrança
        // Operação - Financeiro - Cobrança - Notificação de cobrança
        // Operação - Financeiro - Cobrança - Quitação anual de débitos
        // Operação - Financeiro - Cobrança - Geração de cobrança
        public void AcessarMenuOperacaoFinanceiroCobrancaGeracaoDeCobranca()
        {
            this.AcessarMenuOperacaoFinanceiroCobranca();
            this.AcessarMenu("Geração de cobrança");
        }

        // Operação - Financeiro - NFS-e
        // Operação - Financeiro - Parcelamentos
        // Operação - Financeiro - Sped contribuições
        // Operação - Financeiro - Transações bancárias

        // Operação - Marinas
        // Operação - Título
        // Operação - Visitas

        // Administração
        public void AcessarMenuAdministracao()
        {
            this.AcessarMenu("Administração");
        }

        // Administração - Acesso
        // Administração - Armários
        // Administração - Atendimento
        // Administração - Benefícios
        // Administração - Biblioteca
        // Administração - Clubes
        // Administração - Configurações
        // Administração - Conselhos
        // Administração - Departamentos
        // Administração - Dependências
        // Administração - Estábulos
        // Administração - Estacionamentos
        // Administração - Estádios
        // Administração - Eventos
        // Administração - Exames
        // Administração - Feriados
        // Administração - Ferramentas
        // Administração - Financeiro
        // Administração - Histórico de ações
        // Administração - Integração ERP
        // Administração - Mapas de ocupação
        // Administração - Marinas
        // Administração - Modalidades
        // Administração - Ouvidoria
        // Administração - Profissões
        // Administração - Retornos de correspondência
        // Administração - Segurança
        // Administração - Título

        public void AcessarMenuRelatorios()
        {
            this.AcessarMenu("Relatórios");
        }

        public void AcessarMenuAjuda()
        {
            this.AcessarMenu("Ajuda");
        }
        #endregion

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

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
        private RemoteWebDriver Driver;
    }
}
