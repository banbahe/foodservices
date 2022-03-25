using System;
using System.Collections.Generic;
using System.Text;

namespace fooddtos
{
    public class ResponseModel
    {
        public dynamic Datums { get; set; }
        public int Flag { get; set; }
        public string Message { get; set; }
    }
}
