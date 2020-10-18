using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace Alura.LeilaoOnline.Selenium
{
    public class AoNavegarParaHome
    {
        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            // Arrange
            IWebDriver driver = new ChromeDriver(TestHelper.PastaDoExecutavel);

            // Act
            driver.Navigate().GoToUrl("http://localhost:5000");

            // Assert
            Assert.Contains("Leilões", driver.Title);

            driver.Close();
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            // Arrange
            IWebDriver driver = new ChromeDriver(TestHelper.PastaDoExecutavel);

            // Act
            driver.Navigate().GoToUrl("http://localhost:5000");

            // Assert
            Assert.Contains("Próximos Leilões", driver.PageSource);

            driver.Close();
        }
    }
}
