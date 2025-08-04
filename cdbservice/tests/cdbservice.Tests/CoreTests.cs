using cdbservice.Core.Domain;
using cdbservice.Core.UseCases;
using FluentAssertions;
using Moq;

namespace cdbservice.Tests;

public class CoreTests
{
    private readonly CalcularCdbPosFixadoCommandValidator _validator = new();

    [Fact]
    public void Construtor_DeveLancarExcecao_QuandoValorInicialMenorOuIgualZero()
    {
        Assert.Throws<ArgumentException>(() =>
            new CdbPosFixado(0, 0.1m, 100m, 0.15m));
    }

    [Fact]
    public void CalcularRetornoInvestimento_DeveLancarExcecao_QuandoMesesMenorOuIgualUm()
    {
        var cdb = new CdbPosFixado(1000m, 0.1m, 100m, 0.15m);

        Assert.Throws<ArgumentException>(() =>
            cdb.CalcularRetornoInvestimento(1));
    }

    [Fact]
    public void CalcularRetornoInvestimento_DeveCalcularCorretamente_ParaValoresValidos()
    {
        // Arrange
        decimal valorInicial = 1000m;
        decimal taxaCdi = 0.1m; // 10%
        decimal taxaTb = 100m;  // 100%
        decimal taxaImposto = 0.15m; // 15%
        int meses = 3;

        var cdb = new CdbPosFixado(valorInicial, taxaCdi, taxaTb, taxaImposto);
        
        // Act
        var retorno = cdb.CalcularRetornoInvestimento(meses);

        // Assert
        // taxaMensal = 0.1 * (100/100) = 0.1
        // valorBruto = 1000 * 1.1 * 1.1 = 1210
        // valorLiquido = 1210 * 0.85 = 1028.5
        Assert.Equal(1210m, Math.Round(retorno.ValorBruto, 2));
        Assert.Equal(1028.5m, Math.Round(retorno.ValorLiquido, 2));
    }

    [Fact]
    public async Task Handle_DeveRetornarResultadoCorreto_QuandoParametrosSaoValidos()
    {
        // Arrange
        var mockIndicador = new Mock<IIndicadorFinanceiro>();
        var mockTaxaTb = new Mock<ITaxaTbRepository>();
        var mockTaxaImposto = new Mock<ITaxaImpostoRendaPadraoRepository>();

        mockIndicador.Setup(x => x.ObterValor()).Returns(0.009m); // 0,9%
        mockTaxaTb.Setup(x => x.ObterValor()).Returns(1.08m); // 108%
        mockTaxaImposto.Setup(x => x.ObterAliquotaPorPrazo(It.IsAny<int>())).Returns(0.225m); // 22.5%

        var handler = new CalcularCdbPosFixadoCommandHandler(
            mockIndicador.Object,
            mockTaxaTb.Object,
            mockTaxaImposto.Object
        );

        var command = new CalcularCdbPosFixadoCommand
        {
            ValorInicial = 1000m,
            Meses = 3
        };

        // Act
        var resultado = await handler.Handle(command, default);

        // Assert
        Assert.NotNull(resultado);
        Assert.True(resultado.ValorBruto > 0);
        Assert.True(resultado.ValorLiquido > 0);
    }


    [Fact]
    public async Task Handle_DevePropagarExcecao_QuandoRepositorioLanca()
    {
        // Arrange
        var mockIndicador = new Mock<IIndicadorFinanceiro>();
        var mockTaxaBase = new Mock<ITaxaTbRepository>();
        var mockTaxaImposto = new Mock<ITaxaImpostoRendaPadraoRepository>();

        mockIndicador.Setup(x => x.ObterValor()).Throws(new InvalidOperationException());

        var handler = new CalcularCdbPosFixadoCommandHandler(
            mockIndicador.Object,
            mockTaxaBase.Object,
            mockTaxaImposto.Object
        );

        var command = new CalcularCdbPosFixadoCommand
        {
            ValorInicial = 1000m,
            Meses = 3
        };

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => handler.Handle(command, default));
    }

    [Fact]
    public void Deve_Aceitar_Valores_Validos()
    {
        var command = new CalcularCdbPosFixadoCommand
        {
            ValorInicial = 1000,
            Meses = 12
        };

        var resultado = _validator.Validate(command);

        resultado.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-10)]
    public void Deve_Rejeitar_ValorInicial_MenorOuIgualAZero(decimal valorInicial)
    {
        var command = new CalcularCdbPosFixadoCommand
        {
            ValorInicial = valorInicial,
            Meses = 12
        };

        var resultado = _validator.Validate(command);

        resultado.IsValid.Should().BeFalse();
        resultado.Errors.Should().Contain(e => e.PropertyName == "ValorInicial" && e.ErrorMessage == "Valor inicial deve ser maior que zero.");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(-5)]
    public void Deve_Rejeitar_Meses_MenorOuIgualAUm(int meses)
    {
        var command = new CalcularCdbPosFixadoCommand
        {
            ValorInicial = 1000,
            Meses = meses
        };

        var resultado = _validator.Validate(command);

        resultado.IsValid.Should().BeFalse();
        resultado.Errors.Should().Contain(e => e.PropertyName == "Meses" && e.ErrorMessage == "Número de meses deve ser maior que 1.");
    }
}
