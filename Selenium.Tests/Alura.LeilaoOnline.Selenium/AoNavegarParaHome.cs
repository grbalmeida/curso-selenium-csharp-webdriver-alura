using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace Alura.LeilaoOnline.Selenium
{
    public class AoNavegarParaHome : IDisposable
    {
        private ChromeDriver driver;

        // Setup
        public AoNavegarParaHome()
        {
            driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            // Act
            driver.Navigate().GoToUrl("http://localhost:5000");

            // Assert
            Assert.Contains("Leilões", driver.Title);

            driver.Close();
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            // Act
            driver.Navigate().GoToUrl("http://localhost:5000");

            // Assert
            Assert.Contains("Próximos Leilões", driver.PageSource);

            driver.Close();
        }

        // TearDown
        public void Dispose()
        {
            driver?.Quit();
        }
    }
}
