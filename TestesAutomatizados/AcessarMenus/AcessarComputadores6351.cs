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
    public class AcessarComputadores6351
    {
        public AcessarComputadores6351()
        {
        }

        [TestMethod]
        public void AcessarComputadores6351Metodo()
        {
            // Para gerar código para este teste, selecione "Gerar Código para Teste de Interface do Usuário Codificado" no menu de atalho e selecione um dos itens do menu.
            this.UIMap.AcessarSegurancaComputadores();
            this.UIMap.ProcurarTituloMultiClubesComputadores();
            this.UIMap.ProcurarTextoComputadores();
            this.UIMap.ProcurarTextoItens();
            this.UIMap.FecharTelaSegurancaComputadores();

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
