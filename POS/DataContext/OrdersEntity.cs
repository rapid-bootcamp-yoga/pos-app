using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_orders")]
    public class OrdersEntity
    {
        [Key]
        [Column("id")]
        public int Id{ get; set; }

        [Column("order_id")]
        public int OrderId { get; set; }

        [Column("customer_id")]
        public int CustomerId { get; set; }

        public CustomersEntity Customers { get; set; }

        [Column("employees_id")]
        public int EmployeesId { get; set; }
        public EmployeesEntity Employees { get; set; }

        [Column("order_date")]
        public DateTime OrderDate { get; set; }

        [Column("required_date")]
        public DateTime ShippedDate { get; set; }

        [Column("ship_via")]
        public int ShipVia { get; set; }

        [Column("freight")]
        public int Freight { get; set; }

        [Column("ship_name")]
        public String ShipAddress { get; set; }

        [Column("ship_city")]
        public String ShipCity { get; set; }

        [Column("ship_region")]
        public String ShipRegion { get; set; }

        [Column("ship_postal_code")]
        public String ShipPostalCode { get; set; }

        [Column("ship_country")]
        public String ShipCountry { get; set; }

        public ICollection<OrderDetailsEntity> OrderDetails { get; set; }
    }
}
