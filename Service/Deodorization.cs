using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.Service
{
    class Deodorization : Service
    {
        public override string AddServiceName()
        {
            if (IsAdded == true)
                return "Công nghệ Kháng khuẩn";
            else return "Không";
        }
    }
}
