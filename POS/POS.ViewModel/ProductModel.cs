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

        //public SuppliersEntity Suppliers { get; set; }

        [Required]
        public int CategoryId { get; set; }

        // public CategoriesEntity Categories { get; set; }

        [Required]
        public String quantity_per_unit { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        [Required]
        public int UnitsInStock { get; set; }

        [Required]
        public int UnitsOnOrder { get; set; }

        [Required]
        public int ReorderLevel { get; set; }

        [Required]
        public bool Discontinued { get; set; }
    }
}
