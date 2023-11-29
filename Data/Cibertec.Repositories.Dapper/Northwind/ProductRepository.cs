using Cibertec.Models;
using Cibertec.Repositories.Northwind;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class ProductRepository : Repository<Products>, IProductRepository
    {
        public ProductRepository(string ConnectionString) : base(ConnectionString)
        {
        }
    }
}
