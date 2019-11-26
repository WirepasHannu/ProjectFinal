using System;
using System.Collections.Generic;
using Npgsql;

namespace ProjectFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            //Int input to be used on switch case
            int input;
            double aPrice;
            int aStorageSize;
            int aComputerUse = 0;
            int aStorageType = 0;
            int aComputerOs = 0;
            int aBatteryCapacity;

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

                    do
                    {
                        while (true)
                        {
                            Console.WriteLine("Give price: ");
                            try
                            {
                                aPrice = double.Parse(Console.ReadLine());
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                                continue;
                            }
                            break;
                        }
                    } while (aPrice < 0);

                    do
                    {
                        while (true)
                        {
                            Console.WriteLine("Storage size: ");
                            try
                            {
                                aStorageSize = int.Parse(Console.ReadLine());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                continue;
                            }
                            break;
                        }
                    } while (aStorageSize < 0);
                
                    while (true)
                    {
                        Console.WriteLine("Computer use: ");
                        Methods.Use();
                        try
                        {
                            aComputerUse = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex);
                        }                    
                        if (aComputerUse >= 1 && aComputerUse <= 4)
                        {
                          break;
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Storage type: ");
                        Methods.StorageType();
                        try
                        {
                            aStorageType = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex);
                        }
                        if (aStorageType >= 1 && aStorageType < 4)
                        {
                            break;
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Operating system: ");
                        Methods.OperatingSystem();
                        try
                        {
                            aComputerOs = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex);
                        }
                        if (aComputerOs >= 1 && aComputerOs < 4)
                        {
                            break;
                        }
                    }

                    do
                    {
                        while (true)
                        {
                            Console.WriteLine("Battery Capacity "); 
                            try
                            {
                                aBatteryCapacity = int.Parse(Console.ReadLine());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine("If computer is desktop, please enter 0 ");
                                continue;
                            }
                            break;
                        }
                    } while (aBatteryCapacity < 0);

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

                //Searching Laptop from the database
                case 2:
                    Console.WriteLine("Computer use: ");
                    Methods.Use();
                    int use = int.Parse(Console.ReadLine());
                    Console.WriteLine("Budget: ");
                    int budget = int.Parse(Console.ReadLine());
                    //Making connection to database
                    SqlQuery.Connection();
                    //Method called to import and print desktops
                    SqlQuery.GetFromSqlLaptop(use, budget);

                break;

                //Searching Desktop from the database
                case 3:
                    Console.WriteLine("Computer use: ");
                    Methods.Use();
                    int Use = int.Parse(Console.ReadLine());
                    Console.WriteLine("Budget: ");
                    int Budget = int.Parse(Console.ReadLine());
                    //Making connection to database
                    SqlQuery.Connection();
                    //Method called to import and print desktops
                    SqlQuery.GetFromsqlDesktop(Use, Budget);

                break;

                //Print every computer from the database
                case 4:
                    //Connection to database
                    SqlQuery.Connection();

                    //Import laptops from the database
                    Console.WriteLine();
                    Console.WriteLine("All laptops in the database: ");
                    Console.WriteLine();
                    SqlQuery.GetLaptops();

                    //Import desktops from the database
                    Console.WriteLine();
                    Console.WriteLine("All desktops in the database ");
                    Console.WriteLine();
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
