using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AccountingTypesRepository:IAccountingTypesRepository
    {
       private DataContext db;

        public AccountingTypesRepository(DataContext context)
        {
            this.db = context;
        }
    }
}
