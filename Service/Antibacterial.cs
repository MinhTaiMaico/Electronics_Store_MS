using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.Service
{
    class Antibacterial : Service
    {
        public override string AddServiceName()
        {
            if (IsAdded == true)
                return "Công nghệ Khử mùi";
            else return "Không";
        }
    }
}
