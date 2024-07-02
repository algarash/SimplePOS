using Microsoft.EntityFrameworkCore;
using SimplePOS.Models.Repositories.Interfaces;

namespace SimplePOS.Models.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SimplePOSContext _context;

        public CustomerRepository(SimplePOSContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAllCustomers 
        {
            get
            {
                return _context.Customers.Include(c => c.Orders).OrderByDescending(c => c.CustomerId);
            }
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                Save();
            }catch (Exception ex)
            {
                throw;
            }
            
        }
        public void UpdateCustomer(Customer customer)
        {
            try
            {
                _context.Customers.Update(customer);
                Save();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Customer? GetCustomerById(int id)
        {
            try
            {
                return _context.Customers.FirstOrDefault(c => c.CustomerId == id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
       

        public void DeleteCustomer(int id)
        {
            try
            {
                var customer = _context.Customers.Find(id);
                _context.Customers.Remove(customer);
                Save();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
