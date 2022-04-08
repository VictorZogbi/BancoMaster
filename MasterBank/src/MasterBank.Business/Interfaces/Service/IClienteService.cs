using MasterBank.Business.Models;

namespace MasterBank.Business.Interfaces.Service
{
    public interface IClienteService : IDisposable
    {
        Task<bool> Adicionar(Cliente cliente);
    }
}
