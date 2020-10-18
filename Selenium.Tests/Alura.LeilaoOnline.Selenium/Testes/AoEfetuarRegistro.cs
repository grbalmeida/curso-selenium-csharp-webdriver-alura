using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void Teste()
        {
            // Arrange - dado chrome aberto, página inicial do sist. de leilões,
            // dados de registros válidos informados
            driver.Navigate().GoToUrl("http://localhost:5000");

            // Act - efetuo o registro

            // Assert - devo ser direcionado para uma página de agradecimento
        }
    }
}
