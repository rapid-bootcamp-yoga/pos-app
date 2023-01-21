using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class OrderModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int EmployeesId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime RequiredDate { get; set; }

        [Required]
        public DateTime ShippedDate { get; set; }

        [Required]
        public int ShipVia { get; set; }

        [Required]
        public int Freight { get; set; }

        [Required]
        public String ShipName { get; set; }

        [Required]
        public String ShipAddress { get; set; }

        [Required]
        public String ShipCity { get; set; }

        [Required]
        public String ShipRegion { get; set; }

        [Required]
        public String ShipPostalCode { get; set; }

        [Required]
        public String ShipCountry { get; set; }

        //public List<OrderDetailModel> OrderDetails { get; set; }  
    }
}
