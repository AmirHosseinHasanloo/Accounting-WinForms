using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AccountingRepository:IAccountingRepository
    {
        private DataContext db;

        public AccountingRepository(DataContext context)
        {
            this.db = context;
        }
    }
}
