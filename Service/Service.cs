using System;
using System.Collections.Generic;
using System.Text;

namespace Electronics_Store_MS.Service
{
    public abstract class Service
    {
        private string name;
        private int fee = 500;
        private bool isAdded = false;

        protected string Name { get => name; set => name = value; }
        protected int Fee { get => fee; }
        protected bool IsAdded { get => isAdded; set => isAdded = value; }

        public abstract string AddServiceName();
    }
}
