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
                int _computerUse,
                int _storageType,
                int _os) :
            base(_name, _price, _storageSize, _batteryCapacity, _computerUse, _storageType, _os)
        {
        }
    }
}