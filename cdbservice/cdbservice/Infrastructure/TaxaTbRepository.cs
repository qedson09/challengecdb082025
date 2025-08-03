using cdbservice.Core.Domain;

namespace cdbservice.Infrastructure
{
    public class TaxaTbRepository : ITaxaTbRepository
    {
        public decimal ObterValor()
        {
            return 108m; // 108%
        }
    }
}
