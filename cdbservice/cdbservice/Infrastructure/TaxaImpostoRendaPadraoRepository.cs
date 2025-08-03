using cdbservice.Core.Domain;

namespace cdbservice.Infrastructure
{
    public class TaxaImpostoRendaPadraoRepository : ITaxaImpostoRendaPadraoRepository
    {
        public decimal ObterAliquotaPorPrazo(int meses)
        {
            if (meses <= 6) return 0.225m;
            if (meses <= 12) return 0.20m;
            if (meses <= 24) return 0.175m;
            return 0.15m;
        }
    }
}
