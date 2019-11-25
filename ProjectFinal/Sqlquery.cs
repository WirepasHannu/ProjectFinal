using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace ProjectFinal
{
    class SqlQuery
    {
        // Connection to Database
        private const string HOST = "localhost";
        private const string USERNAME = "postgres";
        private const string PASSWORD = "rc86ezm5";
        private const string DB = "Computer";
        private const string CONNECTION_STRING = "Host=" + HOST + ";Username=" + USERNAME + ";Password=" + PASSWORD + ";Database=" + DB;

        static private NpgsqlConnection connection;
        static private NpgsqlCommand GetAllLaptops = null;
        static private NpgsqlCommand GetAllDesktops = null;
        static private NpgsqlCommand addComputer = null;

        //Connecting to database
        public static void Connection()
        {
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
        }

        //Lisääminen tietokantaan
        public static void StoreToSql(Laptop computer)
        {
            using (addComputer = new NpgsqlCommand("INSERT INTO computer(name, price, storagesize, storagetypeid, operatingsystemid, useid, batterycapacity)" + "VALUES (@name, @price, @storagesize, @storagetypeid, @operatingsystemid, @useid, @batterycapacity)", connection))
            {
                addComputer.Parameters.AddWithValue("name", computer.Name);
                addComputer.Parameters.AddWithValue("price", computer.Price);
                addComputer.Parameters.AddWithValue("storagesize", computer.StorageSize);
                addComputer.Parameters.AddWithValue("storagetypeid", computer.StorageType);
                addComputer.Parameters.AddWithValue("operatingsystemid", computer.OperatingSystem);
                addComputer.Parameters.AddWithValue("useid", computer.ComputerUse);
                addComputer.Parameters.AddWithValue("batterycapacity", computer.BatteryCapacity);
                addComputer.ExecuteNonQuery();
            }
        }
        public static void GetFromSql()
        {
            //Tietokannasta hakeminen
        }

        //Kannettavien palauttamien db:sta
        static public List<Laptop> GetLaptops()
        {
            List<Laptop> listLaptop = new List<Laptop>();
            using (GetAllLaptops = new NpgsqlCommand("SELECT computer.name,computer.price,computer.storagesize, computer.batterycapacity, computeruse.use, storagetype.storagetype, operatingsystem.operating_system FROM \"computer\" LEFT JOIN storagetype on computer.storagetypeid = storagetype.idstoragetype LEFT JOIN computeruse on computer.useid = computeruse.idcomputeruse LEFT JOIN operatingsystem on computer.operatingsystemid = operatingsystem.idoperatingsystem WHERE batterycapacity > 0;", connection))
            {
                GetAllLaptops.Prepare();

                using (NpgsqlDataReader computers = GetAllLaptops.ExecuteReader())

                    while (computers.Read())
                    {
                        listLaptop.Add(new Laptop(computers.GetString(0), computers.GetInt32(1), computers.GetInt32(2), computers.GetInt32(3), computers.GetString(4), computers.GetString(5), computers.GetString(6)));
                        Console.WriteLine($" {computers.GetString(0)} {computers.GetInt32(1)} {computers.GetInt32(2)} {computers.GetInt32(3)} {computers.GetString(4)} {computers.GetString(5)} {computers.GetString(6)}");
                    }
                return listLaptop;
            }
        }
        //Desktopien palauttaminen db:sta
        static public List<Desktop> GetDesktops()
        {
            List<Desktop> listDesktop = new List<Desktop>();
            
            using (GetAllDesktops = new NpgsqlCommand("SELECT computer.name,computer.price,computer.storagesize, computer.batterycapacity, computeruse.use, storagetype.storagetype, operatingsystem.operating_system FROM \"computer\" LEFT JOIN storagetype on computer.storagetypeid = storagetype.idstoragetype LEFT JOIN computeruse on computer.useid = computeruse.idcomputeruse LEFT JOIN operatingsystem on computer.operatingsystemid = operatingsystem.idoperatingsystem WHERE batterycapacity = 0;", connection))
            {
                GetAllDesktops.Prepare();

                using (NpgsqlDataReader computers = GetAllDesktops.ExecuteReader())

                    while (computers.Read())
                    {
                        listDesktop.Add(new Desktop(computers.GetString(0), computers.GetInt32(1), computers.GetInt32(2), computers.GetInt32(3), computers.GetString(4), computers.GetString(5), computers.GetString(6)));
                        Console.WriteLine($" {computers.GetString(0)} {computers.GetInt32(1)} {computers.GetInt32(2)} {computers.GetInt32(3)} {computers.GetString(4)} {computers.GetString(5)} {computers.GetString(6)}");
                    }
                return listDesktop;
            }
        }
    }
}