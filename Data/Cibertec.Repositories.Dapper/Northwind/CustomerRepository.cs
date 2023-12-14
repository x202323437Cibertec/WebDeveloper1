using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class CustomerRepository: Repository<Customers>, ICustomerRepository
    {
        public CustomerRepository(string pConectionString) : base(pConectionString) { }

        public int Count()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.ExecuteScalar<int>("Select count(1) from dbo.Customers;");
            }
        }

        public IEnumerable<Customers> PagedList(int pStartRow, int pEndRow)
        {
            if (pStartRow >= pEndRow)
            {
                return new List<Customers>();
            }
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PI_StartRow", pStartRow);
                parameters.Add("@PI_EndRow", pEndRow);
                return connection.Query<Customers>("dbo.CustomerPagedList", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
