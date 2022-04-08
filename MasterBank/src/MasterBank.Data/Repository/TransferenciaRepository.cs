using MasterBank.Business.Interfaces.Repository;
using MasterBank.Business.Models;
using MasterBank.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterBank.Data.Repository
{
    public class TransferenciaRepository : Repository<Transferencia>, ITransferenciaRepository
    {
        public TransferenciaRepository(MasterBankDbContext db) : base(db) { }

    }
}
