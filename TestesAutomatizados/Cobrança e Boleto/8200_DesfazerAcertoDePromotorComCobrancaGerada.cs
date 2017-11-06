using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
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

        //Timeout = 4h (converted in ms)
        [TestMethod(), Timeout(14400000)]
        public void DesfazerAcertoDePromotorComCobrancaGerada_8200_Metodo()
        {
            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            // 1. Pré-requisito: Acerto de comissão gerada para o promotor @NomePromotor, associado ao título  @IdTitulo 
            McMenus.AcessarMenuOperacaoFinanceiroAcertoDeComissao();

            driver.FindElement(By.Name("Localizar")).Click();

            McFunctions.WaitForElementLoad(By.Id("listView"));
            List<IWebElement> elementlist = new List<IWebElement>();
            elementlist.AddRange(driver.FindElement(By.Id("listView")).FindElements(By.Name("Sophie Promotor")));

            if(elementlist.Count > 0)
            {
                new Actions(driver).ContextClick(elementlist[0]).Perform();
                driver.FindElement(By.Name("Gerar acerto")).Click();
                driver.FindElement(By.Name("Sim")).Click();
                McFunctions.TratarTelaAguarde();
                driver.FindElement(By.Id("buttonCancel")).Click();                
            }
            else
            {
                Console.WriteLine("Acerto gerado anteriormente");
            }

            //3.Logar no MultiClubes
            // Presente no TestInitialize

            //4.Acessar Central de Atendimento
            McFunctions.AcessarCentralDeAtendimento();

            //5.Localizar e Acessar Título
            this.UIMap.AbrirAtendimentoTitulo008Pro();

            //6.Acessar o menu Produtos
            //Serem apresentadas as opções A receber, Recebido, Desativados, Créditos, Resgate, Parcelamento e Mudar promotor
            //// Já vem marcada como default

            //7.Clicar na opção A receber
            //Ser apresentada tela contendo as parcelas de produtos a receber, constando parcela do produto Acerto promotor
            McFunctions.AcessarProdutosAReceber();

            //8.Copiar o valor referente a coluna Nosso número
            McFunctions.WaitForElementLoad(By.Id("listViewParcel"));
            var ListViewParcelElements = driver.FindElement(By.Id("listViewParcel")).FindElements(By.Id(""));
            int counterStep8 = 0;

            foreach (IWebElement i in ListViewParcelElements)
            {
                if (i.GetAttribute("Name") == "Acerto Promotor")
                {
                    break;
                }
                counterStep8++;
            }
            
            var nossoNumero = ListViewParcelElements[counterStep8 + 6].GetAttribute("Name");

            McFunctions.ClicarBotaoFechar();
            
            //9.Clicar no menu Cobranças
            //Serem apresentadas as opções Ativas, Desativadas e Editar Cobranças
            //10.Clicar na opção Ativas
            //Ser apresentada tela contendo as cobranças ativas, constando na coluna Nosso número o mesmo valor do número copiado no passo 8
            McFunctions.AcessarCobrancasAtivas();

            McFunctions.WaitForElementLoad(By.Id("listViewDun"));
            var listViewDunElements = driver.FindElement(By.Id("listViewDun")).FindElements(By.Id(""));
            int counterStep9 = 0;
            bool encontrounn = false;

            foreach (IWebElement i in listViewDunElements)
            {
                if (i.GetAttribute("Name") == nossoNumero)
                {
                    encontrounn = true;
                    break;
                }
                counterStep9++;
            }

            Assert.IsTrue(encontrounn, "Nosso numero encontrado");

            McFunctions.ClicarBotaoFechar();

            McFunctions.FinalizarAtendimentoTitulo();

            //11.Acessar Acerto de Comissão
            McMenus.AcessarMenuOperacaoFinanceiroAcertoDeComissao();

            //12.Clicar no menu Histórico
            //Ser apresentada tela para acessar o histórico de acertos de promotores gerados
            driver.FindElement(By.Id("sideButtonClassHistoric")).Click();

            //13.Clicar no botão Localizar
            //Ser apresentada lista contendo todos os acertos de promotores gerados
            driver.FindElement(By.Id("buttonFilter")).Click();
            
            //14.Localizar e clicar no acerto de comissão referente aos passos 7 e 10
            //Registro de acerto ser corretamente selecionado e apresentado em destaque
            //15.Dar duplo clique no registro de acerto de promotor
            //Ser apresentada tela contendo Detalhe do acerto da comissão
                        
            new Actions(driver).DoubleClick(driver.FindElementsByName("Sophie Promotor")[3]).Build().Perform();

            //16.Clicar no botão Opções
            //Ser apresentado sub - menu contendo as opções disponíveis
            McFunctions.WaitForElementLoad(By.Name("Opções"));
            driver.FindElement(By.Name("Opções")).Click();

            //17.No sub-menu, clicar na opção Desfazer acerto
            //Ser apresentada tela solicitando confirmação para desfazer acerto de comissão para o promotor
            driver.FindElement(By.Name("Desfazer acerto")).Click();

            //18.Clicar no botão Sim
            //Acerto de comissão de promotor ser corretamente desfeito e ser apresentada tela de histórico de acertos sem constar o acerto de comissão desfeito
            driver.FindElement(By.Name("Sim")).Click();

            McFunctions.TratarTelaAguarde();

            driver.FindElement(By.Name("Fechar")).Click();
            
            driver.FindElement(By.Name("Fechar")).Click();

            //19.Acessar Central de Atendimento
            McFunctions.AcessarCentralDeAtendimento();

            //20.Localizar e Acessar Título
            this.UIMap.AbrirAtendimentoTitulo008Pro();

            //21.Repetir os passos 6 e 7
            //Ser apresentada tela contendo as parcelas de produtos a receber, não constando parcela do produto Acerto promotor, desfeita no passo 18
            McFunctions.AcessarProdutosAReceber();

            McFunctions.WaitForElementLoad(By.Id("listViewParcel"));
            var NewlistViewParcelElements = driver.FindElement(By.Id("listViewParcel")).FindElements(By.Id(""));
            var counterStep21 = 0;
            bool encontrouacertopromotor = false;

            foreach (IWebElement i in NewlistViewParcelElements)
            {
                if (i.GetAttribute("Name") == "Acerto Promotor")
                {
                    encontrouacertopromotor = true;
                    break;
                }
               counterStep21++;
            }
            Assert.IsFalse(encontrouacertopromotor, "Acerto Promotor continuou em Produtos a receber");

            McFunctions.ClicarBotaoFechar();

            //22.Repetir os passos 9 e 10
            //Ser apresentada tela contendo as cobranças ativas, não constando cobrança referente ao acerto de comissão de promotor, desfeita no passo 18
            McFunctions.AcessarCobrancasAtivas();

            McFunctions.WaitForElementLoad(By.Id("listViewDun"));
            var NewListViewDunElements = driver.FindElement(By.Id("listViewDun")).FindElements(By.Id(""));
            var counterStep22 = 0;
            bool encontrounn2 = false;

            foreach (IWebElement i in NewListViewDunElements)
            {
                if (i.GetAttribute("Name") == nossoNumero)
                {
                    encontrounn = true;
                    break;
                }
                counterStep22++;
            }
            Assert.IsFalse(encontrounn2, "Nosso numero encontrado nas cobranças ativas");
            McFunctions.ClicarBotaoFechar();

            McFunctions.FinalizarAtendimentoTitulo();
            McFunctions.CloseWindow("Central de Atendimento");            
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
