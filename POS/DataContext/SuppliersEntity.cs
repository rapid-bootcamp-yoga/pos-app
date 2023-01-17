using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_supplier")]
    public class SuppliersEntity
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }

        [Column("company_name")]
        public String CompanyName { set; get; }

        [Column("contact_name")]
        public String ContactName { set; get; }

        [Column("contact_title")]
        public String ContactTitle { get; set; }

        [Column("address")]
        public String Address { get; set; }

        [Column("city")]
        public String City { get; set; }

        [Column("region")]
        public String Region { get; set; }

        [Column("postal_code")]
        public String PostalCode { get; set; }

        [Column("country")]
        public String Country { get; set; }

        [Column("phone")]
        public String Phone { get; set; }

        [Column("fax")]
        public String Fax { get; set; }

        [Column("home_phone")]
        public String HomePage { get; set; }

        public ICollection<ProductsEntity> Products { get; set; }

        public SuppliersEntity(POS.ViewModel.SupplierModel model)
        {
            CompanyName = model.CompanyName;
            ContactName = model.ContactName;
            ContactTitle = model.ContactTitle;
            Address = model.Address;
            City = model.City;
            Region = model.Region;
            PostalCode = model.PostalCode;
            Country = model.Country;
            Phone = model.Phone;
            Fax = model.Fax;
            HomePage = model.HomePage;
        }
        public SuppliersEntity()
        {

        }
    }
}
