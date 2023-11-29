using dap = Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Cibertec.Models
{
    public class Products
    {
        [dap.Key]
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        [Required]
        public bool Discontinued { get; set; }
    }
}
