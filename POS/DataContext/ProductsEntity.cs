using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_product")]
    public class ProductsEntity
    {

        [Key]
        [Column("id")]
        public int Id { set; get; }

        [Required]
        [Column("product_name")]
        public String ProductName { get; set; }

        [Required]
        [Column("supplier_id")]
        public int SupplierId { get; set; }

      
        public SuppliersEntity Suppliers { get; set; }

        [Required]
        [Column("category_id")]
        public int CategoryId { get; set; }

        public CategoriesEntity Categories { get; set; }

        [Required]
        [Column("quantity_per_unit")]
        public String Quantity_per_unit  { get; set; }

        [Required]
        [Column("unit_price")]
        public double UnitPrice { get; set; }

        [Required]
        [Column("units_in_stock")]
        public int UnitsInStock { get; set; }

        [Required]
        [Column("units_in_order")]
        public int UnitsOnOrder { get; set; }

        [Required]
        [Column("reoder_level")]
        public int ReorderLevel { get; set; }

        [Required]
        [Column("discontinued")]
        public bool Discontinued { get; set; }


        public ICollection<OrderDetailsEntity> OrderDetails { get; set; }

        //public ProductsEntity(POS.ViewModel.ProductModel model)
        //{
        //    ProductName = model.ProductName;
        //    SupplierId = model.SupplierId;
        //    CategoryId = model.CategoryId;
        //    Quantity_per_unit = model.quantity_per_unit;
        //    UnitPrice = model.UnitPrice;
        //    UnitsInStock = model.UnitsInStock;
        //    UnitsOnOrder = model.UnitsOnOrder;
        //    ReorderLevel = model.ReorderLevel;
        //    Discontinued = model.Discontinued;
        //}

        public ProductsEntity()
        {

        }
    }
}
