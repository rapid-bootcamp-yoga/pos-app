using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class ProductModel
    {
        public int ProductId { set; get; }

        [Required]
        public String ProductName { get; set; }

        [Required]       
        public int SupplierId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public String Quantity_per_unit { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        [Required]
        public int UnitsInStock { get; set; }

        [Required]
        public int UnitsOnOrder { get; set; }

        [Required]
        public int ReorderLevel { get; set; }

        [Required]
        public string Discontinued { get; set; }
    }
}
