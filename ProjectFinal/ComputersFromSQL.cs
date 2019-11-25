using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFinal
{
    class ComputersFromSQL
    {
        private string name;
        private int price;
        private int storagesize;
        private int batterycapacity;
        private string use;
        private string storagetype;
        private string operatingsystem;

        public ComputersFromSQL( string name, int price, int storagesize, int batterycapacity, string use, string storagetype, string operatingsystem )
        {

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
    }
}
