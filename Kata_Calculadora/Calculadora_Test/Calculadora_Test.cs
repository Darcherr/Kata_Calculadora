using Xunit;
using Calculadora_app;

namespace Calculadora_Test
{
    public class Calculadora_Test
    {
        [Fact]
        public void StringVacio_RetornaCero()
        {
            // Arrange
            var calculadora = new Calculadora();
            var input = "";

            // Act
            var result = calculadora.Calcular(input);

            // Assert
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("20,1", 21)]
        public void DosNumerosSeparadosPorComa_RetornaSuma(string valores, int esperado)
        {
            // Arrange
            var calculadora = new Calculadora();

            // Act
            var result = calculadora.Calcular(valores);

            // Assert
            Assert.Equal(esperado, result);
        }

        [Theory]
        [InlineData("1,2,3,4,5", 15)]
        [InlineData("100,200,300", 600)]
        [InlineData("1,2,3,4,5,6,7,8,9,10", 55)]
        public void MuchosNumerosSeparadosPorComa_RetornaSuma(string input, int esperado)
        {
            //Arrange
            var calculadora = new Calculadora();

            //Act
            var result = calculadora.Calcular(input);

            //Assert
            Assert.Equal(esperado, result);
        }

        [Theory]
        [InlineData("1,2,3,4", 10)]
        [InlineData("100;200,300", 600)]
        [InlineData("1,2:3|4,5;6,7,8,9 10", 55)]
        public void MuchosNumerosSeparadosPorCualquierDelimitador_RetornaSuma(string input, int esperado)
        {
            // Arrange
            var calculadora = new Calculadora();

            // Act
            var result = calculadora.Calcular(input);

            // Assert
            Assert.Equal(esperado, result);
        }

        [Theory]
        [InlineData("-1,2,-3")]
        [InlineData("-1,-2,-3,-4,-5")]
        public void NumerosNegativos_LanzaExcepcion(string input)
        {
            // Arrange
            var calculadora = new Calculadora();

            // Act
            Exception ex = null;
            try
            {
                calculadora.Calcular(input);
            }
            catch (ArgumentException e)
            {
                ex = e;
            }

            // Assert
            Assert.Contains("No se pueden utilizar numeros negativos", ex.Message);

        }
        [Theory]
        [InlineData("1,2,a")]
        [InlineData("1,2,3,b,5")]
        public void CaracteresInvalidos_LanzaExcepcion(string input)
        {
            // Arrange
            var calculadora = new Calculadora();

            // Act
            Exception ex = null;
            try
            {
                calculadora.Calcular(input);
            }
            catch (ArgumentException e)
            {
                ex = e;
            }

            // Assert
            Assert.Contains("caracter/es no valido/s", ex.Message);
        }
    }
}