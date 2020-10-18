using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using Xunit;

namespace CaelumPaginaInicial
{
    public class PaginaInicialTestes
    {
        [Fact]
        public void DeveExibirOTitulo()
        {
            // Arrange - Dado que um navegador est� aberto
            IWebDriver driver = new ChromeDriver(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            );

            // Act - Quando navego para a URL https://www.caelum.com.br
            driver.Navigate().GoToUrl("https://www.caelum.com.br");

            // Assert - Ent�o espero que a p�gina apresentada seja da Caelum
            Assert.Contains("Caelum", driver.Title);

            driver.Close();
        }
    }
}
