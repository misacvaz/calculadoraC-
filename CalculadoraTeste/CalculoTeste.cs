
using CalculadoraCalculo;

namespace CalculadoraTeste;

public class CalculoTeste
{

    public Calculo ConstruirClasseCalculo()
    {
      
       return new Calculo();
       
        
    }
    [Theory]
    [InlineData (1,2,3)]
    public void TesteSomar( int num1, int num2, int resultado)
    {
        //Arrange
        Calculo calc = ConstruirClasseCalculo();

       //Act
        int resultadoCalculo = calc.Somar(num1, num2);

        //Assert
        Assert.Equal(resultado, resultadoCalculo);

    }


    [Theory]
    [InlineData (5,2, 3)]
    public void TesteSubtracao(int num1 , int num2, int resultado)
    {
        //Arrange
        Calculo clac = ConstruirClasseCalculo();

        //Act
        int SubitracaoCalculo = clac.Subtrair(num1, num2);

        //Assert
        Assert.Equal(resultado, SubitracaoCalculo);
    }

    [Theory]
    [InlineData(2, 5, 10)]
    public void TesteMultiplicacao(int num1, int num2, int resultado)
    {
        //Arrange
        Calculo clac = ConstruirClasseCalculo();

        //Act
        int MultiplicacaoCalculo = clac.Multiplicar(num1, num2);

        //Assert
        Assert.Equal(resultado, MultiplicacaoCalculo);
    }


    [Theory]
    [InlineData(10, 5, 2)]
    public void TesteDivisao(int num1, int num2, int resultado)
    {
        //Arrange
        Calculo clac = ConstruirClasseCalculo();

        //Act
        double DivisaoCalculo = clac.Dividir(num1, num2);

        //Assert
        Assert.Equal(resultado, DivisaoCalculo);
    }


    [Fact]
    public void TesteHistorico()
    {
        // Arrange
        Calculo calc = ConstruirClasseCalculo();

        // Executar várias operações
        calc.Somar(1, 2); // "1 + 2 = 3"
        calc.Subtrair(5, 2); // "5 - 2 = 3"
        calc.Multiplicar(2, 5); // "2 * 5 = 10"
        calc.Dividir(10, 5); // "10 / 5 = 2"
        calc.Somar(3, 3); // "3 + 3 = 6"
        calc.Subtrair(7, 4); // "7 - 4 = 3"  <- Este cálculo deve aparecer no histórico
        calc.Multiplicar(6, 3); // "6 * 3 = 18"  <- Este cálculo deve aparecer no histórico

        // Act
        var historico = calc.Historico();

        // Assert - Verificar que os 5 últimos resultados estão corretos
        Assert.Equal(5, historico.Count); // Verifica se tem exatamente 5 itens
        Assert.Equal("2 * 5 = 10", historico[0]);
        Assert.Equal("10 / 5 = 2", historico[1]);
        Assert.Equal("3 + 3 = 6", historico[2]);
        Assert.Equal("7 - 4 = 3", historico[3]);
        Assert.Equal("6 * 3 = 18", historico[4]);
    }
}

