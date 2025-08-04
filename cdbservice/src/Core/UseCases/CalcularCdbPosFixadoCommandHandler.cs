using cdbservice.Core.Domain;
using MediatR;

namespace cdbservice.Core.UseCases
{
    public class CalcularCdbPosFixadoCommandHandler(
        IIndicadorFinanceiro indicadorRepository,
        ITaxaTbRepository taxaTbRepository,
        ITaxaImpostoRendaPadraoRepository taxaImpostoRepository) : IRequestHandler<CalcularCdbPosFixadoCommand, RetornoInvestimento>
    {
        private readonly IIndicadorFinanceiro _indicadorRepository = indicadorRepository;
        private readonly ITaxaTbRepository _taxaTbRepository = taxaTbRepository;
        private readonly ITaxaImpostoRendaPadraoRepository _taxaImpostoRepository = taxaImpostoRepository;

        public Task<RetornoInvestimento> Handle(CalcularCdbPosFixadoCommand request, CancellationToken cancellationToken)
        {
            var taxaCdi = _indicadorRepository.ObterValor();
            var taxaTb = _taxaTbRepository.ObterValor();
            var taxaImposto = _taxaImpostoRepository.ObterAliquotaPorPrazo(request.Meses);

            var cdb = new CdbPosFixado(request.ValorInicial, taxaCdi, taxaTb, taxaImposto);
            var resultado = cdb.CalcularRetornoInvestimento(request.Meses);
            return Task.FromResult(resultado);
        }
    }
}
