using AccountingViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingViewModels;

namespace DataLayer
{
    public interface ICustomersRepository
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomersByID(int customerId);
        bool InsertCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(int customerId);
        bool DeleteCustomer(Customer customer);
        List<ListCustomersViewModel> GetCustomerName(string fillter = "");
        IEnumerable<Customer> SearchCustomers(string q);
    }
}
