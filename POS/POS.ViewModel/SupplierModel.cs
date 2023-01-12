using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class SupplierModel
    {
        public int Id { set; get; }

        [Required]
        public String CompanyName { set; get; }

        [Required]
        public String ContactName { set; get; }

        [Required]
        public String ContactTitle { get; set; }

        [Required]
        public String Address { get; set; }

        [Required]
        public String City { get; set; }

        [Required]
        public String Region { get; set; }

        [Required]
        public String PostalCode { get; set; }

        [Required]
        public String Country { get; set; }

        [Required]
        public String Phone { get; set; }

        [Required]
        public String Fax { get; set; }

        [Required]
        public String HomePhone { get; set; }
    }
}
