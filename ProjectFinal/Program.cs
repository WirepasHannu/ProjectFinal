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

            //Aloitusvalikko
            Console.WriteLine(" 1 - Add new Computer "); //OK
            Console.WriteLine(" 2 - Search a laptop "); //OK
            Console.WriteLine(" 3 - Search a desktop "); //OK
            Console.WriteLine(" 4 - Show a list of computers "); //OK
            Console.WriteLine(" 5 - Quit "); //OK
            input = int.Parse(Console.ReadLine());

            switch (input)
            {
                // Case 1 Uuden tietokoneen lisääminen tietokantaan
                case 1:
                    Console.WriteLine("Give name: ");
                    string aName = Console.ReadLine();

                    Console.WriteLine("Give price: ");
                    double aPrice = double.Parse(Console.ReadLine());

                    Console.WriteLine("Storage size ");
                    int aStorageSize = int.Parse(Console.ReadLine());

                    //Käyttötarkoituksen vaihtoehdot metodeina
                    Console.WriteLine("Use of computer ");
                    Methods.Use();
                    int aComputerUse = int.Parse(Console.ReadLine());

                    //Muistityppin vaihtoehdot metodeina
                    Console.WriteLine("Storage type: ");
                    Methods.StorageType();
                    int aStorageType = int.Parse(Console.ReadLine());

                    //Käyttöjärjestelmän vaihtoehdot metodeina
                    Console.WriteLine("Operating system: ");
                    Methods.OperatingSystem();
                    int aComputerOs = int.Parse(Console.ReadLine());
 
                    Console.WriteLine("Battery Capacity ");
                    int aBatteryCapacity = int.Parse(Console.ReadLine());
                    //Yhteys tietokantaan
                    SqlQuery.Connection();
                    //Jos batterycapacity = 0 -> Desktop olio
                    //Muutoin Laptop

                    Laptop computer = new Laptop(aName, aPrice, aStorageSize, aBatteryCapacity, aComputerUse, aStorageType, aComputerOs);                   
                    SqlQuery.StoreToSql(computer);

                    break;

                case 2:
                    //Laptopin etsiminen SQL:sta
                    Console.WriteLine("Tietokoneen käyttötarkoitus: ");
                    Methods.Use();
                    int use = int.Parse(Console.ReadLine());
                    Console.WriteLine("Budjetti: ");
                    int budget = int.Parse(Console.ReadLine());
                    SqlQuery.Connection();
                    SqlQuery.GetFromSqlLaptop(use, budget);

                break;

                case 3:
                    //Desktopin etsiminen SQL:sta
                    Console.WriteLine("Tietokoneen käyttötarkoitus: ");
                    Methods.Use();
                    int Use = int.Parse(Console.ReadLine());
                    Console.WriteLine("Budjetti: ");
                    int Budget = int.Parse(Console.ReadLine());
                    SqlQuery.Connection();
                    SqlQuery.GetFromsqlDesktop(Use, Budget);

                    break;

                case 4:

                    //Yhteys tietokantaan
                    SqlQuery.Connection();
                    //Kannettavien tuonti tietokannasta
                    SqlQuery.GetLaptops();
                    //Desktopien tuonti tietokannasta
                    SqlQuery.GetDesktops();
                    break;

                case 5:

                    Environment.Exit(0);
                    break;
            }
        }

    }
}
