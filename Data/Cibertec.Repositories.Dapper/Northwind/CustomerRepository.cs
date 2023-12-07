using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class CustomerRepository: Repository<Customers>, ICustomerRepository
    {
        public CustomerRepository(string pConectionString) : base(pConectionString)
        { 
        }

        public int Count()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.ExecuteScalar<int>("Select count(1) from dbo.Customer;");
            }
        }

        public IEnumerable<Customers> PageList(int pStartRow, int pEndRow)
        {
            throw new System.NotImplementedException();
        }
    }
}
