namespace cdbservice.Core.Domain
{
    public class RetornoInvestimento(decimal valorBruto, decimal valorLiquido)
    {
        public decimal ValorBruto { get; } = valorBruto;
        public decimal ValorLiquido { get; } = valorLiquido;
    }
}
