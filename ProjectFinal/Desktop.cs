using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFinal
{
    class Desktop : Computer
    {
        public Desktop(
            string _name,
                double _price,
                int _storageSize,
                int _batteryCapacity,
                string _computerUse,
                string _storageType,
                string _os) :
            base(_name, _price, _storageSize, _batteryCapacity, _computerUse, _storageType, _os)
        {
        }
    }
}