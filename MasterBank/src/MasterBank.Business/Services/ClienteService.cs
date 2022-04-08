using MasterBank.Business.Interfaces;
using MasterBank.Business.Interfaces.Repository;
using MasterBank.Business.Interfaces.Service;
using MasterBank.Business.Models;
using MasterBank.Business.Models.Validations.Document;

namespace MasterBank.Business.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository, INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Adicionar(Cliente cliente)
        {
            cliente.Documento = Utils.ApenasNumeros(cliente.Documento);

            if (!CpfValidacao.Validar(cliente.Documento).Equals(true))
            {
                Notificar("Documento inválido");
                return false;
            }

            if (_clienteRepository.Buscar(x => x.Documento.Equals(cliente.Documento)).Result.Any())
            {
                Notificar("Já existe um cliente com este documento informado.");
                return false;
            }

            if (_clienteRepository.Buscar(x => x.ChavePix.Equals(cliente.ChavePix)).Result.Any())
            {
                Notificar("Chave Pix já existente");
                return false;
            }            

            await _clienteRepository.Adicionar(cliente);
            return true;
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }
    }
}
