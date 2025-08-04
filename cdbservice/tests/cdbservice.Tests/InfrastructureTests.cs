using cdbservice.Infrastructure;

namespace cdbservice.Tests;

public class InfrastructureTests
{
    private readonly TaxaImpostoRendaPadraoRepository _repository = new();

    [Fact]
    public void ObterValor_DeveRetornarValorEsperado()
    {
        // Arrange
        var repository = new IndicadorFinanceiroCdiRepository();

        // Act
        var valor = repository.ObterValor();

        // Assert
        Assert.Equal(0.009m, valor);
    }

    [Fact]
    public void ObterValor_DeveRetornarValorEsperado_TaxaTbRepository()
    {
        // Arrange
        var repository = new TaxaTbRepository();

        // Act
        var valor = repository.ObterValor();

        // Assert
        Assert.Equal(108m, valor);
    }

    [Theory]
    [InlineData(1, 0.225)]
    [InlineData(6, 0.225)]
    public void ObterAliquotaPorPrazo_DeveRetornarAliquota_ParaMesesAte6(int meses, decimal esperado)
    {
        var aliquota = _repository.ObterAliquotaPorPrazo(meses);
        Assert.Equal(esperado, aliquota);
    }

    [Theory]
    [InlineData(7, 0.20)]
    [InlineData(12, 0.20)]
    public void ObterAliquotaPorPrazo_DeveRetornarAliquota_ParaMesesAte12(int meses, decimal esperado)
    {
        var aliquota = _repository.ObterAliquotaPorPrazo(meses);
        Assert.Equal(esperado, aliquota);
    }

    [Theory]
    [InlineData(13, 0.175)]
    [InlineData(24, 0.175)]
    public void ObterAliquotaPorPrazo_DeveRetornarAliquota_ParaMesesAte24(int meses, decimal esperado)
    {
        var aliquota = _repository.ObterAliquotaPorPrazo(meses);
        Assert.Equal(esperado, aliquota);
    }

    [Theory]
    [InlineData(25, 0.15)]
    [InlineData(36, 0.15)]
    [InlineData(120, 0.15)]
    public void ObterAliquotaPorPrazo_DeveRetornarAliquota_ParaMesesAcimaDe24(int meses, decimal esperado)
    {
        var aliquota = _repository.ObterAliquotaPorPrazo(meses);
        Assert.Equal(esperado, aliquota);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void ObterAliquotaPorPrazo_DeveLancarArgumentException_ParaMesesInvalidos(int meses)
    {
        var ex = Assert.Throws<ArgumentException>(() => _repository.ObterAliquotaPorPrazo(meses));
        Assert.Equal("O número de meses deve ser maior que zero. (Parameter 'meses')", ex.Message);
    }
}
