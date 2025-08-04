using cdbservice.Core.Domain;

namespace cdbservice.Infrastructure
{
    public class TaxaImpostoRendaPadraoRepository : ITaxaImpostoRendaPadraoRepository
    {
        public decimal ObterAliquotaPorPrazo(int meses)
        {
            if (meses <= 0)
                throw new ArgumentException("O número de meses deve ser maior que zero.", nameof(meses));

            return meses switch
            {
                <= 6 => 0.225m,
                <= 12 => 0.20m,
                <= 24 => 0.175m,
                _ => 0.15m
            };
        }
    }
}
