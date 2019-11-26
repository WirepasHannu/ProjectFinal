using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using System.Linq;
using System.Threading.Tasks;

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
        static private NpgsqlCommand searchComputer = null;

        //Connecting to the database
        public static void Connection()
        {
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
        }

        //Adding Computer to database
        public static void StoreToSql(Laptop computer)
        {
            using (addComputer = new NpgsqlCommand("INSERT INTO computer(name, price, storagesize, storagetypeid, operatingsystemid, useid, batterycapacity,date_added, time_added)" + "VALUES (@name, @price, @storagesize, @storagetypeid, @operatingsystemid, @useid, @batterycapacity, @date_added, @time_added)", connection))
            {
                addComputer.Parameters.AddWithValue("name", computer.Name);
                addComputer.Parameters.AddWithValue("price", computer.Price);
                addComputer.Parameters.AddWithValue("storagesize", computer.StorageSize);
                addComputer.Parameters.AddWithValue("storagetypeid", computer.StorageType);
                addComputer.Parameters.AddWithValue("operatingsystemid", computer.OperatingSystem);
                addComputer.Parameters.AddWithValue("useid", computer.ComputerUse);
                addComputer.Parameters.AddWithValue("batterycapacity", computer.BatteryCapacity);
                addComputer.Parameters.AddWithValue("date_added", DateTime.Now);
                addComputer.Parameters.AddWithValue("time_added", DateTime.Now.TimeOfDay);
                addComputer.ExecuteNonQuery();
            }
        }
        //Searching Laptop from the database
        public static void GetFromSqlLaptop(int use, int budget)
        {
            List<Laptop> searchedcomputers = new List<Laptop>();
            using (searchComputer = new NpgsqlCommand($"SELECT computer.id, computer.name,computer.price,computer.storagesize, computer.batterycapacity, computeruse.use, storagetype.storagetype, operatingsystem.operating_system FROM computer LEFT JOIN storagetype on computer.storagetypeid = storagetype.idstoragetype LEFT JOIN computeruse on computer.useid = computeruse.idcomputeruse LEFT JOIN operatingsystem on computer.operatingsystemid = operatingsystem.idoperatingsystem WHERE price < {budget}  AND computer.useid = '{use}' AND batterycapacity > 0;", connection))
            {
                searchComputer.Prepare();
                using NpgsqlDataReader searchresult = searchComputer.ExecuteReader();
                while (searchresult.Read())
                {
                    searchedcomputers.Add(new Laptop(searchresult.GetInt16(0), searchresult.GetString(1), searchresult.GetInt32(2), searchresult.GetInt32(3), searchresult.GetInt32(4), searchresult.GetString(5), searchresult.GetString(6), searchresult.GetString(7)));
                    Console.WriteLine($" {searchresult.GetInt16(0)} {searchresult.GetString(1)} {searchresult.GetInt32(2)} {searchresult.GetInt32(3)} {searchresult.GetInt32(4)} {searchresult.GetString(5)} {searchresult.GetString(6)} {searchresult.GetString(7)}");
                }
            } 
        }
        //Searching Desktop from the database
        public static void GetFromsqlDesktop(int Use, int Budget)
        {
            List<Desktop> searchedcomputers = new List<Desktop>();
            using (searchComputer = new NpgsqlCommand($"SELECT computer.id, computer.name,computer.price,computer.storagesize, computer.batterycapacity, computeruse.use, storagetype.storagetype, operatingsystem.operating_system FROM computer LEFT JOIN storagetype on computer.storagetypeid = storagetype.idstoragetype LEFT JOIN computeruse on computer.useid = computeruse.idcomputeruse LEFT JOIN operatingsystem on computer.operatingsystemid = operatingsystem.idoperatingsystem WHERE price < {Budget}  AND computer.useid = '{Use}' AND batterycapacity = 0 OR NULL;", connection))
            {
                searchComputer.Prepare();
                using NpgsqlDataReader searchresult = searchComputer.ExecuteReader();
                while (searchresult.Read())
                {
                    searchedcomputers.Add(new Desktop(searchresult.GetInt16(0), searchresult.GetString(1), searchresult.GetInt32(2), searchresult.GetInt32(3), searchresult.GetInt32(4), searchresult.GetString(5), searchresult.GetString(6), searchresult.GetString(7)));
                    Console.WriteLine($" {searchresult.GetInt16(0)} {searchresult.GetString(1)} {searchresult.GetInt32(2)} {searchresult.GetInt32(3)} {searchresult.GetInt32(4)} {searchresult.GetString(5)} {searchresult.GetString(6)} {searchresult.GetString(7)}");
                }
            }
        }
        //Getting laptops from the database
        static public List<Laptop> GetLaptops()
        {
            List<Laptop> listLaptop = new List<Laptop>();
            using (GetAllLaptops = new NpgsqlCommand("SELECT computer.id, computer.name,computer.price,computer.storagesize, computer.batterycapacity, computeruse.use, storagetype.storagetype, operatingsystem.operating_system FROM \"computer\" LEFT JOIN storagetype on computer.storagetypeid = storagetype.idstoragetype LEFT JOIN computeruse on computer.useid = computeruse.idcomputeruse LEFT JOIN operatingsystem on computer.operatingsystemid = operatingsystem.idoperatingsystem WHERE batterycapacity > 0;", connection))
            {
                GetAllLaptops.Prepare();
                using (NpgsqlDataReader computers = GetAllLaptops.ExecuteReader())

                    while (computers.Read())
                    {
                        listLaptop.Add(new Laptop(computers.GetInt16(0), computers.GetString(1), computers.GetInt32(2), computers.GetInt32(3), computers.GetInt32(4), computers.GetString(5), computers.GetString(6), computers.GetString(7)));
                        Console.WriteLine($" {computers.GetInt16(0)} {computers.GetString(1)} {computers.GetInt32(2)} {computers.GetInt32(3)} {computers.GetInt32(4)} {computers.GetString(5)} {computers.GetString(6)} {computers.GetString(7)}");
                    }
                return listLaptop;
            }
        }
        //Getting desktops from the database
        static public List<Desktop> GetDesktops()
        {
            List<Desktop> listDesktop = new List<Desktop>();          
            using (GetAllDesktops = new NpgsqlCommand("SELECT computer.id, computer.name,computer.price,computer.storagesize, computer.batterycapacity, computeruse.use, storagetype.storagetype, operatingsystem.operating_system FROM \"computer\" LEFT JOIN storagetype on computer.storagetypeid = storagetype.idstoragetype LEFT JOIN computeruse on computer.useid = computeruse.idcomputeruse LEFT JOIN operatingsystem on computer.operatingsystemid = operatingsystem.idoperatingsystem WHERE batterycapacity = 0;", connection))
            {
                GetAllDesktops.Prepare();

                using (NpgsqlDataReader computers = GetAllDesktops.ExecuteReader())

                    while (computers.Read())
                    {
                        listDesktop.Add(new Desktop(computers.GetInt16(0), computers.GetString(1), computers.GetInt32(2), computers.GetInt32(3), computers.GetInt32(4), computers.GetString(5), computers.GetString(6), computers.GetString(7)));
                        Console.WriteLine($" {computers.GetInt16(0)} {computers.GetString(1)} {computers.GetInt32(2)} {computers.GetInt32(3)} {computers.GetInt32(4)} {computers.GetString(5)} {computers.GetString(6)} {computers.GetString(7)}");
                    }
                return listDesktop;
            }
        }  
    }
}
