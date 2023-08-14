using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using AccountingViewModels;

namespace DataLayer
{
    public class CustomersRepository : ICustomersRepository
    {
        private DataContext db;

        public CustomersRepository(DataContext context)
        {
            this.db = context;
        }

        public List<Customer> GetAllCustomers()
        {
            return db.Customers.ToList();
        }

        public Customer GetCustomersByID(int customerId)
        {
            return db.Customers.Find(customerId);
        }

        public bool InsertCustomer(Customer customer)
        {
            try
            {
                db.Customers.Add(customer);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            if (customer != null)
            {
                db.Entry(customer).State = EntityState.Modified;
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteCustomer(int customerId)
        {
            try
            {
                var delete = GetCustomersByID(customerId);
                DeleteCustomer(delete);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCustomer(Customer customer)
        {
            try
            {
                db.Entry(customer).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Customer> SearchCustomers(string q)
        {
            return db.Customers.Where(C => C.FullName.Contains(q) || C.Mobile.Contains(q) || C.Email.Contains(q)).ToList();
        }

        public List<ListCustomersViewModel> GetCustomerName(string fillter = "")
        {
            if (fillter == null)
            {
                return db.Customers.Select(C => new ListCustomersViewModel()
                {
                    CustomerID = C.CustomerID,
                    FullName = C.FullName
                }).ToList();
            }
            return db.Customers.Where(C => C.FullName.Contains(fillter)).Select(C => new ListCustomersViewModel()
            {
                CustomerID = C.CustomerID,
                FullName = C.FullName
            }).ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public int GetCumtomerIdByName(string name)
        {
            return db.Customers.Where(q => q.FullName == name).Select(q => q.CustomerID).SingleOrDefault();
        }

        public string GetCustomerNameById(int id)
        {
            return db.Customers.Find(id).FullName;
        }
    }
}
