using cdbservice.Core.Domain;

namespace cdbservice.Infrastructure
{
    public class IndicadorFinanceiroCdiRepository : IIndicadorFinanceiro
    {
        public decimal ObterValor()
        {
            return 0.009m; // 0,9%
        }
    }
}
