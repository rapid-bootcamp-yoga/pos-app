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
    internal class OrderDetailsEntity
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("order_id")]
        public int OrderId { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("unit_price")]
        public int UnitPrice{ get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("discount")]
        public int Discount { get; set; }
    }
}
