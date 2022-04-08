using System.ComponentModel.DataAnnotations;

namespace MasterBank.Business.Models
{
    public class Transferencia : Entity
    {
        [MaxLength(200, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres")]
        public string ChavePixOrigem { get; set; }

        public decimal Valor { get; set; }
        
        [MaxLength(200, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres")]
        public string ChavePixDestino { get; set; }
    }
}