using Cibertec.Models;
using System.Collections.Generic;

namespace Cibertec.Repositories.Northwind
{
    public interface ICustomerRepository:IRepository<Customers>
    {
        IEnumerable<Customers> PageList(int pStartRow, int pEndRow);
        int Count();
    }
}
