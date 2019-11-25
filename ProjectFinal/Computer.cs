using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFinal
{
    public abstract class Computer
    {

        private string _name;
        private double _price;
        private int _storageSize;
        private int _computerUse;
        private int _storageType;
        private int _os;
        private int _batteryCapacity;

        //Konstruktori 
        public Computer(
                string _name,
                double _price,
                int _storageSize,
                int _batteryCapacity,
                int _computerUse,
                int _storageType,
                int _os
                )
        {
            Name = _name;
            Price = _price;
            StorageSize = _storageSize;
            StorageType = _storageType;
            OperatingSystem = _os;
            ComputerUse = _computerUse;
            BatteryCapacity = _batteryCapacity;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public int StorageSize
        {
            get { return _storageSize; }
            set { _storageSize = value; }
        }
        public int ComputerUse
        {
            get { return _computerUse; }
            set { _computerUse = value; }
        }
        public int StorageType
        {
            get { return _storageType; }
            set { _storageType = value; }
        }
        public int OperatingSystem
        {
            get { return _os; }
            set { _os = value; }
        }
        public int BatteryCapacity
        {
            get { return _batteryCapacity; }
            set { _batteryCapacity = value; }
        }
    }
}
