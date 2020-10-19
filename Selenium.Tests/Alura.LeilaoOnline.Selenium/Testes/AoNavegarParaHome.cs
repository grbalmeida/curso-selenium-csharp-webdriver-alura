using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaHome
    {
        private IWebDriver driver;

        public AoNavegarParaHome(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            // Act
            driver.Navigate().GoToUrl("http://localhost:5000");

            // Assert
            Assert.Contains("Leilões", driver.Title);
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            // Act
            driver.Navigate().GoToUrl("http://localhost:5000");

            // Assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }

        [Fact]
        public void DadoChromeAbertoFormularioRegistroNaoDeveMostrarMensagensDeErro()
        {
            // Act
            driver.Navigate().GoToUrl("http://localhost:5000");

            // Assert
            IWebElement form = driver.FindElement(By.TagName("form"));
            ReadOnlyCollection<IWebElement> spans = form.FindElements(By.TagName("span"));
        
            foreach (var span in spans)
            {
                Assert.True(string.IsNullOrEmpty(span.Text));
            }    
        }
    }
}
