using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFinal
{
    class Desktop : Computer
    {
        //Constructor when creating new desktop and adding it to the database
        public Desktop(
                string _name,
                double _price,
                int _storageSize,
                int _batteryCapacity,
                int _computerUse,
                int _storageType,
                int _os) : base(_name, _price, _storageSize, _batteryCapacity, _computerUse, _storageType, _os)
        {
        }
        //Constructor that is used when getting data from the database
        public Desktop(
            int id,
            string name,
            int price,
            int storagesize,
            int batterycapacity,
            string use,
            string storagetype,
            string operatingsystem) : base(id, name, price, storagesize, batterycapacity, use, storagetype, operatingsystem)
        {
        }
    }
}