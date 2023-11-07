namespace CalculadoraTestes;

public class CalculadoraTests
{
    [Fact]
    public void Somar_DeveRetornarSomaCorreta()
    {
        // Arrange
        var calculadora = new Calculadora();

        // Act
        int resultado = calculadora.Somar(5, 3);

        // Assert
        Assert.Equal(8, resultado);
    }

    [Fact]
    public void Subtrair_DeveRetornarSubtracaoCorreta()
    {
        // Arrange
        var calculadora = new Calculadora();

        // Act
        int resultado = calculadora.Subtrair(10, 4);

        // Assert
        Assert.Equal(6, resultado);
    }

    [Fact]
    public void Multiplicar_DeveRetornarMultiplicacaoCorreta()
    {
        // Arrange
        var calculadora = new Calculadora();

        // Act
        int resultado = calculadora.Multiplicar(7, 3);

        // Assert
        Assert.Equal(21, resultado);
    }

    [Fact]
    public void Dividir_DeveRetornarDivisaoCorreta()
    {
        // Arrange
        var calculadora = new Calculadora();

        // Act
        int resultado = calculadora.Dividir(20, 4);

        // Assert
        Assert.Equal(5, resultado);
    }

    [Fact]
    public void Dividir_PorZero_DeveLancarArgumentException()
    {
        // Arrange
        var calculadora = new Calculadora();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => calculadora.Dividir(10, 0));
    }

    [Fact]
    public void ObterHistorico_DeveRetornarHistoricoCorreto()
    {
        // Arrange
        var calculadora = new Calculadora();

        // Act
        calculadora.Somar(3, 2);
        calculadora.Subtrair(10, 4);
        calculadora.Somar(3, 8);
        calculadora.Subtrair(10, 6);
        var historico = calculadora.ObterHistorico();

        // Assert - Validação positiva (até 3 registros)
        Assert.True(historico.Count <= 3);

        if (historico.Count <= 1)
        {
            Assert.Contains("SOMAR 3 e 2 resultam em 5", historico);
            Assert.Contains("SUBTRAIR 10 e 4 resultam em 6", historico);
            Assert.Contains("SOMAR 3 e 8 resultam em 11", historico);
            Assert.Contains("SUBTRAIR 10 e 6 resultam em 4", historico);
        }
 
        // Assert - Validação negativa (mais de 3 registros)
        Assert.False(historico.Count > 3);
    }
}

