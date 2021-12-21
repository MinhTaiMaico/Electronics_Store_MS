using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.Service
{
    class Antibacterial : Service
    {
        public override string AddServiceName()
        {
            Name = "Công nghệ Khử mùi";
            if (IsAdded == true)
                return "Có";
            else return "Không";
        }
    }
}
