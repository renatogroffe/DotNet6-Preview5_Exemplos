using Xunit;

namespace Groffe.Distancias.Testes
{
    public class Testes
    {
        [Theory]
        [InlineData(1, 1.609)]
        [InlineData(10.579, 17.022)]
        [InlineData(500, 804.5)]
        [InlineData(750.5, 1207.554)]
        [InlineData(1300, 2091.7)]
        [InlineData(2000.123, 3218.198)]
        public void ValidarConversaoMilhasParaKm(
            double milhas, double resultadoKm)
        {
            Assert.Equal(resultadoKm,
                ConversorDistancias.MilhasParaKm(milhas));
        }

        // Método comentado para simulações com o Coverlet
        [Theory]
        [InlineData(1.609, 1)]
        [InlineData(100, 62.15)]
        [InlineData(2091.7, 1300)]
        [InlineData(200.78, 124.786)]
        [InlineData(5763.96, 3582.324)]
        [InlineData(7500, 4661.28)]
        public void ValidarConversaoKmParaMilhas(
            double Km, double resultadoMilhas)
        {
            Assert.Equal(resultadoMilhas,
                ConversorDistancias.MilhasParaKm(Km));
        }
    }
}