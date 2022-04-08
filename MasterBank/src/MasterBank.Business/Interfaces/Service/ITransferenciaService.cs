using MasterBank.Business.Models;

namespace MasterBank.Business.Interfaces.Repository
{
    public interface ITransferenciaService : IDisposable
    {
        Task<bool> Adicionar(Transferencia transferencia);
    }
}