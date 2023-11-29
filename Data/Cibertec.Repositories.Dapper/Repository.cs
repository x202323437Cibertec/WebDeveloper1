using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.Dapper
{
    public class Repository<T> : IRepository<T> where T: class
    {
        protected string _connectionString;

        public Repository(string pConectionString)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $"{ type.Name }"; };
            _connectionString = pConectionString;
        }

        public bool Delete(T entity)
        {
            using (var conection = new SqlConnection(_connectionString))
            {
                return conection.Delete(entity);
            }
        }
        public bool Update(T entity)
        {
            using (var conection = new SqlConnection(_connectionString))
            {
                return conection.Update(entity);
            }
        }
        public int Insert(T entity)
        {
            using (var conection = new SqlConnection(_connectionString))
            {
                return (int)conection.Insert(entity);
            }
        }
        public IEnumerable<T> GetList()
        {
            using (var conection = new SqlConnection(_connectionString))
            {
                return conection.GetAll<T>();
            }
        }
        public T GetById(int pId)
        {
            using (var conection = new SqlConnection(_connectionString))
            {
                return conection.Get<T>(pId);
            }
        }

        public T GetById(string pId)
        {
            using (var conection = new SqlConnection(_connectionString))
            {
                return conection.Get<T>(pId);
            }
        }

    }
}
