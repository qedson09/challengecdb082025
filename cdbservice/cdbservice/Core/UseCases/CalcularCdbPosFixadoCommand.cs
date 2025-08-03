using cdbservice.Core.Domain;
using MediatR;

namespace cdbservice.Core.UseCases
{
    public class CalcularCdbPosFixadoCommand : IRequest<RetornoInvestimento>
    {
        public decimal ValorInicial { get; set; }
        public int Meses { get; set; }
    }
}
