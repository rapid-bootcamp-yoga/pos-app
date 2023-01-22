using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Response
{
    public class ProductResponse
    {
        public int Id { set; get; }

        public String ProductName { get; set; }

        public String CompanyName { get; set; }

        public String CategoryName { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        public int UnitsOnOrder { get; set; }

        public int ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

    }
}
