namespace cdbservice.Core.Domain
{
    public interface IProdutoRendaFixa
    {
        RetornoInvestimento CalcularRetornoInvestimento(int meses);
    }
}
