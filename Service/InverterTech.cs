using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.Service
{
    public class InverterTech : Service
    {
        public override string AddServiceName()
        {
            if (IsAdded == true)
                return "Công nghệ Inverter";
            else return "Không";
        }
    }
}
