using System;
using System.Collections.Generic;
using System.Text;

namespace fooddtos
{
    public class OrderDto
    {
        public int CurrentStatus { get; set; }

        public int DateEntry { get; set; }

        public int IdOrder { get; set; }

        public decimal Total { get; set; }
        public string Folio { get; set; }

        public string ClientName { get; set; }
        public IEnumerable<OrderDetailDto> Details { get; set; }
    }
}
