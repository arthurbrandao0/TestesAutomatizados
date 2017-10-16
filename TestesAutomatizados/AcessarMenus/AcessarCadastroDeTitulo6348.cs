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


namespace TestesAutomatizados.AcessarMenus
{
    /// <resumo>
    /// Descrição resumida para CodedUITest1
    /// </resumo>
    [CodedUITest]
    public class AcessarCadastroDeTitulo6348
    {
        public AcessarCadastroDeTitulo6348()
        {
        }

        [TestMethod]
        public void AcessarCadastroDeTitulo6348Metodo()
        {
            // Para gerar código para este teste, selecione "Gerar Código para Teste de Interface do Usuário Codificado" no menu de atalho e selecione um dos itens do menu.

            //Necessita que seja feita uma validação que verifique se o caixa está aberto
            this.UIMap.AcessarCadastroDeTitulo();
            this.UIMap.ProcurarTextoCadastro();
            this.UIMap.ProcurarTextoNovoTítulo();
            this.UIMap.ProcurarBotaoTítulo();
            this.UIMap.ProcurarBotaoIncluirDependente();
            this.UIMap.ProcurarGroupBoxVenda();
            this.UIMap.FecharTelaCadastroTitulo();            
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
