using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;

namespace TestesAutomatizados.Título
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class AlterarValidadeDeSocio
    {
        public AlterarValidadeDeSocio()
        {
        }

        [TestMethod]
        public void AlterarValidadeDeSocio_8022()
        {
            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();
            OpenCash openCash = new OpenCash();
            openCash.OpenCashMethod();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            string holderName = "Sócio criado em " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string dependentName = "Dependente criado em " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            McMenus.AcessarMenuOperacaoTituloCadastroDeTitulo();

            McFunctions.SearchElementByIdAndClick("comboBoxSalePlan", true);
            McFunctions.SearchElementByNameAndClick("AGE - AGEPES");

            McFunctions.SearchElementByIdAndSendKeys("maskedTextBoxPostalCode", "01311000", true, 60);

            McFunctions.SearchElementByIdAndClick("buttonSearch");

            McFunctions.SearchElementByIdAndSendKeys("textBoxNumber", "100", true);

            McFunctions.SearchElementByIdAndClick("buttonOK");

            McFunctions.SearchElementByIdAndSendKeys("textBoxName", holderName);
            McFunctions.SearchElementByIdAndSendKeys("textBox", "123");
            McFunctions.SearchElementByIdAndClick("buttonOK");

            McFunctions.SearchElementByIdAndClick("buttonFinalize", true);
            McFunctions.SearchElementByNameAndClick("Sim", true);

            McFunctions.SearchElementByIdAndClick("buttonService", true);

            McFunctions.SearchElementByNameAndClick("Título", true, 60);

            McFunctions.SearchElementByIdAndClick("sideButtonNewMember", true);

            McFunctions.SearchElementByIdAndSendKeys("textBoxName", dependentName, true);
            McFunctions.SearchElementByIdAndClick("comboBoxParentage");
            McFunctions.SearchElementByNameAndClick("Nora");
            McFunctions.SearchElementByIdAndSendKeys("textBox", "123");
            McFunctions.SearchElementByIdAndClick("buttonOK");

            McFunctions.WaitForElementLoad(By.Id("listViewMembers"));

            McFunctions.SearchElementByNameAndClick("Dependente");
            new Actions(driver).MoveToElement(driver.FindElement(By.Name("Dependente"))).ContextClick(driver.FindElement(By.Name("Dependente"))).Build().Perform();

            McFunctions.SearchElementByNameAndClick("Status", true);
            McFunctions.SearchElementByNameAndClick("Validade");

            this.UIMap.AlterarValidadeSocio();

            McFunctions.SearchElementByIdAndClick("buttonOK");

            McFunctions.WaitForElementLoad(By.Id("listViewMembers"), 30);

            var listViewDunElements = driver.FindElement(By.Id("listViewMembers")).FindElements(By.Id(""));

            int dependentNamePosition = 0;
            foreach (IWebElement i in listViewDunElements)
            {
                if (i.GetAttribute("Name") == dependentName)
                {
                    break;
                }
                dependentNamePosition++;
            }

            Assert.AreEqual(listViewDunElements[dependentNamePosition + 12].GetAttribute("Name"), "Até 01/01/2100");

            McFunctions.FinalizarAtendimentoTitulo();
            McFunctions.CloseWindow("Central de atendimento");
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            CheckLoginMulticlubes loginMC = new CheckLoginMulticlubes();
            loginMC.VerificarSeMultiClubesEstaAbertoELogado();
        }

        ////Use TestCleanup para executar código depois de cada execução de teste
        [TestCleanup()]
        public void MyTestCleanup()
        {
            CheckTestTrash McClean = new CheckTestTrash();
            McClean.CheckTestTrashMethod();
        }

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
    }
}
