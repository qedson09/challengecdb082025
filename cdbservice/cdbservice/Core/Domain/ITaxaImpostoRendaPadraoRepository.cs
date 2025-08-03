namespace cdbservice.Core.Domain
{
    public interface ITaxaImpostoRendaPadraoRepository
    {
        decimal ObterAliquotaPorPrazo(int meses);
    }
}
