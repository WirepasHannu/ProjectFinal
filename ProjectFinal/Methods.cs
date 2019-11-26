using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFinal
{
    class Methods
    { 
        
        //Method to print storagetypes
        public static void StorageType()
        {
            string[] storage = new string[] { "1 - HDD", "2 - SSD", "3 - M2 SSD" };
            foreach (var item in storage)
            {
                Console.WriteLine(item);
            }
        }

        //Method to print different operating systems
        public static void OperatingSystem()
        {
            string[] operatingsystem = new string[] { "1 - Windows", "2 - IOS", "3 - Else" };
            foreach (var item in operatingsystem)
            {
                Console.WriteLine(item);
            }
        }
        //Array of different computer uses and values
        public static void Use()
        {
            string[] uses = new string[] { "1 - Business", "2 - Editing", "3 - Basic", "4 - Gaming" };
            foreach (var item in uses)
            {
                Console.WriteLine(item);
            }
        }
    }
}