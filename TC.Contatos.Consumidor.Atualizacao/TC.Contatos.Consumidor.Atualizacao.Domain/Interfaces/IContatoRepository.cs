using Domain.RegionalAggregate;

namespace Domain.Interfaces
{
    public interface IContatoRepository
    {
        void Alterar(Contato contato);
        Contato ObterPorId(Guid id);
    }
}
