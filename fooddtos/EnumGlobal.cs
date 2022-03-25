using System;
using System.Collections.Generic;
using System.Text;

namespace fooddtos
{
    public enum CSTATUS
    {
        Error = -100,
        ItemExisting = -2,
        Canceled = -1,
        Null_Empty_NoFound = 0,
        Pending = 1,
        InProcess = 2,
        Completed = 3,
        Delivered = 4,
        Ok = 100,
        ProductNotAvailable = -101,
        ProductAvaliable = 101,
    }
    internal class EnumGlobal
    {
    }
}
