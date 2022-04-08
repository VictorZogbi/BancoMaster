using MasterBank.Business.Interfaces.Repository;
using MasterBank.Business.Models;
using MasterBank.Data.Context;

namespace MasterBank.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(MasterBankDbContext db) : base(db) { }

        public async Task<IEnumerable<Cliente>> ObterCliente(Cliente cliente)
        {
            return await Buscar(x => x.Nome.Equals(cliente.Nome) ||
                               x.Documento.Equals(cliente.Documento) ||
                               x.ChavePix.Equals(cliente.ChavePix));
        }
    }
}