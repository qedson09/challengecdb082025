namespace cdbservice.Core.Domain
{
    public class CdbPosFixado : IProdutoRendaFixa
    {
        private readonly decimal _valorInicial;
        private readonly decimal _taxaCdi;
        private readonly decimal _taxaTb;
        private readonly decimal _taxaImposto;

        public CdbPosFixado(decimal valorInicial, decimal taxaCdi, decimal taxaTb, decimal aliquotaImposto)
        {
            if (valorInicial <= 0) throw new ArgumentException("Valor inicial deve ser maior que zero.");
            _valorInicial = valorInicial;
            _taxaCdi = taxaCdi;
            _taxaTb = taxaTb;
            _taxaImposto = aliquotaImposto;
        }
        
        public RetornoInvestimento CalcularRetornoInvestimento(int meses)
        {
            if (meses <= 1)
                throw new ArgumentException("Número de meses deve ser maior que 1.");

            decimal valorBruto = _valorInicial;
            decimal taxaMensal = _taxaCdi * (_taxaTb / 100m);

            for (int i = 0; i < meses -1; i++)
            {
                valorBruto *= (1 + taxaMensal);
            }

            decimal valorLiquido = valorBruto * (1 - _taxaImposto);

            valorBruto = Math.Round(valorBruto, 2);
            valorLiquido = Math.Round(valorLiquido, 2);
            return new RetornoInvestimento(valorBruto, valorLiquido);
        }
    }

}
