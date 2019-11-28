using System;
using System.Collections.Generic;
using Npgsql;

namespace ProjectFinal
{
    class Program
    {
        public Computer Computer
        {
            get => default;
            set
            {
            }
        }

        static void Main(string[] args)
        {
            //
            //Array to store uses of the computer     
            string[] uses = new string[] { "1 - Business", "2 - Editing", "3 - Basic", "4 - Gaming" };
            //Array to store different storagetypes
            string[] storagetypes = new string[] { "1 - HDD", "2 - SSD", "3 - M2 SSD" };
            //Array to store different operatingsystems
            string[] operatingsystem = new string[] { "1 - Windows", "2 - IOS", "3 - Else" };

            //Int input to be used on switch case
            int input;

            double aPrice = 0;
            int aStorageSize = 0;
            int aComputerUse = 0;
            int aStorageType = 0;
            int aComputerOs = 0;
            int aBatteryCapacity;
            int use = 0;
            int Use = 0; // Do not use only case differencing variable names, common source of accidents
            int budget;
            int Budget;
            bool loopBreak = true;

            //While loop to run program until user selects "5 - quit"
            while (loopBreak == true) {
            //Start menu
            Console.WriteLine(" 1 - Add new Computer "); 
            Console.WriteLine(" 2 - Search a laptop "); 
            Console.WriteLine(" 3 - Search a desktop "); 
            Console.WriteLine(" 4 - Show a list of all computers ");
            Console.WriteLine(" 5 - Delete computer from the database");
            Console.WriteLine(" 6 - Quit "); 
            input = int.Parse(Console.ReadLine());

            switch (input)
            {
                // Case1 : Adding new computer to database by user values
                case 1:
                   /** Put these to subfunctions. This method is very large and difficult to follow. 
                       Common rule-of-thumb is that method should fit to a screen */
                                      
                    Console.WriteLine("Give name: ");
                    string aName = Console.ReadLine();
                    
                    /** something like:
                    private static string _givename()
                    {
                        Console.WriteLine("Give name: ");
                        return Console.ReadLine();
                    };
                    
                    And in this function:
                    case 1:
                         string aName = Program._givename();
                    */
                    

                        while (true)
                        {
                            Console.WriteLine("Give price in euros: ");
                            Console.WriteLine("Max price is 50000");
                            try
                            {
                                aPrice = double.Parse(Console.ReadLine());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            if (aPrice > 0 && aPrice < 50000)
                            {
                                break;
                            }
                        }
                        /** And this to own subfunction as well
                        private static int _getprice()
                        {
                            while (true)
                            {
                                int aStorageSize;
                                Console.WriteLine("Storage size in gigabytes: ");
                                Console.WriteLine("Max value is 10000");
                                try
                                {
                                    aStorageSize = int.Parse(Console.ReadLine());
                                }
                                catch  (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                if (aStorageSize > 0 && aStorageSize < 10001)
                                {
                                    return aStorageSize;
                                }
                            }
                        }
                        and now this 'main program' starts to look like:
                    case 1:
                         string aName = Program._givename();
                         aStoragesize = Program._getprice();
                         ...
                         
                         and same for other while(true) loops, easy to detach to own subfunctions
                         */


                        while (true)
                        {
                            Console.WriteLine("Storage size in gigabytes: ");
                            Console.WriteLine("Max value is 10000");
                            try
                            {
                                aStorageSize = int.Parse(Console.ReadLine());
                            }
                            catch  (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            if (aStorageSize > 0 && aStorageSize < 10001)
                            {
                                break;
                            }
                        
                        }

                    while (true)
                    {
                        Console.WriteLine("Computer use: ");

                        //Print different uses from array
                        foreach (var item in uses)
                        {
                            Console.WriteLine(item);
                        }
                        try
                        {
                            aComputerUse = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex);
                        }
                        //Program wont allow values that are smaller than one or values that are higher than lenght of the array
                        if (aComputerUse >= 1 && aComputerUse <= uses.Length)
                        {
                          break;
                        }
                    }
                    
                    while (true)
                    {
                        Console.WriteLine("Storage type: ");
                        foreach (var item in storagetypes)
                        {
                            Console.WriteLine(item);
                        }
                        try
                        {
                            aStorageType = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex);
                        }
                        //Program wont allow values that are smaller than one or values that are higher than lenght of the array
                        if (aStorageType >= 1 && aStorageType <= storagetypes.Length)
                        {
                            break;
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Operating system: ");
                        //Print different operatingsystems
                        foreach (var item in operatingsystem)
                        {
                            Console.WriteLine(item);
                        }
                        try
                        {
                            aComputerOs = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex);
                        }
                        //Program wont allow values that are smaller than one or values that are higher than lenght of the array
                        if (aComputerOs >= 1 && aComputerOs < operatingsystem.Length)
                        {
                            break;
                        }
                    }

                    //Asking the batterycapacity
                    //If computer is desktop -> User must enter 0, else computer is defined as laptop
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
                    //Asking the use 
                    while (true)
                    {
                        Console.WriteLine("Computer use: ");

                        //Print different uses from array
                        foreach (var item in uses)
                        {
                            Console.WriteLine(item);
                        }
                        try
                        {
                        use = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex);
                        }
                        if (use >= 1 && use <= 4)
                        {
                            break;
                        }
                    }
                    //Asking the budget
                    do
                    {
                        while (true)
                        {
                            Console.WriteLine("Budget: ");
                            try
                            {
                                budget = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                                continue;
                            }
                            break;
                        }
                    } while (budget < 0);
   
                    //Connecting to database
                    SqlQuery.Connection();
                    //Method called to import and print Laptops that suit to search criteria
                    SqlQuery.GetFromSqlLaptop(use, budget);

                break;

                //Searching Desktop from the database
                case 3:
                    //Asking the use
                    while (true)
                    {
                        Console.WriteLine("Computer use: ");

                        //Print different uses from array
                        foreach (var item in uses)
                        {
                            Console.WriteLine(item);
                        }
                        try
                        {
                            Use = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex);
                        }
                        if (Use >= 1 && Use <= 4)
                        {
                            break;
                        }
                    }

                    //Asking the budget
                    do
                    {
                        while (true)
                        {
                            Console.WriteLine("Budget: ");
                            try
                            {
                                Budget = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                                continue;
                            }
                            break;
                        }
                    } while (Budget < 0);
           
                    //Connecting to database
                    SqlQuery.Connection();
                    //Method called to import and print Desktops that suit to search criteria
                    SqlQuery.GetFromsqlDesktop(Use, Budget);

                break;
             
                case 4:
                    //Print every computer from the database
                    //Connection to database
                    SqlQuery.Connection();

                    //Import laptops from the database
                    Console.WriteLine("All laptops in the database: ");
                    Console.WriteLine();
                    SqlQuery.GetLaptops();

                    //Import desktops from the database
                    Console.WriteLine();
                    Console.WriteLine("All desktops in the database ");
                    Console.WriteLine();
                    SqlQuery.GetDesktops();

                    break;
                    //Delete computer from the sql
                    case 5:
                        //First we print all the computers
                        SqlQuery.Connection();
                        SqlQuery.GetDesktops();
                        SqlQuery.GetLaptops();
                        //Ask user which computer they want to delete, user must enter ID in numbers
                        Console.WriteLine("Give id of the computer you want to delete: ");
                        int id = int.Parse(Console.ReadLine());
                        //Confirmation that user wants to delete computer, if input is y/Y -> Delete, else break
                        Console.WriteLine("Are you sure that you want to delete this computer? y/n");
                        ConsoleKeyInfo cnf = Console.ReadKey();
                        while (true)
                        {
                            try
                            {
                                if (cnf.Key.ToString() == "y" || cnf.Key.ToString() == "Y")

                                {
                                    SqlQuery.DeleteFromSql(id);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                    //Exiting program 
                    case 6:    
                        loopBreak = false;
  
                break;
            }
          }
        }
    }
}
