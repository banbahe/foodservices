using System;
using System.Collections.Generic;
using System.Text;

namespace fooddtos
{
    public class OrderDetailDto
    {
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public int IdProduct { get; set; }
    }
}
