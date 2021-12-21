using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.Service
{
    public class InverterTech : Service
    {
        public override string AddServiceName()
        {
            Name = "Công nghệ Inverter";
            if (IsAdded == true)
                return "Có";
            else return "Không";
        }
    }
}
