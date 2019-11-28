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

        //Values to be used when getting data from sql
        /** You don't need separate values for these, at least for duplicate items. Use values above directly? */
        
        private readonly int id;
        private readonly string name;
        private readonly int price; /** Set value directly to _price? */
        private readonly int storagesize;
        private readonly int batterycapacity;
        private readonly string use;
        /** You have this and _computerUse representing same item. Use only either one */
        
        private readonly string storagetype;
        private readonly string operatingsystem;
   
        /* You could create private 'base constructor for common values'
        private Computer(
            string name,
            double price,
            int storageSize,
            int batterycapacity,
            ) 
        {
        ... here, initialize common members, like:
            this.name=name;
            this.price=price;
            ...
        }
        */
            
        
        //Constructor when creating new computer and adding it to the database
        public Computer(
                string _name,
                double _price,
                int _storageSize,
                int _batteryCapacity,
                int _computerUse,
                int _storageType,
                int _os
                )
        /* And use here the 'base constructor:
        : this(_name, _price, _storageSize, _batteryCapacity) */
        {
            Name = _name;
            Price = _price;
            StorageSize = _storageSize;
            StorageType = _storageType;
            OperatingSystem = _os;
            ComputerUse = _computerUse;
            BatteryCapacity = _batteryCapacity;
        }
        //Constructor which is used when taking data from the database
        public Computer(
            int id, 
            string name, 
            int price, 
            int storagesize, 
            int batterycapacity, 
            string use, 
            string storagetype, 
            string operatingsystem)
        {
            this.id = id; 
            this.name = name;
            this.price = price;
            this.storagesize = storagesize;
            this.batterycapacity = batterycapacity;
            this.use = use;
            this.storagetype = storagetype;
            this.operatingsystem = operatingsystem;
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
        //Getters that are used when getting data from the database
        public string NameDB()
        { return name; }
        public int PriceDB()
        { return price; }
        public int StoragesizeDB()
        { return storagesize; }
        public int BatterycapacityDB()
        { return batterycapacity; }
        public string UseDB()
        { return use; }
        public string StoragetypeDB()
        { return storagetype; }
        public string OperatingsystemDB()
        { return operatingsystem; }
        public int IdDB()
        { return id; }
    }
}
