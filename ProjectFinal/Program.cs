using System;
using System.Collections.Generic;
using Npgsql;

namespace ProjectFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            //int input switch casen käyttöön
            int input;

            double aPrice;

        
            //Start menu
            Console.WriteLine(" 1 - Add new Computer "); //OK
            Console.WriteLine(" 2 - Search a laptop "); //OK
            Console.WriteLine(" 3 - Search a desktop "); //OK
            Console.WriteLine(" 4 - Show a list of all computers "); //OK
            Console.WriteLine(" 5 - Quit "); //OK
            input = int.Parse(Console.ReadLine());

            switch (input)
            {
                // Case1 : Adding new computer to database by user values
                case 1:
                   
                    Console.WriteLine("Give name: ");
                    string aName = Console.ReadLine();

                    Console.WriteLine("Give price: ");
                    aPrice = double.Parse(Console.ReadLine());
     
                    Console.WriteLine("Storage size ");
                    int aStorageSize = int.Parse(Console.ReadLine());

                    Console.WriteLine("Use of computer ");
                    Methods.Use();
                    int aComputerUse = int.Parse(Console.ReadLine());

                    Console.WriteLine("Storage type: ");
                    Methods.StorageType();
                    int aStorageType = int.Parse(Console.ReadLine());

                    Console.WriteLine("Operating system: ");
                    Methods.OperatingSystem();
                    int aComputerOs = int.Parse(Console.ReadLine());
 
                    Console.WriteLine("Battery Capacity ");
                    int aBatteryCapacity = int.Parse(Console.ReadLine());
                    //Connecting to database
                    SqlQuery.Connection();

                    //If batterycapacity is 0 -> Computer is defined as Desktop, else as Laptop
                    if(aBatteryCapacity == 0)
                    {
                        //Creating new Laptop
                        Laptop computer = new Laptop(aName, aPrice, aStorageSize, aBatteryCapacity, aComputerUse, aStorageType, aComputerOs);
                        //Adding Laptop to database
                        SqlQuery.StoreToSql(computer);
                    }
                    else
                    {
                        //Creating new Desktop
                        Laptop computer = new Laptop(aName, aPrice, aStorageSize, aBatteryCapacity, aComputerUse, aStorageType, aComputerOs);
                        //Adding Desktop to database
                        SqlQuery.StoreToSql(computer);
                    }
                    break;

                case 2:
                    //Searching Laptop from the database
                    Console.WriteLine("Tietokoneen käyttötarkoitus: ");
                    Methods.Use();
                    int use = int.Parse(Console.ReadLine());
                    Console.WriteLine("Budjetti: ");
                    int budget = int.Parse(Console.ReadLine());
                    //Making connection to database
                    SqlQuery.Connection();
                    //Method called to import and print desktops
                    SqlQuery.GetFromSqlLaptop(use, budget);

                break;

                case 3:
                    //Searching Desktop from the database
                    Console.WriteLine("Tietokoneen käyttötarkoitus: ");
                    Methods.Use();
                    int Use = int.Parse(Console.ReadLine());
                    Console.WriteLine("Budjetti: ");
                    int Budget = int.Parse(Console.ReadLine());
                    //Making connection to database
                    SqlQuery.Connection();
                    //Method called to import and print desktops
                    SqlQuery.GetFromsqlDesktop(Use, Budget);

                break;

                case 4:
                    //Connection to database
                    SqlQuery.Connection();
                    //Import laptops from the database
                    SqlQuery.GetLaptops();
                    //Import desktops from the database
                    SqlQuery.GetDesktops();
                    break;
                case 5:
                    //Exiting program 
                    Environment.Exit(0);
                    break;
            }
        }

    }
}
