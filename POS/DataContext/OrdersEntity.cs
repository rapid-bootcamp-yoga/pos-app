using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime;
using System.Runtime.CompilerServices;
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

        [Required]
        [Column("customer_id")]
        public int CustomerId { get; set; }
        public CustomersEntity Customer { get; set; }

        [Required]
        [Column("employees_id")]
        public int EmployeesId { get; set; }
        public EmployeesEntity Employees { get; set; }

        [Required]
        [Column("order_date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Column("required_date")]
        public DateTime RequiredDate { get; set; }

        [Required]
        [Column("shipped_date")]
        public DateTime ShippedDate { get; set; }

        [Required]
        [Column("ship_via")]
        public int ShipVia { get; set; }

        [Required]
        [Column("freight")]
        public int Freight { get; set; }

        [Required]
        [Column("ship_name")]
        public String ShipName { get; set; }

        [Required]
        [Column("ship_address")]
        public String ShipAddress { get; set; }

        [Required]
        [Column("ship_city")]
        public String ShipCity { get; set; }

        [Required]
        [Column("ship_region")]
        public String ShipRegion { get; set; }

        [Required]
        [Column("ship_postal_code")]
        public String ShipPostalCode { get; set; }

        [Required]
        [Column("ship_country")]
        public String ShipCountry { get; set; }

        public ICollection<OrderDetailsEntity> OrderDetails { get; set; }

       public OrdersEntity(POS.ViewModel.OrderModel model)
        {
            CustomerId= model.CustomerId;
            EmployeesId = model.EmployeesId;
            OrderDate = model.OrderDate;
            RequiredDate = model.RequiredDate;
            ShippedDate = model.ShippedDate;
            ShipVia = model.ShipVia;
            Freight = model.Freight;
            ShipName = model.ShipName;
            ShipAddress = model.ShipAddress;
            ShipCity = model.ShipCity;
            ShipRegion = model.ShipRegion;
            ShipPostalCode = model.ShipPostalCode;
            ShipCountry = model.ShipCountry;
        }
       
        

        public OrdersEntity()
        {
                
        }
    }
}
