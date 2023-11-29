using Cibertec.Repositories.Northwind;
using Cibertec.UnitOfWork;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class NorthwindUnitOfWork: IUnitOfWork
    {
        public NorthwindUnitOfWork(string pConnectionString)
        {
            Customers = new CustomerRepository(pConnectionString);
            Products = new ProductRepository(pConnectionString);
            Users = new UserRepository(pConnectionString);
        }

        public ICustomerRepository Customers { get; private set; }
        public IProductRepository Products { get; private set; }
        public IUserRepository Users { get; private set; }
    }
}
