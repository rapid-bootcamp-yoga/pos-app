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

       
        [Column("product_name")]
        public String ProductName { get; set; }

        
        [Column("supplier_id")]
        public int SupplierId { get; set; }
        public SuppliersEntity Supplier { get; set; }

       
        [Column("category_id")]
        public int CategoryId { get; set; }
        public CategoriesEntity Category { get; set; }

       
        [Column("quantity_per_unit")]
        public String Quantity_per_unit  { get; set; }

        [Column("unit_price")]
        public double UnitPrice { get; set; }

        [Column("units_in_stock")]
        public int UnitsInStock { get; set; }

        [Column("units_in_order")]
        public int UnitsOnOrder { get; set; }

        [Column("reoder_level")]
        public int ReorderLevel { get; set; }

        [Column("discontinued")]
        public bool Discontinued { get; set; }


        public ICollection<OrderDetailsEntity> OrderDetails { get; set; }

        public ProductsEntity(POS.ViewModel.ProductModel model)
        {
            ProductName = model.ProductName;
            SupplierId = model.SupplierId;
            CategoryId = model.CategoryId;
            Quantity_per_unit = model.Quantity_per_unit;
            UnitPrice = model.UnitPrice;
            UnitsInStock = model.UnitsInStock;
            UnitsOnOrder = model.UnitsOnOrder;
            ReorderLevel = model.ReorderLevel;
            Discontinued = model.Discontinued;
        }

        public ProductsEntity()
        {

        }
    }
}
