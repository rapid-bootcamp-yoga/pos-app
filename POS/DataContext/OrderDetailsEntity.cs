using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("order_details")]
    public class OrderDetailsEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("order_id")]
        public int OrderId { get; set; }

        public OrdersEntity Order { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        public ProductsEntity Product { get; set; }

        [Column("unit_price")]
        public int UnitPrice{ get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("discount")]
        public int Discount { get; set; }


       

        public OrderDetailsEntity(POS.ViewModel.OrderDetailModel model)
        {
            OrderId = model.OrderId;
            ProductId = model.ProductId;
            UnitPrice = model.UnitPrice;
            Quantity = model.Quantity;
            Discount = model.Discount;
        }

        public OrderDetailsEntity()
        {
                
        }

    }


}
