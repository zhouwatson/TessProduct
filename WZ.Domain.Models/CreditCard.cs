using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZ.Domain.Models
{
    public class CreditCard 
    {
        public string CardNumber { get; set; }

        public int ExpireMonth { get; set; }

        public int ExpireYear { get; set; }

        //public string NameOnCard { get; set; }

        public string SecurityCode { get; set; }
    }
}
