using System;
using System.Collections.Generic;
using System.Text;

namespace fooddtos
{
    public class ProductDto
    {
        public int CurrentStatus { get; set; }
        public int DateEntry { get; set; }
        public int IdProduct { get; set; }
        public string Name { get; set; }
        private string _sku;
        public string SKU
        {
            get { return _sku; }
            set { _sku = value.ToUpper(); }
        }


        public string ImgPath { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal Existence { get; set; }
    }
}
