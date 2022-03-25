using System;
using System.Collections.Generic;
using System.Text;

namespace fooddtos
{
    public class FoodSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string dbxfolder { get; set; }
        public string dbxcredentials { get; set; }
    }
}
