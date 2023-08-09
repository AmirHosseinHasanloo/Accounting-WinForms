using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataContext : DbContext, IDisposable
    {
        public DataContext() : base("name=DataContext") { }

        public DbSet<Customer> Customers { get; set; }
        private ICustomersRepository _customersRepository;
        public ICustomersRepository CustomersRepository
        {
            get
            {
                if (_customersRepository == null)
                {
                    _customersRepository = new CustomersRepository(this);
                }
                return _customersRepository;
            }
        }

        public DbSet<Accounting> Accountings { get; set; }
        private GenericRepository<Accounting> _accountingRepository;
        public GenericRepository<Accounting> AccountingRepository
        {
            get
            {
                if (_accountingRepository == null)
                {
                    _accountingRepository = new GenericRepository<Accounting>(this);
                }
                return _accountingRepository;
            }
        }



        public DbSet<AccountingTypes> AccountingTypes { get; set; }
        private GenericRepository<AccountingTypes> _accountingTypesRepository;
        public GenericRepository<AccountingTypes> AccountingTypesRepository
        {
            get
            {
                if (_accountingTypesRepository == null)
                {
                    _accountingTypesRepository = new GenericRepository<AccountingTypes>(this);
                }
                return _accountingTypesRepository;
            }
        }

        public void Save()
        {
            this.SaveChanges();
        }

        public void Disposing()
        {
            base.Dispose();
        }
    }
}
