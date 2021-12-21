using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.Service
{
    class Deodorization : Service
    {
        public override string AddServiceName()
        {
            Name = "Công nghệ Kháng khuẩn";
            if (IsAdded == true)
                return "Có";
            else return "Không";
        }
    }
}
