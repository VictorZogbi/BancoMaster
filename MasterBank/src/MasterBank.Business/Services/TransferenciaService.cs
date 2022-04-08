using MasterBank.Business.Interfaces;
using MasterBank.Business.Interfaces.Repository;
using MasterBank.Business.Models;

namespace MasterBank.Business.Services
{
    public class TransferenciaService : BaseService, ITransferenciaService
    {
        private readonly ITransferenciaRepository _transferenciaRepository;

        public TransferenciaService(ITransferenciaRepository transferenciaRepository, INotificador notificador) : base(notificador)
        {
            _transferenciaRepository = transferenciaRepository;
        }

        public async Task<bool> Adicionar(Transferencia transferencia)
        {
            if (_transferenciaRepository.Buscar(x => x.ChavePixOrigem != transferencia.ChavePixOrigem).Result.Any())
            {
                Notificar("Chave Pix Origem inexistente");
                return false;
            }

            if (_transferenciaRepository.Buscar(x => x.ChavePixDestino != transferencia.ChavePixDestino).Result.Any())
            {
                Notificar("Chave Pix Destino inexistente");
                return false;
            }

            if (transferencia.Valor <= 0)
            {
                Notificar("Valor tem que ser maior que zero");
                return false;
            }

            await _transferenciaRepository.Adicionar(transferencia);
            return true;
        }

        public void Dispose()
        {
            _transferenciaRepository?.Dispose();
        }
    }
}