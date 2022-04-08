using System.ComponentModel.DataAnnotations;

namespace MasterBank.Business.Models
{
    public class Cliente : Entity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string Documento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres")]
        public string ChavePix { get; set; }

        public Cliente(string nome, string documento, string chavePix)
        {
            Nome = nome;
            Documento = documento;
            ChavePix = chavePix;
        }
    }
}