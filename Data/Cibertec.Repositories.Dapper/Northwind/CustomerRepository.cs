using Cibertec.Models;
using Cibertec.Repositories.Northwind;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class CustomerRepository: Repository<Customers>, ICustomerRepository
    {
        public CustomerRepository(string pConectionString) : base(pConectionString)
        { 
        }

    }
}
