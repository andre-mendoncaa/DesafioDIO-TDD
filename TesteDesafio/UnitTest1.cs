using System;
using Xunit;
using DesafioDIO;
using System.Net.Cache;

namespace TesteDesafio
{
    public class UnitTest1
    {
        public Calculadora construirClasse()
        {
            string data = "02/06/2024";
            Calculadora calc = new Calculadora(data);

            return calc;
        }


        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(4, 5, 9)]
        public void TesteSomar(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.somar(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }
        [Theory]
        [InlineData(3, 2, 1)]
        [InlineData(4, 5, -1)]
        public void TesteSubtrair(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.subtrair(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }
        [Theory]
        [InlineData(4, 2, 2)]
        [InlineData(-15, -5, 3)]
        public void TesteDividir(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.dividir(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }
        [Theory]
        [InlineData(3, 2, 6)]
        [InlineData(4, -5, -20)]
        public void TesteMultiplicar(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.multiplicar(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }
        [Fact]
        public void TestarDivisaoZero()
        {
            Calculadora calc = construirClasse();
            Assert.Throws<DivideByZeroException>(() => calc.dividir(3,0));
        }
        [Fact]
        public void TestarHistorico()
        {
            Calculadora calc = construirClasse();

            calc.somar(1, 2);
            calc.somar(3, 2);
            calc.somar(5, 3);
            calc.somar(87, 12);

            var lista = calc.historico();

            Assert.NotEmpty(calc.historico());
            Assert.Equal(3, lista.Count);
        }
    }
}
