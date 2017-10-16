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
using System.Threading;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <resumo>
    /// Descrição resumida para CodedUITest1
    /// </resumo>
    [CodedUITest]
    public class testeVersion
    {
        public testeVersion()
        {
        }

        [TestMethod]
        public void GerarCobrancaEmMassaSemImportacaoDeConsumoTodas6283Metodo()
        {
            // Para gerar código para este teste, selecione "Gerar Código para Teste de Interface do Usuário Codificado" no menu de atalho e selecione um dos itens do menu.
            //this.UIMap.AbrirGeracaoDeCobranca();
            //this.UIMap.VerificarTituloGeracaoCobranca();
            //this.UIMap.DesabilitarOpcaoImportarConsumosAte();
            //this.UIMap.SelecionarTodasCobrancas();
            //this.UIMap.DesabilitarGerarComOpcaoPorCiclo();
            //this.UIMap.ClicarBotaoGeracaoCobranca();
            //this.UIMap.VerificarTituloGeracaoCobranca();

            int tempoEspera = 0;

           while (tempoEspera < 5)
            {
                tempoEspera += 1;
                Thread.Sleep(1000);
                Console.WriteLine(tempoEspera);

                Console.WriteLine(DateTime.Now.ToString("h:mm:ss:fff tt"));

                // essa parte abaixo é para verificar se terminou a verificação, mas nao rolou
                //UIMap NewUIMap = new UIMap();

                //WinWindow UIGeraçãodecobrançaWindow1 = new WinWindow();
                //UIGeraçãodecobrançaWindow1.SearchProperties[WinWindow.PropertyNames.Name] = "Geração de cobrança";
                //UIGeraçãodecobrançaWindow1.WindowTitles.Add("Geração de cobrança");

                //WinWindow UIConcluídaWindow = new WinWindow();
                //UIConcluídaWindow.SearchProperties[WinWindow.PropertyNames.ControlName] = "labelMessage";
                //UIConcluídaWindow.WindowTitles.Add("Geração de cobrança");

                WinText UIConcluídaText = new WinText();
                UIConcluídaText.SearchProperties[WinText.PropertyNames.Name] = "Concluída";
                UIConcluídaText.WindowTitles.Add("Geração de cobrança");


                if (UIConcluídaText.Exists)
                //if (NewUIMap.UIGeraçãodecobrançaWindow1.UIConcluídaWindow.UIConcluídaText.Exists)
                {
                Console.WriteLine("Concluiu a geracao de cobranca");
                   break;

                }
                else
                {
                    Console.WriteLine("Ainda nao encontrou");
                }
            }
        }

        #region Atributos de teste adicionais

        // É possível usar os seguintes atributos adicionais enquanto escreve os testes:

        ////Use TestInitialize para executar código antes de executar cada teste 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            // Para gerar código para este teste, selecione "Gerar Código para Teste de Interface do Usuário Codificado" no menu de atalho e selecione um dos itens do menu.
            CheckLoginMulticlubes loginMultiClubes = new CheckLoginMulticlubes();
            loginMultiClubes.VerificarSeMultiClubesEstaAbertoELogado();
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
    }
}
