using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZ.Domain.Models
{
    public class Address 
    {
        public string City { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public string State { get; set; }

        public string StreetAddress1 { get; set; }

        public string StreetAddress2 { get; set; }
    }
}
