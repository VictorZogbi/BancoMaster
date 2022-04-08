using MasterBank.Business.Interfaces;
using MasterBank.Business.Interfaces.Repository;
using MasterBank.Business.Interfaces.Service;
using MasterBank.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasterBank.API.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class ClienteController : MainController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        private readonly ITransferenciaService _transferenciaService;

        public ClienteController(IClienteRepository clienteRepository,
                                 IClienteService clienteService,
                                 ITransferenciaService transferenciaService,
                                  INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
            _transferenciaService = transferenciaService;
        }

        [HttpGet]
        public async Task<IEnumerable<Cliente>> ConsultarCliente(string Nome, string Documento, string ChavePix)
        {
            return await _clienteRepository.ObterCliente(new Cliente(Nome, Documento, ChavePix));
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> CadastrarCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.Select(x => x.Errors));

            await _clienteService.Adicionar(cliente);

            return CustomResponse(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Transferencia>> TransferirPix(Transferencia transferencia)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.Select(x => x.Errors));

            await _transferenciaService.Adicionar(transferencia);

            return CustomResponse(transferencia);
        }
    }
}