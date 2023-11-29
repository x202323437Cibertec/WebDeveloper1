using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using Dapper;
using System.Data.SqlClient;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(string pConnectionString) : base(pConnectionString) { }

        public User ValidaterUser(string pEmail, string pPassword)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@PI_Email", pEmail);
                parametros.Add("@PI_Password", pPassword);
                return connection.QueryFirstOrDefault<User>("dbo.ValidateUser", parametros, commandType:System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
