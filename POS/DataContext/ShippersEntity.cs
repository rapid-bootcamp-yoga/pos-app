using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_shipper")]
    public class ShippersEntity
    {
        [Key]
        [Column("shipper_id")]
        public String ShipperId { get; set; }

        [Column("company_name")]
        public String CompanyName { get; set; }

        [Column("phone")]
        public String phone { get; set; }
    }
}
