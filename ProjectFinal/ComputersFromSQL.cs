using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFinal
{
    class ComputersFromSQL
    {
        private int id;
        private readonly string name;
        private readonly int price;
        private readonly int storagesize;
        private readonly int batterycapacity;
        private readonly string use;
        private readonly string storagetype;
        private readonly string operatingsystem;

        public ComputersFromSQL( int id, string name, int price, int storagesize, int batterycapacity, string use, string storagetype, string operatingsystem )
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
        public string Name()
        {
            return name;
        }
        public int Price()
        {
            return price;
        }
        public int Storagesize()
        {
            return storagesize;
        }
        public int Batterycapacity()
        {
            return batterycapacity;
        }
        public string Use()
        {
            return use;
        }
        public string Storagetype()
        {
            return storagetype;
        }
        public string Operatingsystem()
        {
            return operatingsystem;
        }
        public int Id()
        {
            return id;
        }
    }
}
