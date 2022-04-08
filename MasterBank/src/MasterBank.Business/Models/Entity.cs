using System.ComponentModel.DataAnnotations;

namespace MasterBank.Business.Models
{
    public abstract class Entity
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}